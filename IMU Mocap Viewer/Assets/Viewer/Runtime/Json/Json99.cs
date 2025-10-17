// Based on https://github.com/xioTechnologies/JSON

using System;
using System.Globalization;
using System.Text;

namespace Viewer.Runtime.Json
{
    /// <summary>
    /// Result codes for JSON parsing operations.
    /// </summary>
    public enum JsonResult
    {
        Ok,
        InvalidSyntax,
        UnexpectedType,
        MissingObjectEnd,
        MissingArrayEnd,
        MissingComma,
        MissingKey,
        MissingColon,
        MissingStringEnd,
        StringTooLong,
        InvalidStringCharacter,
        InvalidStringEscapeSequence,
        InvalidStringHexEscapeSequence,
        UnableToParseStringHexEscapeSequence,
        InvalidNumberFormat,
        NumberTooLong,
        UnableToParseNumber,
    }

    /// <summary>
    /// JSON value types.
    /// </summary>
    public enum JsonType
    {
        String,
        Number,
        Object,
        Array,
        Boolean,
        Null,
    }

    /// <summary>
    /// Zero-allocation JSON parser using ReadOnlySpan for streaming parsing.
    /// </summary>
    public static class Json99
    {
        /// <summary>
        /// Parses value type. The position is not modified.
        /// </summary>
        /// <param name="json">JSON span</param>
        /// <param name="position">Current position</param>
        /// <param name="type">Parsed type</param>
        /// <returns>Result</returns>
        public static JsonResult ParseType(ReadOnlySpan<char> json, ref int position, out JsonType type)
        {
            SkipWhiteSpace(json, ref position);
            
            int pos = position;
            
            if (pos >= json.Length)
            {
                type = default;
                return JsonResult.InvalidSyntax;
            }

            switch (json[pos])
            {
                case '"':
                    type = JsonType.String;
                    return JsonResult.Ok;
                case '-':
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                    type = JsonType.Number;
                    return JsonResult.Ok;
                case '{':
                    type = JsonType.Object;
                    return JsonResult.Ok;
                case '[':
                    type = JsonType.Array;
                    return JsonResult.Ok;
                case 't':
                case 'f':
                    type = JsonType.Boolean;
                    return JsonResult.Ok;
                case 'n':
                    type = JsonType.Null;
                    return JsonResult.Ok;
                default:
                    type = default;
                    return JsonResult.InvalidSyntax;
            }
        }

        /// <summary>
        /// Advances the position to the first non-whitespace character.
        /// </summary>
        /// <param name="json">JSON span</param>
        /// <param name="position">Current position</param>
        private static void SkipWhiteSpace(ReadOnlySpan<char> json, ref int position)
        {
            while (position < json.Length)
            {
                switch (json[position])
                {
                    case ' ':
                    case '\t':
                    case '\n':
                    case '\r':
                        position++;
                        break;
                    default:
                        return;
                }
            }
        }

        /// <summary>
        /// Checks that the type matches the expected type. The position is not modified.
        /// </summary>
        /// <param name="json">JSON span</param>
        /// <param name="position">Current position</param>
        /// <param name="expectedType">Expected type</param>
        /// <returns>Result</returns>
        private static JsonResult CheckType(ReadOnlySpan<char> json, ref int position, JsonType expectedType)
        {
            JsonResult result = ParseType(json, ref position, out JsonType type);
            if (result != JsonResult.Ok)
                return result;

            if (type != expectedType)
                return JsonResult.UnexpectedType;

            return JsonResult.Ok;
        }

        /// <summary>
        /// Parses an object start. The position is advanced to the first non-whitespace character after the object start.
        /// </summary>
        /// <param name="json">JSON span</param>
        /// <param name="position">Current position</param>
        /// <returns>Result</returns>
        public static JsonResult ParseObjectStart(ReadOnlySpan<char> json, ref int position)
        {
            JsonResult result = CheckType(json, ref position, JsonType.Object);
            
            if (result != JsonResult.Ok)
                return result;

            position++;
            
            SkipWhiteSpace(json, ref position);
            
            return JsonResult.Ok;
        }

        /// <summary>
        /// Parses an object end. The position is advanced to the first character after the object end.
        /// </summary>
        /// <param name="json">JSON span</param>
        /// <param name="position">Current position</param>
        /// <returns>Result</returns>
        public static JsonResult ParseObjectEnd(ReadOnlySpan<char> json, ref int position)
        {
            SkipWhiteSpace(json, ref position);
            if (position >= json.Length || json[position] != '}')
                return JsonResult.MissingObjectEnd;

            position++;
            return JsonResult.Ok;
        }

        /// <summary>
        /// Parses an array start. The position is advanced to the first non-whitespace character after the array start.
        /// </summary>
        /// <param name="json">JSON span</param>
        /// <param name="position">Current position</param>
        /// <returns>Result</returns>
        public static JsonResult ParseArrayStart(ReadOnlySpan<char> json, ref int position)
        {
            JsonResult result = CheckType(json, ref position, JsonType.Array);
            if (result != JsonResult.Ok)
                return result;

            position++;
            SkipWhiteSpace(json, ref position);
            return JsonResult.Ok;
        }

        /// <summary>
        /// Parses an array end. The position is advanced to the first character after the array end.
        /// </summary>
        /// <param name="json">JSON span</param>
        /// <param name="position">Current position</param>
        /// <returns>Result</returns>
        public static JsonResult ParseArrayEnd(ReadOnlySpan<char> json, ref int position)
        {
            SkipWhiteSpace(json, ref position);
            if (position >= json.Length || json[position] != ']')
                return JsonResult.MissingArrayEnd;

            position++;
            return JsonResult.Ok;
        }

        /// <summary>
        /// Parses a comma. The position is advanced to the first character after the comma.
        /// </summary>
        /// <param name="json">JSON span</param>
        /// <param name="position">Current position</param>
        /// <returns>Result</returns>
        public static JsonResult ParseComma(ReadOnlySpan<char> json, ref int position)
        {
            SkipWhiteSpace(json, ref position);
            if (position >= json.Length || json[position] != ',')
                return JsonResult.MissingComma;

            position++;
            return JsonResult.Ok;
        }

        /// <summary>
        /// Parses the key in a JSON object. The position is advanced to the character after the colon that separates the key/value pair.
        /// </summary>
        /// <param name="json">JSON span</param>
        /// <param name="position">Current position</param>
        /// <param name="destination">Destination span</param>
        /// <param name="numberOfBytes">Number of bytes written</param>
        /// <returns>Result</returns>
        public static JsonResult ParseKey(ReadOnlySpan<char> json, ref int position, Span<char> destination, out int numberOfBytes)
        {
            // Check type
            if (CheckType(json, ref position, JsonType.String) != JsonResult.Ok)
            {
                numberOfBytes = 0;
                return JsonResult.MissingKey;
            }

            // Parse key
            JsonResult result = ParseString(json, ref position, destination, out numberOfBytes);
            if (result != JsonResult.Ok)
                return result;

            // Parse colon
            SkipWhiteSpace(json, ref position);
            if (position >= json.Length || json[position] != ':')
                return JsonResult.MissingColon;

            position++;
            return JsonResult.Ok;
        }

        /// <summary>
        /// Parse string. The position is advanced to the first character after the string.
        /// </summary>
        /// <param name="json">JSON span</param>
        /// <param name="position">Current position</param>
        /// <param name="destination">Destination span</param>
        /// <param name="numberOfBytes">Number of characters written</param>
        /// <returns>Result</returns>
        public static JsonResult ParseString(ReadOnlySpan<char> json, ref int position, Span<char> destination, out int numberOfBytes)
        {
            numberOfBytes = 0;

            // Check type
            JsonResult result = CheckType(json, ref position, JsonType.String);
            if (result != JsonResult.Ok)
                return result;

            position++; // Skip opening quote

            // Parse string
            int index = 0;
            while (position < json.Length)
            {
                // if (destination.Length > 0 && index >= destination.Length)
                if (destination.Length > 0 && index > destination.Length)
                    return JsonResult.StringTooLong;

                char ch = json[position];

                if (ch == '\0')
                    return JsonResult.MissingStringEnd;

                if (ch >= 0 && ch < 0x20)
                    return JsonResult.InvalidStringCharacter; // control characters must be escaped

                if (ch == '\\')
                {
                    result = ParseEscapeSequence(json, ref position, destination, ref index);
                    if (result != JsonResult.Ok)
                        return result;
                    continue;
                }

                if (ch == '"')
                {
                    position++;
                    numberOfBytes = index;
                    return JsonResult.Ok;
                }

                WriteToDestination(destination, ref index, ch);
                position++;
            }

            return JsonResult.MissingStringEnd;
        }

        /// <summary>
        /// Parse escape sequence. The position is advanced to the first character after the escape sequence.
        /// </summary>
        /// <param name="json">JSON span</param>
        /// <param name="position">Current position</param>
        /// <param name="destination">Destination span</param>
        /// <param name="index">Current index in destination</param>
        /// <returns>Result</returns>
        private static JsonResult ParseEscapeSequence(ReadOnlySpan<char> json, ref int position, Span<char> destination, ref int index)
        {
            if (position + 1 >= json.Length)
                return JsonResult.InvalidStringEscapeSequence;

            switch (json[position + 1])
            {
                case '"':
                    WriteToDestination(destination, ref index, '"');
                    break;
                case '\\':
                    WriteToDestination(destination, ref index, '\\');
                    break;
                case '/':
                    WriteToDestination(destination, ref index, '/');
                    break;
                case 'b':
                    WriteToDestination(destination, ref index, '\b');
                    break;
                case 'f':
                    WriteToDestination(destination, ref index, '\f');
                    break;
                case 'n':
                    WriteToDestination(destination, ref index, '\n');
                    break;
                case 'r':
                    WriteToDestination(destination, ref index, '\r');
                    break;
                case 't':
                    WriteToDestination(destination, ref index, '\t');
                    break;
                case 'u':
                    return ParseHexEscapeSequence(json, ref position, destination, ref index);
                default:
                    return JsonResult.InvalidStringEscapeSequence;
            }

            position += 2;
            return JsonResult.Ok;
        }

        /// <summary>
        /// Parse hex escape sequence. The position is advanced to the first character after the hex escape sequence.
        /// </summary>
        /// <param name="json">JSON span</param>
        /// <param name="position">Current position</param>
        /// <param name="destination">Destination span</param>
        /// <param name="index">Current index in destination</param>
        /// <returns>Result</returns>
        private static JsonResult ParseHexEscapeSequence(ReadOnlySpan<char> json, ref int position, Span<char> destination, ref int index)
        {
            if (position + 5 >= json.Length)
                return JsonResult.InvalidStringHexEscapeSequence;

            for (int i = 2; i <= 5; i++)
            {
                char ch = json[position + i];
                if (!((ch >= '0' && ch <= '9') || (ch >= 'A' && ch <= 'F') || (ch >= 'a' && ch <= 'f')))
                    return JsonResult.InvalidStringHexEscapeSequence;
            }

            ReadOnlySpan<char> hexSpan = json.Slice(position + 2, 4);
            if (!int.TryParse(hexSpan, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out int value))
                return JsonResult.UnableToParseStringHexEscapeSequence;

            WriteToDestination(destination, ref index, (char)value);
            position += 6;
            return JsonResult.Ok;
        }

        /// <summary>
        /// Writes character to destination and increments index, if destination is not empty.
        /// </summary>
        /// <param name="destination">Destination span</param>
        /// <param name="index">Current index</param>
        /// <param name="character">Character to write</param>
        private static void WriteToDestination(Span<char> destination, ref int index, char character)
        {
            if (!destination.IsEmpty && index < destination.Length)
            {
                destination[index] = character;
            }
            index++;
        }

        /// <summary>
        /// Parses number. The position is advanced to the first character after the number.
        /// </summary>
        /// <param name="json">JSON span</param>
        /// <param name="position">Current position</param>
        /// <param name="number">Parsed number</param>
        /// <returns>Result</returns>
        public static JsonResult ParseNumber(ReadOnlySpan<char> json, ref int position, out float number)
        {
            number = 0;

            // Check type
            JsonResult result = CheckType(json, ref position, JsonType.Number);
            if (result != JsonResult.Ok)
                return result;

            int startPos = position;

            // Parse sign
            if (position < json.Length && json[position] == '-')
            {
                position++;
                if (position >= json.Length || !char.IsDigit(json[position]))
                    return JsonResult.InvalidNumberFormat; // minus sign must be followed by digit
            }

            // Parse first zero
            if (position < json.Length && json[position] == '0')
            {
                position++;
                if (position < json.Length && json[position] == '0')
                    return JsonResult.InvalidNumberFormat; // leading zeros are invalid
            }

            // Parse integer
            while (position < json.Length && char.IsDigit(json[position]))
            {
                position++;
            }

            // Parse fraction
            if (position < json.Length && json[position] == '.')
            {
                position++;
                if (position >= json.Length || !char.IsDigit(json[position]))
                    return JsonResult.InvalidNumberFormat; // decimal point must be followed by digit

                while (position < json.Length && char.IsDigit(json[position]))
                {
                    position++;
                }
            }

            // Parse exponent
            if (position < json.Length && (json[position] == 'e' || json[position] == 'E'))
            {
                position++;
                if (position < json.Length && (json[position] == '+' || json[position] == '-'))
                {
                    position++;
                }
                if (position >= json.Length || !char.IsDigit(json[position]))
                    return JsonResult.InvalidNumberFormat; // exponent must be followed by digit

                while (position < json.Length && char.IsDigit(json[position]))
                {
                    position++;
                }
            }

            // Parse number string
            ReadOnlySpan<char> numberSpan = json.Slice(startPos, position - startPos);
            if (numberSpan.Length >= 32)
                return JsonResult.NumberTooLong;

            if (!float.TryParse(numberSpan, NumberStyles.Float, CultureInfo.InvariantCulture, out number))
                return JsonResult.UnableToParseNumber;

            return JsonResult.Ok;
        }

        /// <summary>
        /// Parses boolean. The position is advanced to the first character after the boolean.
        /// </summary>
        /// <param name="json">JSON span</param>
        /// <param name="position">Current position</param>
        /// <param name="boolean">Parsed boolean value</param>
        /// <returns>Result</returns>
        public static JsonResult ParseBoolean(ReadOnlySpan<char> json, ref int position, out bool boolean)
        {
            boolean = false;

            // Check type
            JsonResult result = CheckType(json, ref position, JsonType.Boolean);
            if (result != JsonResult.Ok)
                return result;

            // Parse true
            ReadOnlySpan<char> trueSpan = "true".AsSpan();
            if (position + trueSpan.Length <= json.Length && 
                json.Slice(position, trueSpan.Length).SequenceEqual(trueSpan))
            {
                position += trueSpan.Length;
                boolean = true;
                return JsonResult.Ok;
            }

            // Parse false
            ReadOnlySpan<char> falseSpan = "false".AsSpan();
            if (position + falseSpan.Length <= json.Length && 
                json.Slice(position, falseSpan.Length).SequenceEqual(falseSpan))
            {
                position += falseSpan.Length;
                boolean = false;
                return JsonResult.Ok;
            }

            return JsonResult.InvalidSyntax;
        }

        /// <summary>
        /// Parses null. The position is advanced to the first character after the null.
        /// </summary>
        /// <param name="json">JSON span</param>
        /// <param name="position">Current position</param>
        /// <returns>Result</returns>
        public static JsonResult ParseNull(ReadOnlySpan<char> json, ref int position)
        {
            // Check type
            JsonResult result = CheckType(json, ref position, JsonType.Null);
            if (result != JsonResult.Ok)
                return result;

            // Parse null
            ReadOnlySpan<char> nullSpan = "null".AsSpan();
            if (position + nullSpan.Length <= json.Length && 
                json.Slice(position, nullSpan.Length).SequenceEqual(nullSpan))
            {
                position += nullSpan.Length;
                return JsonResult.Ok;
            }

            return JsonResult.InvalidSyntax;
        }

        /// <summary>
        /// Parses any JSON and discards data. The position is advanced to the first character after the JSON.
        /// </summary>
        /// <param name="json">JSON span</param>
        /// <param name="position">Current position</param>
        /// <returns>Result</returns>
        public static JsonResult Parse(ReadOnlySpan<char> json, ref int position)
        {
            int indent = 0;
            return ParseValue(json, ref position, false, ref indent);
        }

        /// <summary>
        /// Prints the JSON structure and result message.
        /// </summary>
        /// <param name="json">JSON string</param>
        public static void Print(string json)
        {
            ReadOnlySpan<char> jsonSpan = json.AsSpan();
            int position = 0;
            int indent = 0;
            JsonResult result = ParseValue(jsonSpan, ref position, true, ref indent);
            Console.WriteLine(ResultToString(result));
        }

        /// <summary>
        /// Parses value and optionally prints structure. The position is advanced to the first character after the value.
        /// </summary>
        /// <param name="json">JSON span</param>
        /// <param name="position">Current position</param>
        /// <param name="print">True to print structure</param>
        /// <param name="indent">Current indentation level</param>
        /// <returns>Result</returns>
        private static JsonResult ParseValue(ReadOnlySpan<char> json, ref int position, bool print, ref int indent)
        {
            // Parse value type
            JsonResult result = ParseType(json, ref position, out JsonType type);
            if (result != JsonResult.Ok)
                return result;

            // Print value type
            if (print)
            {
                int actualIndent = 4 * indent;
                string indentStr = new string(' ', actualIndent);
                switch (type)
                {
                    case JsonType.String:
                        Console.WriteLine($"{indentStr}string");
                        break;
                    case JsonType.Number:
                        Console.WriteLine($"{indentStr}number");
                        break;
                    case JsonType.Object:
                        Console.WriteLine($"{indentStr}object");
                        break;
                    case JsonType.Array:
                        Console.WriteLine($"{indentStr}array");
                        break;
                    case JsonType.Boolean:
                        Console.WriteLine($"{indentStr}boolean");
                        break;
                    case JsonType.Null:
                        Console.WriteLine($"{indentStr}null");
                        break;
                }
            }

            // Parse value
            switch (type)
            {
                case JsonType.String:
                    return ParseString(json, ref position, Span<char>.Empty, out _);
                case JsonType.Number:
                    return ParseNumber(json, ref position, out _);
                case JsonType.Object:
                    return ParseObject(json, ref position, print, ref indent);
                case JsonType.Array:
                    return ParseArray(json, ref position, print, ref indent);
                case JsonType.Boolean:
                    return ParseBoolean(json, ref position, out _);
                case JsonType.Null:
                    return ParseNull(json, ref position);
            }

            return JsonResult.Ok;
        }

        /// <summary>
        /// Parses object and discards data. The position is advanced to the first character after the object.
        /// </summary>
        /// <param name="json">JSON span</param>
        /// <param name="position">Current position</param>
        /// <param name="print">True to print structure</param>
        /// <param name="indent">Current indentation level</param>
        /// <returns>Result</returns>
        private static JsonResult ParseObject(ReadOnlySpan<char> json, ref int position, bool print, ref int indent)
        {
            // Parse object start
            JsonResult result = ParseObjectStart(json, ref position);
            if (result != JsonResult.Ok)
                return result;

            // Parse object end (empty object)
            result = ParseObjectEnd(json, ref position);
            if (result == JsonResult.Ok)
                return JsonResult.Ok;

            // Loop through each key/value pair
            indent++;
            while (true)
            {
                // Parse key
                Span<char> key = stackalloc char[64];
                result = ParseKey(json, ref position, key, out _);
                if (result != JsonResult.Ok)
                    return result;

                // Parse value
                result = ParseValue(json, ref position, print, ref indent);
                if (result != JsonResult.Ok)
                    return result;

                // Parse comma
                result = ParseComma(json, ref position);
                if (result == JsonResult.Ok)
                    continue;

                // Parse object end
                result = ParseObjectEnd(json, ref position);
                if (result != JsonResult.Ok)
                    return result;
                break;
            }
            indent--;
            return JsonResult.Ok;
        }

        /// <summary>
        /// Parses array and discards data. The position is advanced to the first character after the array.
        /// </summary>
        /// <param name="json">JSON span</param>
        /// <param name="position">Current position</param>
        /// <param name="print">True to print structure</param>
        /// <param name="indent">Current indentation level</param>
        /// <returns>Result</returns>
        private static JsonResult ParseArray(ReadOnlySpan<char> json, ref int position, bool print, ref int indent)
        {
            // Parse array start
            JsonResult result = ParseArrayStart(json, ref position);
            if (result != JsonResult.Ok)
                return result;

            // Parse array end (empty array)
            result = ParseArrayEnd(json, ref position);
            if (result == JsonResult.Ok)
                return JsonResult.Ok;

            // Loop through each value
            indent++;
            while (true)
            {
                // Parse value
                result = ParseValue(json, ref position, print, ref indent);
                if (result != JsonResult.Ok)
                    return result;

                // Parse comma
                result = ParseComma(json, ref position);
                if (result == JsonResult.Ok)
                    continue;

                // Parse array end
                result = ParseArrayEnd(json, ref position);
                if (result != JsonResult.Ok)
                    return result;
                break;
            }
            indent--;
            return JsonResult.Ok;
        }

        /// <summary>
        /// Returns the result message.
        /// </summary>
        /// <param name="result">Result code</param>
        /// <returns>Result message</returns>
        public static string ResultToString(JsonResult result)
        {
            return result switch
            {
                JsonResult.Ok => "OK",
                JsonResult.InvalidSyntax => "Invalid syntax",
                JsonResult.UnexpectedType => "Unexpected type",
                JsonResult.MissingObjectEnd => "Missing object end",
                JsonResult.MissingArrayEnd => "Missing array end",
                JsonResult.MissingComma => "Missing comma",
                JsonResult.MissingKey => "Missing key",
                JsonResult.MissingColon => "Missing colon",
                JsonResult.MissingStringEnd => "Missing string end",
                JsonResult.StringTooLong => "String too long",
                JsonResult.InvalidStringCharacter => "Invalid string character",
                JsonResult.InvalidStringEscapeSequence => "Invalid string escape sequence",
                JsonResult.InvalidStringHexEscapeSequence => "Invalid string hex escape sequence",
                JsonResult.UnableToParseStringHexEscapeSequence => "Unable to parse string hex escape sequence",
                JsonResult.InvalidNumberFormat => "Invalid number format",
                JsonResult.NumberTooLong => "Number too long",
                JsonResult.UnableToParseNumber => "Unable to parse number",
                _ => ""
            };
        }

        // Helper method for parsing arrays of numbers into spans
        /// <summary>
        /// Parses a JSON array of numbers into a span. Returns the number of elements parsed.
        /// </summary>
        /// <param name="json">JSON span</param>
        /// <param name="position">Current position</param>
        /// <param name="destination">Destination span for parsed numbers</param>
        /// <param name="count">Number of elements parsed</param>
        /// <returns>Result</returns>
        public static JsonResult ParseNumberArray(ReadOnlySpan<char> json, ref int position, Span<float> destination, out int count)
        {
            count = 0;
            
            if (ParseArrayStart(json, ref position) != JsonResult.Ok)
                return JsonResult.InvalidSyntax;
                
            // Check for empty array
            int savedPos = position;
            if (ParseArrayEnd(json, ref savedPos) == JsonResult.Ok)
            {
                position = savedPos;
                return JsonResult.Ok;
            }
            
            // Parse elements
            while (count < destination.Length)
            {
                if (ParseNumber(json, ref position, out float number) != JsonResult.Ok)
                    return JsonResult.InvalidSyntax;
                    
                destination[count] = number;
                count++;
                
                // Try comma or array end
                savedPos = position;
                if (ParseComma(json, ref savedPos) == JsonResult.Ok)
                {
                    position = savedPos;
                    continue;
                }
                
                if (ParseArrayEnd(json, ref savedPos) == JsonResult.Ok)
                {
                    position = savedPos;
                    return JsonResult.Ok;
                }
                
                return JsonResult.InvalidSyntax;
            }
            
            return JsonResult.Ok;
        }
    }
}
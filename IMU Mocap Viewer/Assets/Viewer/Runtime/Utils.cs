namespace Viewer.Runtime
{
    static class Utils
    {
        public static float ClampAngle(float angle)
        {
            switch (angle)
            {
                case < 0f:
                    angle = 360f - -angle % 360f;
                    break;
                case > 360f:
                    angle %= 360f;
                    break;
            }

            return angle;
        }

        public static bool ConsumeFlag(ref bool flag)
        {
            if (flag == false) return false;

            flag = false;

            return true;
        }
    }
}
namespace Viewer.Runtime.Primitives
{
    public interface ILabelGroup
    {
        bool Visible { get; set; }

        Label Get();

        void Clear();
    }
}
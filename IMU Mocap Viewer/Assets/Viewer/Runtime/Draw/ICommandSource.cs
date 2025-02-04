using UnityEngine.Rendering;

namespace Viewer.Runtime.Draw
{
    public interface ICommandSource
    {
        int Order { get; }

        void PopulateCommands(RasterCommandBuffer buffer);
    }
}
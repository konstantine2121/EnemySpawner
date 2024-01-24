using UnityEngine;

namespace Assets.Sources
{
    public interface IPositionProvider
    {
        Vector3 Position { get; }
    }
}

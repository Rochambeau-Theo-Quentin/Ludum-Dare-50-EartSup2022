using UnityEngine;

namespace NazioToolKit
{
    public static class NPixelPerfect
    {
        public const int referenceResolution = 32;

        public static Vector3 GetPixeledVector(Vector3 _position)
        {
            Vector3 _intVector = new Vector3((int)_position.x, (int)_position.y);

            Vector2Int _rest = new Vector2Int((int)((_position.x - _intVector.x) * referenceResolution), (int)((_position.y - _intVector.y) * referenceResolution));
            Vector2 _restPixeled = PixelToVector2(_rest);

            return new Vector3(_intVector.x + _restPixeled.x, _intVector.y + _restPixeled.y, _position.z);
        }

        public static Vector2 PixelToVector2(Vector2Int _pixels)
        {
            return new Vector2(_pixels.x / (float)referenceResolution, _pixels.y / (float)referenceResolution);
        }
    }
}
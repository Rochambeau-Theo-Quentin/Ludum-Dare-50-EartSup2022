using UnityEngine;

namespace NazioToolKit
{
    public class NCalculs
    {
        /// <summary>
        /// Determine une coordonné peut etre utilisé dans un tableau.
        /// </summary>
        /// <param name="_pos"></param>
        /// <param name="_bounds"></param>
        /// <returns></returns>
        public static bool InBound(Vector2Int _pos, Vector2Int _bounds)
        {
            if (_pos.x >= _bounds.x || _pos.x < 0 || _pos.y >= _bounds.y || _pos.y < 0) return false;

            return true;
        }

        public static float Angle(Vector2 vector2)
        {
            if (vector2.x < 0)
            {
                return 360 - (Mathf.Atan2(vector2.x, vector2.y) * Mathf.Rad2Deg * -1);
            }
            else
            {
                return Mathf.Atan2(vector2.x, vector2.y) * Mathf.Rad2Deg;
            }
        }

        /// <summary>
        /// Si la valeur est >0 alors retourne 1, si <0 retourne -1, sinon retourne 0.
        /// </summary>
        /// <param name="_value">Valeur utilisé pour les calculs.</param>
        /// <returns></returns>
        public static int SimplifySigne(float _value)
        {
            if (_value > 0) return 1;
            if (_value < 0) return -1;

            return 0;
        }

        /// <summary>
        /// Retourne le vector en enlevant l'axe le plus petit. Si X et Y sont egaux, il retourne le vecteur de base.
        /// </summary>
        /// <param name="_vector">Vecteur sur lequel se base la fonction.</param>
        /// <returns></returns>
        public static Vector2 KeepGreaterAxis(Vector2 _vector)
        {
            if (_vector.x > _vector.y) return new Vector2(_vector.x, 0);
            if (_vector.x < _vector.y) return new Vector2(0, _vector.y);

            return _vector;
        }

        /// <summary>
        /// Retourne le vector en enlevant l'axe le plus petit. Si X et Y sont egaux, il retourne _returnVector
        /// </summary>
        /// <param name="_vector">Vecteur sur lequel se base la fonction.</param>
        /// <param name="_returnVector">Vecteur retourné si les valeurs des axes sont égaux.</param>
        /// <returns></returns>
        public static Vector2 KeepGreaterAxis(Vector2 _vector, Vector2 _returnVector)
        {
            if (_vector.x > _vector.y) return new Vector2(_vector.x, 0);
            if (_vector.x < _vector.y) return new Vector2(0, _vector.y);

            return _returnVector;
        }

        /// <summary>
        /// Retourne le vector en enlevant l'axe le plus petit en valeur absolue. Si X et Y sont egaux, il retourne le vecteur de base.
        /// </summary>
        /// <param name="_vector">Vecteur sur lequel se base la fonction.</param>
        /// <param name="_returnVector">Vecteur retourné si les valeurs des axes sont égaux.</param>
        /// <returns></returns>
        public static Vector2 KeepAbsoluteGreaterAxis(Vector2 _vector)
        {
            if (Mathf.Abs(_vector.x) > Mathf.Abs(_vector.y)) return new Vector2(_vector.x, 0);
            if (Mathf.Abs(_vector.x) < Mathf.Abs(_vector.y)) return new Vector2(0, _vector.y);

            return _vector;
        }

        /// <summary>
        /// Retourne le vector en enlevant l'axe le plus petit en valeur absolue. Si X et Y sont egaux, il retourne _returnVector
        /// </summary>
        /// <param name="_vector">Vecteur sur lequel se base la fonction.</param>
        /// <param name="_returnVector">Vecteur retourné si les valeurs des axes sont égaux.</param>
        /// <returns></returns>
        public static Vector2 KeepAbsoluteGreaterAxis(Vector2 _vector, Vector2 _returnVector)
        {
            if (Mathf.Abs(_vector.x) > Mathf.Abs(_vector.y)) return new Vector2(_vector.x, 0);
            if (Mathf.Abs(_vector.x) < Mathf.Abs(_vector.y)) return new Vector2(0, _vector.y);

            return _returnVector;
        }


        public static Quaternion GetQuatWithVector(Vector2 _direction)
        {
            if (_direction == Vector2.left) return Quaternion.Euler(0, 0, 180);
            if (_direction == Vector2.up) return Quaternion.Euler(0, 0, -90);
            if (_direction == Vector2.down) return Quaternion.Euler(0, 0, 90);

            return Quaternion.identity;
        }
    }
}
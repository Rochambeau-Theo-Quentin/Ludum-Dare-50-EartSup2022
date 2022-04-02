using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace NazioToolKit
{
    public static class NUtils
    {
        /// <summary>
        /// Transforme un vecteur en couleur
        /// </summary>
        /// <param name="_vector">Vecteur3 dont chaque axe est positif et <=1.</param>
        /// <returns>Couleur</returns>
        public static Color GetColorWithVector(Vector3 _vector)
        {
            return new Color(_vector.x, _vector.y, _vector.z);
        }

        /// <summary>
        /// Transforme un vecteur en couleur
        /// </summary>
        /// <param name="_vector">Vecteur4 dont chaque axe est positif et <=1.</param>
        /// <returns>Couleur</returns>
        public static Color GetColorWithVector(Vector4 _vector)
        {
            return new Color(_vector.x, _vector.y, _vector.z, _vector.w);
        }
    }
}


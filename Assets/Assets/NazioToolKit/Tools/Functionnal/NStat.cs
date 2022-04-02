using UnityEngine;

namespace NazioToolKit
{
    [System.Serializable]
    public class NStat
    {
        private float current;
        [SerializeField] private float max;
        [Range(0f, 15f), SerializeField] private float regen;

        #region Setters

        public void Regen()
        {
            Modify(regen * Time.deltaTime);
        }

        public void Init(float _maxValue)
        {
            max = _maxValue;
            current = max;
        }

        public void Modify(float _modifier)
        {
            current += _modifier;

            if (current > max) current = max;
        }

        public void SetMax(float _max)
        {
            max = _max;
        }

        public void Set(float _life)
        {
            current = _life;
        }

        #endregion

        #region Getters

        public float Current()
        {
            return current;
        }

        public float Max()
        {
            return max;
        }

        public float Percent()
        {
            return current / max;
        }

        #endregion
    }
}


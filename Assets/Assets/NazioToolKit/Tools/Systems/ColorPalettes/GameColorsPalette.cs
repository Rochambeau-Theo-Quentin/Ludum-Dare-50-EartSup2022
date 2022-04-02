using UnityEngine;

namespace NazioToolKit
{
    public enum PaletteType
    {
        Double,
        Simple,
        InverseSimple,
    }

    [System.Serializable]
    public class GameColorsPalette
    {
        public string name;
        public Color mainColor;
        [SerializeField] private PaletteType type;
        private Color modifier = new Color(0.1f, 0.1f, 0.1f, 1f);

        public Color[] palette { private set; get; } = new Color[9];//{ private set; get; }

        //

        public void Actualise(float _influence, int _number)
        {
            switch (type)
            {
                case PaletteType.Double:
                    BasicPalette(_influence, _number);
                    break;
                case PaletteType.Simple:
                    InverseBasicPalette(_influence, _number, 1);
                    break;
                case PaletteType.InverseSimple:
                    InverseBasicPalette(_influence, _number, -1);
                    break;
            }

        }

        private void BasicPalette(float _influence, int _number)
        {
            palette = new Color[2 * _number + 1];
            modifier = new Color(_influence / _number, _influence / _number, _influence / _number, 1f);

            for (var i = -_number; i <= _number; i++)
            {
                palette[i + _number] = mainColor + modifier * i;
                palette[i + _number].a = 1f;
            }
        }

        private void InverseBasicPalette(float _influence, int _number, int _factor)
        {
            palette = new Color[2 * _number + 1];
            modifier = new Color(_influence / _number / 2, _influence / _number / 2, _influence / _number / 2, 1f);

            for (var i = 0; i <= 2 * _number; i++)
            {
                palette[i] = mainColor + modifier * i * _factor;
                palette[i].a = 1f;
            }
        }

        public Color GetColor(int _ID)
        {
            _ID = Mathf.Clamp(_ID, 0, palette.Length - 1);
            return palette[_ID];
        }
    }
}
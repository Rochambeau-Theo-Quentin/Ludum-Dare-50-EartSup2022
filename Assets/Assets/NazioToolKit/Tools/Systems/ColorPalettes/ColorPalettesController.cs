using UnityEngine;

namespace NazioToolKit
{
    public class ColorPalettesController : MonoBehaviour
    {
        public static ColorPalettesController instance { private set; get; }

        [SerializeField] private GameColorsPalette[] palettes;

        [Header("Parametters")]
        [SerializeField, Range(0f, 1f)] private float varianceInfluence = 0.1f;
        [SerializeField] private int varianceNumbers = 9;

        private void Awake()
        {
            if (instance != null)
            {
                Destroy(this);
                return;
            }
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        private void OnValidate()
        {
            if (palettes == null) return;

            foreach (var _palette in palettes)
            {
                _palette.Actualise(varianceInfluence, varianceNumbers);
            }
        }

        #region StaticMethods

        public static GameColorsPalette GetPaletteByName(string _name)
        {
            return instance.SGetPaletteByName(_name);
        }


        public static Color GetRandomColorInPalette(int _randomForce, GameColorsPalette _palette)
        {
            if(_palette == null) return new Color(0,0,0,0);

            return _palette.GetColor(Mathf.Clamp(Random.Range(_palette.palette.Length / 2 - _randomForce, _palette.palette.Length / 2 + _randomForce), 0, _palette.palette.Length));
        }

        #endregion

        private GameColorsPalette SGetPaletteByName(string _name)
        {
            if (palettes == null) return null;

            foreach (var _palette in palettes)
            {
                if (_palette.name == _name) return _palette;
            }

            return null;
        }
    }
}
using UnityEngine;
using UnityEngine.UI;

namespace Nazio_LT
{
    public class FolderWindow : Window
    {
        [SerializeField] private Sprite[] baseImages;
        [SerializeField] private Sprite[] cursedImages;

        private Image[] iconsToChange;

        private bool cursed;

        public void SetCursed(bool _cursed)
        {
            cursed = _cursed;

            ChangeSprite(cursed ? cursedImages : baseImages);
        }   

        private void ChangeSprite(Sprite[] _sprites)
        {
            for (var i = 0; i < iconsToChange.Length; i++)
            {
                iconsToChange[i].sprite = _sprites[i];
            }
        }
    }
}
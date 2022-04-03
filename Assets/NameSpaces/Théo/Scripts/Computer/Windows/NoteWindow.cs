using TMPro;

namespace Nazio_LT
{
    public class NoteWindow : Window
    {
        private TMP_InputField texts;
        private NotePad pad;

        public override void Init(int _id, OpenIcon _icon, string _path)
        {
            base.Init(_id, _icon, _path);

            SetText();
        }

        public void SetText()
        {
            texts = GetComponentInChildren<TMP_InputField>();
            pad = GetComponent<NotePad>();

            texts.text = pad.GetText();
        }
    }
}
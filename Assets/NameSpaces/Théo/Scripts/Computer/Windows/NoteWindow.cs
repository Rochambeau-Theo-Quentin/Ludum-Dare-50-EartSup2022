using TMPro;

namespace Nazio_LT
{
    public class NoteWindow : Window
    {
        private TMP_InputField texts;

        public void SetText(string _text)
        {
            texts = GetComponentInChildren<TMP_InputField>();

            texts.text = _text;
        }
    }
}
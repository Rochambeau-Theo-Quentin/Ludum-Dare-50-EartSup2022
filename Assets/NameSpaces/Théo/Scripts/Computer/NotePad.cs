using UnityEngine;

namespace Nazio_LT
{
    public class NotePad : MonoBehaviour
    {
        [SerializeField, TextArea(5, 5)] private string savedText;

        public string GetText() { return savedText; }
    }
}
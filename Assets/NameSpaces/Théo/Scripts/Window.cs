using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Nazio_LT
{
    public class Window : MonoBehaviour
    {
        private bool state;
        private int id;

        private CanvasGroup canvasGroup;
        private Canvas canvas;
        private ComputerController computer;
        private OpenIcon icon;

        public void Init(int _id, OpenIcon _icon)
        {
            state = true;
            id = _id;

            icon = _icon;

            canvasGroup = GetComponent<CanvasGroup>();
            canvas = GetComponent<Canvas>();
        }

        public void ChangeState(bool _state)
        {
            state = _state;
            DispWindow();
        }
        public void ChangeState()
        {
            state = !state;
            DispWindow();
        }

        public void Close()
        {
            Destroy(icon.gameObject);
            Destroy(this.gameObject);
        }

        private void DispWindow()
        {
            canvas.enabled = state ? true : false;
            canvasGroup.alpha = state ? 1f : 0f;
        }

        public void SetID(int _id) { id = _id; }
    }
}
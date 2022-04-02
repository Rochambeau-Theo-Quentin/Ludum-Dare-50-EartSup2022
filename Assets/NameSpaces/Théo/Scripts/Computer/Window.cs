using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Nazio_LT
{
    public class Window : MonoBehaviour, IDragHandler
    {
        private bool state;
        private int id;

        private CanvasGroup canvasGroup;
        public Canvas canvas { private set; get; }
        private ComputerController computer;
        private OpenIcon icon;

        #region ImplementedMethods

        public void OnDrag(PointerEventData _eventData)
        {
            computer.SetFirstPlanWindow(this);

            RectTransform _bar = (RectTransform)transform.GetChild(0);
            RectTransform _transform = (RectTransform)transform;

            Vector2 _mousePos = _eventData.position;

            transform.position = _mousePos - Vector2.up * _transform.sizeDelta.y / 2;

            if (_mousePos.x > Screen.width) transform.position = new Vector2(Screen.width - 1, transform.position.y);
            else if (_mousePos.x < 0) transform.position = new Vector2(1, transform.position.y);

            if (_mousePos.y > Screen.height) transform.position = new Vector2(transform.position.x, Screen.height - 1);
            else if (_mousePos.y < 0) transform.position = new Vector2(transform.position.x, 1);
        }

        #endregion

        #region MainMethods

        public void Init(int _id, OpenIcon _icon)
        {
            state = true;
            id = _id;

            icon = _icon;

            canvasGroup = GetComponent<CanvasGroup>();
            canvas = GetComponent<Canvas>();
            computer = FindObjectOfType<ComputerController>();
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

        #endregion

        #region Setters

        public void SetID(int _id) { id = _id; }

        #endregion
    }
}
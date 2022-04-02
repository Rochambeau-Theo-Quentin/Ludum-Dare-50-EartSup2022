using System.Collections;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Nazio_LT
{
    public class Window : MonoBehaviour, IDragHandler
    {
        protected string path;

        public bool state { private set; get; }
        private int id;
        private Vector2 originalSize;

        private const float ANIMTIME = 0.25f;

        private CanvasGroup canvasGroup;
        public Canvas canvas { private set; get; }
        protected ComputerController computer;
        private OpenIcon icon;

        public void OnDrag(PointerEventData _eventData)
        {
            RectTransform _bar = (RectTransform)transform.GetChild(0);
            RectTransform _transform = (RectTransform)transform;

            Vector2 _mousePos = _eventData.position;

            transform.position = _mousePos - Vector2.up * _transform.sizeDelta.y / 2;

            if (_mousePos.x > Screen.width) transform.position = new Vector2(Screen.width - 1, transform.position.y);
            else if (_mousePos.x < 0) transform.position = new Vector2(1, transform.position.y);

            if (_mousePos.y > Screen.height) transform.position = new Vector2(transform.position.x, Screen.height - 1);
            else if (_mousePos.y < 0) transform.position = new Vector2(transform.position.x, 1);

            computer.SetFirstPlanWindow(this);
        }

        #region MainMethods

        public virtual void Init(int _id, OpenIcon _icon, string _path)
        {
            id = _id;
            path = _path;

            icon = _icon;

            canvasGroup = GetComponent<CanvasGroup>();
            canvas = GetComponent<Canvas>();

            originalSize = ((RectTransform)transform).sizeDelta;
            computer = FindObjectOfType<ComputerController>();
            ChangeState();
        }

        public virtual void ChangeState()
        {
            state = !state;
            StartCoroutine(ChangingStateAnimation(false, state));

            if(state) computer.SetFirstPlanWindow(this);
        }

        public virtual void Close()
        {
            StartCoroutine(ChangingStateAnimation(true, false));
        }

        private IEnumerator ChangingStateAnimation(bool _close, bool _state)
        {
            canvas.enabled = true;
            RectTransform _rect = (RectTransform)transform;

            Func<float, float> alphaMethod = _flt => _state ? Mathf.Lerp(0, 1, _flt / ANIMTIME) : Mathf.Lerp(1, 0, _flt / ANIMTIME);
            Func<float, Vector2> sizeMethod = _flt => _state ? Vector2.Lerp(Vector2.zero, originalSize, _flt / ANIMTIME) : Vector2.Lerp(originalSize, Vector2.zero, _flt / ANIMTIME);

            float _t = 0;

            while (true)
            {
                yield return null;

                _t += Time.deltaTime;

                canvasGroup.alpha = alphaMethod.Invoke(_t);
                _rect.sizeDelta = sizeMethod.Invoke(_t);

                if (_t > ANIMTIME)
                {
                    canvasGroup.alpha = state ? 1 : 0;
                    break;
                }
            }

            canvas.enabled = _state;

            if (_close)
            {
                Destroy(icon.gameObject);
                Destroy(this.gameObject);
            }
        }

        #endregion

        #region Setters

        public void SetID(int _id) { id = _id; }

        #endregion
    }
}
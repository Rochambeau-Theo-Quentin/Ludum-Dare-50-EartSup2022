using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NazioToolKit
{
    public class CreditsController : MonoBehaviour
    {

        [SerializeField] private RectTransform creditAnchorTransform;
        private RectTransform creditTransform;

        [SerializeField] private float duration;
        private float height;
        private Vector3 target;

        private MenuController mainMenu;

        private void Awake()
        {
            creditTransform = (RectTransform)creditAnchorTransform.GetChild(0);
            mainMenu = GetComponentInParent<MenuController>();
        }

        public void Launch()
        {
            creditAnchorTransform.anchoredPosition = Vector3.zero;
            height = creditTransform.sizeDelta.y + Screen.height;

            StartCoroutine(CreditAnimation());
        }

        private IEnumerator CreditAnimation()
        {
            float _t = 0;
            while (true)
            {
                yield return null;
                _t += Time.deltaTime;

                creditAnchorTransform.anchoredPosition = (_t / duration) * height * Vector3.up;

                if (_t > duration) break;
            }

            mainMenu.Credits(false);
        }
    }
}

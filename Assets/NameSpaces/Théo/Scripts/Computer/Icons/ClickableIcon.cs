using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Nazio_LT
{
    public abstract class ClickableIcon : MonoBehaviour
    {
        [SerializeField] protected string path;

        [SerializeField] protected WindowType type;

        protected ComputerController computer;
        protected Window linkedWindow;
        private Image iconImage;

        private void Awake()
        {
            computer = FindObjectOfType<ComputerController>();
            iconImage = GetComponent<Image>();
        }

        public void Init(Window _link, WindowType _type)
        {
            linkedWindow = _link;
            type = _type;
            iconImage.sprite = GameManager.instance.GetIcon(_type);
        }

        public abstract void Click();
    }
}
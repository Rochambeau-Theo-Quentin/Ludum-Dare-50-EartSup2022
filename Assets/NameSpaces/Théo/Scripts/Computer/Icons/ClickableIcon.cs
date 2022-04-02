using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Nazio_LT
{
    public abstract class ClickableIcon : MonoBehaviour
    {
        [SerializeField] protected string path;

        [SerializeField] protected WindowType type;

        protected ComputerController computer;
        protected Window linkedWindow;

        private void Awake()
        {
            computer = FindObjectOfType<ComputerController>();
        }

        public void Init(Window _link, WindowType _type)
        {
            linkedWindow = _link;
            type = _type;
        }

        public abstract void Click();
    }
}
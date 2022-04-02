using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Nazio_LT
{
    public class Window : MonoBehaviour
    {
        private bool state;
        private int id;

        public void Init(int _id)
        {
            state = true;
            id = _id;
        }

        public void ChangeState(bool _state) { state = _state; }
        public void ChangeState() { state = !state; }
    }
}
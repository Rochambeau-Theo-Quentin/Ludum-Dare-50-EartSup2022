using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Nazio_LT
{
    public enum WindowType
    {
        Folder = 0,
    }

    public class ComputerController : MonoBehaviour
    {
        private List<Window> openedWindows = new List<Window>();
        [SerializeField] private List<Transform> windowsPrefabs = new List<Transform>();

        public Window CreateWindow(WindowType _type)
        {
            Window _win = Instantiate(windowsPrefabs[((int)_type)]).GetComponent<Window>();
            openedWindows.Add(_win);
            _win.Init(openedWindows.Count - 1);

            return _win;
        }
    }
}
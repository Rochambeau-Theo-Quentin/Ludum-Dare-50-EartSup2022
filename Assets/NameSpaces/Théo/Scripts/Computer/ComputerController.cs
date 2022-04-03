using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Nazio_LT
{
    public enum WindowType
    {
        Template = 0,
        CMD = 1,
        CloseCMD = 2,
        ReadMe = 3,
        Gogol = 4,
        Folder = 5,
    }

    public class ComputerController : MonoBehaviour
    {
        private bool cmdOpen;
        [SerializeField] private bool canDrag = true;

        private List<Window> openedWindows = new List<Window>();

        [Header("Prefabs")]
        [SerializeField] private List<Transform> windowsPrefabs = new List<Transform>();
        [SerializeField] private Transform iconPrefab;

        [Header("Refs")]
        [SerializeField] private Transform bar;
        private PathController path;

        private void Awake()
        {
            path = FindObjectOfType<PathController>();
        }

        public Window CreateWindow(WindowType _type, string _path)
        {
            if(cmdOpen && _type == WindowType.CMD) return null;

            Window _win = Instantiate(windowsPrefabs[((int)_type)], transform.position, Quaternion.identity, transform).GetComponent<Window>();
            openedWindows.Add(_win);

            OpenIcon _icon = Instantiate(iconPrefab, Vector3.zero, Quaternion.identity, bar).GetComponent<OpenIcon>();
            _icon.Init(_win, _type);

            _win.Init(openedWindows.Count - 1, _icon, _path);

            if(_type == WindowType.CMD) cmdOpen = true;

            return _win;
        }

        public void SetFirstPlanWindow(Window _window)
        {
            foreach (var windows in openedWindows)
            {
                if(windows != null) windows.canvas.sortingOrder = 10;
            }

            _window.canvas.sortingOrder = 50;
        }

        public bool CanDrag()
        {
            return canDrag;
        } 
    }
}
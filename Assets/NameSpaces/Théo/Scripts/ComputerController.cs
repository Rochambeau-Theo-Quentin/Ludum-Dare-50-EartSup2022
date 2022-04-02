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

        [Header("Prefabs")]
        [SerializeField] private List<Transform> windowsPrefabs = new List<Transform>();
        [SerializeField] private Transform iconPrefab;

        [Header("Refs")]
        [SerializeField] private Transform bar;

        public Window CreateWindow(WindowType _type)
        {
            Window _win = Instantiate(windowsPrefabs[((int)_type)], transform.position, Quaternion.identity, transform).GetComponent<Window>();
            openedWindows.Add(_win);

            OpenIcon _icon = Instantiate(iconPrefab, Vector3.zero, Quaternion.identity, bar).GetComponent<OpenIcon>();
            _icon.Init(_win, _type);

            _win.Init(openedWindows.Count - 1, _icon);

            return _win;
        }

        public void CloseWindow(int _id)
        {

        }
    }
}
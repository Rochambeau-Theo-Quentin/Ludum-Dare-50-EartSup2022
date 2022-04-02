using UnityEngine;
using UnityEditor;

namespace NazioToolKit.Systems.Menu
{
    [CustomEditor(typeof(MenuController))]
    public class MenuControllerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.DrawDefaultInspector();

            MenuController _script = (MenuController)target;

        }
    }
}



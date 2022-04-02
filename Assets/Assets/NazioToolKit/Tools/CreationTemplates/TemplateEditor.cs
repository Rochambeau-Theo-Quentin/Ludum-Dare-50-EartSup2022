#if UNITY_EDITOR
using UnityEditor;

namespace NazioToolKit
{
    public class TemplateEditor : Editor
    {
        private const string path = "Assets/Assets/NazioToolKit/CreationTemplates/Utils/";

        private const string SingleTon = "SingleTon.cs.txt";

        [MenuItem(itemName: "Assets/Create/Nazio Tools/Utils/Singleton", isValidateFunction: false, priority = 50)]
        public static void CreateSingleTonFromTemplate()
        {
            ProjectWindowUtil.CreateScriptAssetFromTemplateFile(path + SingleTon, "Singleton.cs");
        }

        private const string ScriptableObject = "ScriptableObject.cs.txt";

        [MenuItem(itemName: "Assets/Create/Nazio Tools/Utils/ScriptableObject", isValidateFunction: false, priority = 50)]
        public static void CreateScriptableObjectFromTemplate()
        {
            ProjectWindowUtil.CreateScriptAssetFromTemplateFile(path + ScriptableObject, "ScriptableObject.cs");
        }

        private const string Editor = "Editor.cs.txt";

        [MenuItem(itemName: "Assets/Create/Nazio Tools/Utils/Editor", isValidateFunction: false, priority = 50)]
        public static void CreateEditorFromTemplate()
        {
            ProjectWindowUtil.CreateScriptAssetFromTemplateFile(path + Editor, "Editor.cs");
        }

    }
}
#endif
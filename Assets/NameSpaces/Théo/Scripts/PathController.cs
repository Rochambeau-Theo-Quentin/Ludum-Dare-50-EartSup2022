using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Nazio_LT
{
    public class PathController : MonoBehaviour
    {
        private Dictionary<string, WindowType> paths = new Dictionary<string, WindowType>();

        private ComputerController computer;

        public WindowType GetWindowWithPath(string _path) { return paths[_path]; }

        private void Start()
        {
            computer = FindObjectOfType<ComputerController>();

            RegisterPaths();

            if(SceneManager.GetActiveScene().name == "Jeu") Command("Open " + "cmd.exe");
        }

        private void RegisterPaths()
        {
            paths.Add("cmd.exe", WindowType.CMD);
            paths.Add("desktop/Read_Me.txt", WindowType.ReadMe);
            paths.Add("alertCloseCMD.exe", WindowType.CloseCMD);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_command"></param>
        /// <returns>Error</returns>
        public string Command(string _command)
        {
            if (_command.Contains("Open")) return OpenPath(_command);

            return "Command doesn't exist.";
        }

        private string OpenPath(string _command)
        {
            string[] _cmdParts = _command.Split(' ');
            if (_cmdParts[0] == "Open" && paths.ContainsKey(_cmdParts[1]))
            {
                if (computer.CreateWindow(paths[_cmdParts[1]], _cmdParts[1]) != null) return "Opening window : " + _cmdParts[1];
                return "Cannot Open second cmd.";

            }
            return "Path doesn't exist.";
        }
    }
}
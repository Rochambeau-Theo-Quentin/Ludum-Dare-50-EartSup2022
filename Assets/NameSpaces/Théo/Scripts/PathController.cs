using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

            print(Command("Open " + "cmd.exe"));
        }

        private void RegisterPaths()
        {
            paths.Add("cmd.exe", WindowType.CMD);
            paths.Add("notePad.exe", WindowType.NotePad);
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
                computer.CreateWindow(paths[_cmdParts[1]], _cmdParts[1]);
                return "Opening window : " + _cmdParts[1];
            }
            else return "Path doesn't exist.";
        }
    }
}
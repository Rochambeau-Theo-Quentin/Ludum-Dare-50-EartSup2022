using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Nazio_LT
{
    public class ClickableIcon : MonoBehaviour
    {
        [SerializeField] private WindowType type;

        private ComputerController computer;
        private Window linkedWindow;

        private void Awake()
        {
            computer = FindObjectOfType<ComputerController>();
        }

        /// <summary>
        /// Va ouvir si a deja une fenetre, sinon va creer. Pour barre des taches.
        /// </summary>
        public void Open()
        {
            if (linkedWindow == null) linkedWindow = computer.CreateWindow(type);

            linkedWindow.ChangeState(true);
        }

        /// <summary>
        /// Va creer. Pour bureau.
        /// </summary>
        public void Create()
        {
            //Instantie lui meme
            //Reset l'objet
            Window _win = computer.CreateWindow(type);
            //link l'ojet a la nouvelle window
        }
    }
}
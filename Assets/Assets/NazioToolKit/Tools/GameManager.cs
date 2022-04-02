using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NazioToolKit
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager instance;
        public static GameManager GetInstance()
        {
            return instance;
        }

        private void Awake()
        {
            if (instance != null)
            {
                Destroy(this);
                return;
            }
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        public static void ChangeScene(string _sceneName)
        {
            SceneManager.LoadScene(_sceneName);
        }

        public static void Quit()
        {
            Application.Quit();
        }
    }
}
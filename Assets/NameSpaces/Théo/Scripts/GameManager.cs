using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Nazio_LT;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { private set; get; }

    [SerializeField] private List<Sprite> icons = new List<Sprite>();

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

    public Sprite GetIcon(WindowType _type)
    {
        return icons[((int)_type)];
    }
}
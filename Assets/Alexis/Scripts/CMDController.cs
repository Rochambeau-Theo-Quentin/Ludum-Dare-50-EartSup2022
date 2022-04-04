using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public enum dialogueState
{
CMD,
Cortana,
Google,
Readme,
Windows
}

public class CMDController : MonoBehaviour  , IPointerEnterHandler, IPointerExitHandler
{
    [Serializable]
    public struct contentDialogue
    {
        public string writtingText;

        [TextArea(5, 5)]
        public List<string> dialogueText;
        
        public contentDialogue(string writtingTxt,  List<string> dialogueTxt) {
            this.writtingText = writtingTxt;
            this.dialogueText = dialogueTxt;
        }
    }

    [Header("Base command")]
    [SerializeField]
    private string baseCommandText;

    [Header("Text of CMD")]
    [SerializeField] private Text textCMD;
    [SerializeField] private GameObject prefabTextCMD;

    private VerticalLayoutGroup verticalLayoutGroup;
    private Scrollbar scrollbar;
    private bool debug;

    public UnityEvent messageIsWritting;

    [Header("Individue")]
    [SerializeField] private Color hackerColor;
    [SerializeField] private Color userColor;
    [SerializeField] private string userName;
    [SerializeField] private string hackerName;

    private string textCMDStack;
    private string currentTextWritting;
    private int indexCommand = 0;
    private int indexWritting = 0;
    private bool canWritting = false;

    [Header("List of dialogue")]
    [SerializeField]
    public List<contentDialogue> myDialogue;

    [SerializeField] private dialogueState dialogueType;
    [SerializeField] private GameObject seePanelDialogue;

    private void Start()
    {
        verticalLayoutGroup = GetComponentInChildren<VerticalLayoutGroup>();
        scrollbar = GetComponentInChildren<Scrollbar>();

        if(dialogueType == dialogueState.Cortana || dialogueType == dialogueState.Google)
         seePanelDialogue.SetActive(false);
    }

    private void Update()
    {
        if(!canWritting)
            return;
        
        Writting();
    }

    private void Writting()
    {
        if (Input.anyKeyDown && !(Input.GetKey(KeyCode.Mouse0) || Input.GetKey(KeyCode.Mouse1)))
        {
            if (indexWritting == myDialogue.Count)
            {
                return;
            }
            
            indexCommand++;

            DebugText($"indexCommand : {indexCommand} > myDialogue[indexWritting].writtingText.Length : {myDialogue[indexWritting].writtingText.Length}");
            if (indexCommand >= myDialogue[indexWritting].writtingText.Length)
            {
                SetTextCommand();
                
                SetTextDialogue();

                indexCommand = 0;
                indexWritting++;

                if (indexWritting == 7)
                {
                    SceneManager.LoadScene("BouquetFinal");
                }
                return;
            }

            currentTextWritting = myDialogue[indexWritting].writtingText.Substring(0, indexCommand);
            textCMD.text = ($"{baseCommandText}{currentTextWritting}");
        }
    }

    private GameObject obj;
    private Text txt;
    void SetTextCommand()
    {
        CreateText();
        textCMD.text = (baseCommandText);
        txt.text = ($"{userName} {myDialogue[indexWritting].writtingText}");
        txt.color = userColor;
        scrollbar.value = 0;
    }

    void SetTextDialogue()
    {
        for (int i = 0; i < myDialogue[indexWritting].dialogueText.Count; i++)
        {

            CreateText();
            txt.text = ($"{hackerName} {myDialogue[indexWritting].dialogueText[i]}");
            txt.color = hackerColor;
        }
        scrollbar.value = 0;
    }


    void CreateText()
    {
        obj = Instantiate(prefabTextCMD, verticalLayoutGroup.transform);
        txt = obj.GetComponentInChildren<Text>();
    }

    //j'ajoute du dialogue lors de la fin de  ma mission 
    public void AddDialogue(string commandeCMD, List<string> dialogues)
    {
        Debug.Log("name : " + commandeCMD);
        contentDialogue newContentDialogue = new CMDController.contentDialogue(commandeCMD, dialogues);
        
        myDialogue.Add(newContentDialogue);
    }
    
    //Que dans GOOGLE ET CORTANA avoir pour l'abstract
    public void OnPointerEnter(PointerEventData eventData)
    {
        DebugText("Je rentre dans : " + name);
        
        if (dialogueType == dialogueState.Cortana|| dialogueType == dialogueState.Google)
        {
            seePanelDialogue.SetActive(true);
        }
        DebugText(" canWritting  : " + canWritting);
        canWritting = true;
    }
    
    public void OnPointerExit(PointerEventData eventData)
    {
        DebugText("Je sors de : " + name);
        
        if (dialogueType == dialogueState.Cortana || dialogueType == dialogueState.Google)
        {
            seePanelDialogue.SetActive(false);
        }
        
        canWritting = false;
    }

    public void DebugText(string _string)
    {
        if(!debug) return;
        Debug.Log(_string);
    }

    public dialogueState GetState()
    {
        return dialogueType; 
    }
}

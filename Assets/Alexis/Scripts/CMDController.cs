using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class CMDController : MonoBehaviour
{
    [Header("Base command")]
    [SerializeField]
    private string baseCommandText;
    
    [Header("Text of CMD")]
    [SerializeField] private Text textCMD;
    [SerializeField] private GameObject prefabTextCMD;

    [Header("Layout")]
    [SerializeField] private VerticalLayoutGroup verticalLayoutGroup;

    public UnityEvent messageIsWritting;

    [Header("Individue")]
    [SerializeField] private Color hackerColor;
    [SerializeField] private Color userColor;
    [SerializeField] private string userName;
    [SerializeField] private string hackerName;
    
    private string textCMDStack;
    private string currentTextWritting;
    private int indexCommand = 0;
    private int indexWritting= 0;
    
    [Header("List of dialogue")]
    [SerializeField]
    public contentDialogue[] myDialogue;
    [Serializable]
    public struct contentDialogue
    {
        public string writtingText; 
        
        [TextArea(5,5)]
        public List<string> dialogueText;
    }
    
    private void Update()
    {
        if (Input.anyKeyDown)
        {
            if (indexWritting == myDialogue.Length)
            {
                return;
            }  
            
            indexCommand++;

            if (indexCommand > myDialogue[indexWritting].writtingText.Length)
            {
                SetTextCommand();

                for (int i = 0; i <  myDialogue[indexWritting].dialogueText.Count; i++)
                {
                    SetTextDialogue();
                }

                messageIsWritting.Invoke();
                
                indexCommand = 0;
                indexWritting++;
                
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
        textCMD.text = ($"----------------");
        txt.text = ($"{userName} {myDialogue[indexWritting].writtingText}");
        txt.color = userColor;
        verticalLayoutGroup.padding.top += -50;
    }    
    
    void SetTextDialogue()
    {
        for (int i = 0; i <  myDialogue[indexWritting].dialogueText.Count; i++)
        {
            CreateText();
            txt.text = ($"{hackerName} {myDialogue[indexWritting].dialogueText[i]}");
            txt.color = hackerColor;
            verticalLayoutGroup.padding.top += -50;
        }
    }
    
    void CreateText()
    {
        obj = Instantiate(prefabTextCMD, verticalLayoutGroup.transform);
        txt = obj.GetComponentInChildren<Text>();
    }
}
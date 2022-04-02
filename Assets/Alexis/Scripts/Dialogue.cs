using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public abstract class Dialogue : MonoBehaviour
{    
    [Header("Base command")]
    [SerializeField]
    protected string baseCommandText;
    [Header("Text of CMD")]
    [SerializeField]
    protected Text textCMD;
    [SerializeField] protected GameObject prefabTextCMD;

    [Header("Layout")]
    [SerializeField] protected VerticalLayoutGroup verticalLayoutGroup;

    public UnityEvent messageIsWritting;
    
    [Header("Individue")]
    [SerializeField] protected Color hackerColor;
    [SerializeField] protected Color userColor;
    [SerializeField] protected string userName;
    [SerializeField] protected string hackerName;
    
    protected string textCMDStack;
    protected string currentTextWritting;
    protected int indexCommand = 0;
    protected int indexWritting= 0;
    protected GameObject obj;
    protected Text txt;
    
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

    public void checkKeyBoard()
    {
        if (Input.anyKeyDown)
        {
            if (indexWritting == myDialogue.Length)
            {
                return;
            }  
                
            indexCommand++;

            Debug.Log($"indexCommand : {indexCommand} and indexWritting {indexWritting}");
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

    public virtual void SetTextCommand()
    {
        CreateText();
        textCMD.text = ($"Cortana");
        txt.text = ($"{userName} {myDialogue[indexWritting].writtingText}");
        txt.color = userColor;
        verticalLayoutGroup.padding.top += -50;
    }    
    
    public virtual  void SetTextDialogue()
    {
        for (int i = 0; i <  myDialogue[indexWritting].dialogueText.Count; i++)
        {
            Debug.Log("je creer un text");
            CreateText();
            txt.text = ($"{hackerName} {myDialogue[indexWritting].dialogueText[i]}");
            txt.color = hackerColor;
            verticalLayoutGroup.padding.top += -50;
        }
    }
    
    public virtual  void CreateText()
    {
        obj = Instantiate(prefabTextCMD, verticalLayoutGroup.transform);
        txt = obj.GetComponentInChildren<Text>();
    }
}

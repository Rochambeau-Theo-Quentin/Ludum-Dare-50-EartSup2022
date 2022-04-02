using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Cortana : Dialogue
{
    private void Update()
    {
        checkKeyBoard();
    }
    public override void SetTextCommand()
    {
        CreateText();
        textCMD.text = ($"Cortana");
        txt.text = ($"{userName} {myDialogue[indexWritting].writtingText}");
        txt.color = userColor;
        verticalLayoutGroup.padding.top += -50;
    }    
    
    public override  void SetTextDialogue()
    {
        for (int i = 0; i <  myDialogue[indexWritting].dialogueText.Count; i++)
        {
            CreateText();
            txt.text = ($"{hackerName} {myDialogue[indexWritting].dialogueText[i]}");
            txt.color = hackerColor;
            verticalLayoutGroup.padding.top += -50;
        }
    }
    
    public override  void CreateText()
    {
        obj = Instantiate(prefabTextCMD, verticalLayoutGroup.transform);
        txt = obj.GetComponentInChildren<Text>();
    }
}

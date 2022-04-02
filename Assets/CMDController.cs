using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CMDController : MonoBehaviour
{
    [Header("List of dialogue")]
    [TextArea(3,2)]
    [SerializeField]
    private List<string> writtingText;
    
    [TextArea(5,5)]
    [SerializeField]
    private List<string> dialogueText;
    
    [Header("Base command")]
    [SerializeField]
    private string baseCommandText;
    
    [Header("Text of CMD")]
    [SerializeField] private Text textCMD;
    [SerializeField] private GameObject prefabTextCMD;

    [Header("Layout")]
    [SerializeField] private VerticalLayoutGroup verticalLayoutGroup;


    private string textCMDStack;
    private string currentTextWritting;
    private int indexCommand = 0;
    private int indexWritting= 0;

    private void Start()
    {
        SetText();
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            if (indexWritting == writtingText.Count)
            {
                return;
            }  
            
            indexCommand++;
            
            if (indexCommand > writtingText[indexWritting].Length)
            {
                indexWritting++;
                return;
            }
            
            currentTextWritting = writtingText[indexWritting].Substring(0, indexCommand);
            textCMD.text = ($"{baseCommandText}{currentTextWritting}");
        }
    }

    void SetText()
    {
        GameObject obj = Instantiate(prefabTextCMD, verticalLayoutGroup.transform);
        Text txt = obj.GetComponentInChildren<Text>();

        txt.text = writtingText[indexWritting];
        verticalLayoutGroup.padding.top += -50;
    }

    /*
    private void Start()
    {
        //Debug.Log( " basicText : " + basicText + "allText : " + allText[0]);
        //textCMD.text = ($"{textCMD.text} \n \n {basicText}{allText[0]}");
        SetText();
    }

    private void Update()
    {

        if (Input.anyKeyDown)
        {
            if (indexWritting == writtingText.Count)
            {
                return;
            }  
            
            indexCommand++;

            if (indexCommand > writtingText[indexWritting].Length)
            {                
                SetText();
                textCMD.text = ($"{textCMDStack} \n \n {dialogueText[indexWritting]}");
                SetText();
    
                indexCommand = 0;
                indexWritting++;
                return;
            }
            
            currentTextWritting = writtingText[indexWritting].Substring(0, indexCommand);
            textCMD.text = ($"{textCMDStack} \n \n {baseCommandText}{currentTextWritting}");
        }
    }

    void SetText()
    {
        textCMDStack = textCMD.text;
    }
    */
}

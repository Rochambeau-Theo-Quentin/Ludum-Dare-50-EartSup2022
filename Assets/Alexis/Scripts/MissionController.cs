using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MissionController : MonoBehaviour
{
    [SerializeField] public List<mission> myMission = new List<mission>();
    //[SerializeField] public List<CMDController> cmd = new List<CMDController>();
    private int IndexMission= 0;
    
    //[SerializeField]
    //private Mission test;
  /// <summary>
  ///nous sert a parametré chaque mission avec l'ajout de dialogue pour chaque type de CMDController (a renommer d'ailleur)
  /// Oui ce n'est pas beau mais j'ai plus de facilité a utiliser les struct XD
  /// </summary>
    [Serializable]
    public struct mission
    {
        [SerializeField] public CMD myCMD;
        [SerializeField] public Cortana myCortana;
        [SerializeField] public Google myGoogle;
        [SerializeField] public Readme myReadme;
        [SerializeField] public Window myWindow;
    }
  
  //A mettre tout ça en fusion dans une class genre : mission avec juste string / list<string> / et un event 
    [Serializable]
    public struct CMD
    {
        public string commandeCMD;
        public string elementToProgress;
        public List<string> dialogues;
        
        public UnityEvent<string, List<string>> AddDialogue;
    } 
    [Serializable]
    public struct Cortana
    {
        public string commandeCortana;
        public string elementToProgress;
        public List<string> dialogues;
        
        public UnityEvent<string, List<string>> AddDialogue;
    } 
    [Serializable]
    public struct Google
    {
        public string commandeGoogle;
        public string elementToProgress;
        public List<string> dialogues;
        
        public UnityEvent<string, List<string>> AddDialogue;
    }
    [Serializable]
    public struct Readme
    {
        public string elementToProgress;
    }    
    [Serializable]
    public struct Window
    {
        public string elementToProgress;
    }

    public void VerificationWindows(string windows)
    {
        
        if (myMission[IndexMission].myCortana.elementToProgress == windows || 
            myMission[IndexMission].myCMD.elementToProgress == windows ||
            myMission[IndexMission].myGoogle.elementToProgress == windows ||
            myMission[IndexMission].myReadme.elementToProgress == windows)
        {
            Debug.LogWarning("Tu passe de niveau oulalalaa");
                FinishStepMission();
        }
        
    }
    
    public void addListenedOfMision(CMDController cmdController)
    {

        if (cmdController.GetState() == dialogueState.CMD)
        {
            Debug.Log("CMD");

            for (int i = 0; i < myMission.Count; i++)
            {
                myMission[i].myCMD.AddDialogue.AddListener(cmdController.AddDialogue);   
            }
        }
        
        if (cmdController.GetState() == dialogueState.Cortana)
        {
            Debug.Log("Cortana");
            myMission[IndexMission].myCortana.AddDialogue.AddListener(cmdController.AddDialogue);
        }

        if (cmdController.GetState() == dialogueState.Google)
        {           
            Debug.Log("Google");
            for (int i = 0; i < myMission.Count; i++)
            {
                myMission[IndexMission].myGoogle.AddDialogue.AddListener(cmdController.AddDialogue);
            }
        }
        
        //cmd.Add(cmdController);
    }

    public void FinishStepMission()
    {
        if (IndexMission >= myMission.Count)
            return;
        
        //Debug.Log($"Nous avons i : {i} et nous avons myMission[i].commandeCMD { myMission[i].commandeCMD } et myMission[i].dialogues : { myMission[i].dialogues}");
        if( myMission[IndexMission].myCMD.commandeCMD != null)
         myMission[IndexMission].myCMD.AddDialogue.Invoke(myMission[IndexMission].myCMD.commandeCMD, myMission[IndexMission].myCMD.dialogues);

        if (myMission[IndexMission].myCortana.commandeCortana != null)
        {
            myMission[IndexMission].myCortana.AddDialogue.Invoke(myMission[IndexMission].myCortana.commandeCortana, myMission[IndexMission].myCortana.dialogues);
        }
        
        if( myMission[IndexMission].myGoogle.commandeGoogle != null)
         myMission[IndexMission].myGoogle.AddDialogue.Invoke(myMission[IndexMission].myGoogle.commandeGoogle, myMission[IndexMission].myGoogle.dialogues);
        
        IndexMission++;
    }
}

public abstract class Mission : MonoBehaviour
{
    [Serializable]
    public struct test
    {
        [Header("Name of Part mission")]
        public string name;
        public string commande;
        public List<string> dialogues;
        
        public UnityEvent<string, List<string>> AddDialogue;
    } 
}


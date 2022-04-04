using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class MissionController : MonoBehaviour
{
    [SerializeField] public List<mission> myMission = new List<mission>();
    //[SerializeField] public List<CMDController> cmd = new List<CMDController>();
    private int IndexMission { get; set; }
    
    //[SerializeField]
    //private Mission test;
  /// <summary>
  ///nous sert a parametré chaque mission avec l'ajout de dialogue pour chaque type de CMDController (a renommer d'ailleur)
  /// Oui ce n'est pas beau mais j'ai plus de facilité a utiliser les struct XD
  /// </summary>
    [Serializable]
    public struct mission
  {
      public List<string> elementToProgress;
      public GameObject iconToSpawn;
      public Transform iconToSpawnPoint;
      
        [SerializeField] public CMD myCMD;
        [SerializeField] public Cortana myCortana;
        [SerializeField] public Google myGoogle;
        //[SerializeField] public Readme myReadme;
        //[SerializeField] public Window myWindow;
    }
  
  //A mettre tout ça en fusion dans une class genre : mission avec juste string / list<string> / et un event 
    [Serializable]
    public struct CMD
    {
        public string commandeCMD;
        public List<string> dialogues;
        
        public UnityEvent<string, List<string>> AddDialogue;
    } 
    [Serializable]
    public struct Cortana
    {
        public string commandeCortana;

        public List<string> dialogues;
        
        public UnityEvent<string, List<string>> AddDialogue;
    } 
    [Serializable]
    public struct Google
    {
        public string commandeGoogle;

        public List<string> dialogues;
        
        public UnityEvent<string, List<string>> AddDialogue;
    }
    /*
    [Serializable]
    public struct Readme
    {
        public GameObject iconToSpawn;
        public Transform iconToSpawnPoint;
    }    
    [Serializable]
    public struct Window
    {
        public GameObject iconToSpawn;
        public Transform iconToSpawnPoint;
    }
*/
    public void VerificationWindows(string windows)
    {
        foreach (string step in myMission[IndexMission].elementToProgress)
        {
            if (step == windows)
            {
                Debug.LogWarning("Tu passe de niveau oulalalaa");
                SpawnNewIcon();
                FinishStepMission();
            }   
        }
    }

    void SpawnNewIcon()
    {
        if (myMission[IndexMission].iconToSpawn != null)
        {
            Instantiate(myMission[IndexMission].iconToSpawn.gameObject, 
               myMission[IndexMission].iconToSpawnPoint.position, 
               transform.rotation,
               myMission[IndexMission].iconToSpawnPoint.transform);
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
                myMission[i].myGoogle.AddDialogue.AddListener(cmdController.AddDialogue);
                //Debug.Log(i);
            }
        }

        //cmd.Add(cmdController);
    }

    public void  GetMission()
    {
        for (int i = 0; i < IndexMission; i++)
        {
            myMission[i].myGoogle.AddDialogue.Invoke(myMission[i].myGoogle.commandeGoogle, myMission[i].myGoogle.dialogues);
            //Debug.Log(i);
        }
    }

    public void FinishStepMission()
    {
        if (IndexMission >= myMission.Count)
        {
            return;   
        }

        //Debug.Log($"Nous avons i : {i} et nous avons myMission[i].commandeCMD { myMission[i].commandeCMD } et myMission[i].dialogues : { myMission[i].dialogues}");
        if (myMission[IndexMission].myCMD.commandeCMD != null)
        {
            Debug.LogWarning("pourtant tu doit te lancer");
            Debug.LogWarning("pourtant tu doit te lancer");
            myMission[IndexMission].myCMD.AddDialogue.Invoke(myMission[IndexMission].myCMD.commandeCMD, myMission[IndexMission].myCMD.dialogues);   
        }

        if (myMission[IndexMission].myCortana.commandeCortana != null)
        {
            myMission[IndexMission].myCortana.AddDialogue.Invoke(myMission[IndexMission].myCortana.commandeCortana, myMission[IndexMission].myCortana.dialogues);
        }

        if (myMission[IndexMission].myGoogle.commandeGoogle != null)
        {
            myMission[IndexMission].myGoogle.AddDialogue.Invoke(myMission[IndexMission].myGoogle.commandeGoogle, myMission[IndexMission].myGoogle.dialogues);
           // Debug.Log("myMission[IndexMission].myGoogle.commandeGoogle : " + myMission[IndexMission].myGoogle.commandeGoogle);
        }

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


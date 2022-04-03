using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MissionController : MonoBehaviour
{
    [SerializeField] public List<mission> myMission = new List<mission>();
    private int IndexMission= 0;
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
    }
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

    public void Start()
    {
        FinishMission();
    }

    public void FinishMission()
    {
        //Debug.Log($"Nous avons i : {i} et nous avons myMission[i].commandeCMD { myMission[i].commandeCMD } et myMission[i].dialogues : { myMission[i].dialogues}");
        if( myMission[IndexMission].myCMD.commandeCMD != null)
         myMission[IndexMission].myCMD.AddDialogue.Invoke(myMission[IndexMission].myCMD.commandeCMD, myMission[IndexMission].myCMD.dialogues);
        
        if( myMission[IndexMission].myCortana.commandeCortana != null)
            myMission[IndexMission].myCortana.AddDialogue.Invoke(myMission[IndexMission].myCortana.commandeCortana, myMission[IndexMission].myCortana.dialogues);
        
        if( myMission[IndexMission].myGoogle.commandeGoogle != null)
         myMission[IndexMission].myGoogle.AddDialogue.Invoke(myMission[IndexMission].myGoogle.commandeGoogle, myMission[IndexMission].myGoogle.dialogues);
        IndexMission++;
    }
}


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MissionController : MonoBehaviour
{
    [SerializeField] public List<mission> myMission = new List<mission>();

    [Serializable]
    public struct mission
    {
        public string name;
        public string commande;
        public List<string> dialogues;
        
        public UnityEvent<string, List<string>> AddDialogue;
    }

    public void FinishMission(int i)
    {
        myMission[i].AddDialogue.Invoke(myMission[i].commande, myMission[i].dialogues);
    }
}


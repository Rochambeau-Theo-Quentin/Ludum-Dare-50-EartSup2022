using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendInformation : MonoBehaviour
{
    private GameObject missionController;
    private CMDController _cmdController;
    public void Start()
    {
        missionController = GameObject.Find("MissionController");
        MissionController ms = missionController.GetComponent<MissionController>();
        _cmdController = GetComponent<CMDController>();
        ms.addListenedOfMision(_cmdController);
    }
}

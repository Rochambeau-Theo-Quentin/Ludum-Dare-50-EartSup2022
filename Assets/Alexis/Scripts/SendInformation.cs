using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SendInformation : MonoBehaviour, IPointerEnterHandler
{
    private MissionController _missionController;
    private CMDController _cmdController;

    private bool debug;
    public void Start()
    {
       GameObject ms = GameObject.Find("MissionController");
       _missionController= ms.GetComponent<MissionController>();
       _cmdController = GetComponent<CMDController>();
       
        if(_cmdController == null)
            return;
        
        _missionController.addListenedOfMision(_cmdController);
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        DebugText(name);
    }
    
    public void DebugText(string _string)
    {
        Debug.Log(_string);
        _missionController.VerificationWindows(_string);
    }
}

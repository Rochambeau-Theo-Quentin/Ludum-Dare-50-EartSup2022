using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class TestDeMission : MonoBehaviour, IPointerEnterHandler
{
    public UnityEvent myEvent;
    public void OnPointerEnter(PointerEventData eventData)
    {
        myEvent.Invoke();
    }
    
}

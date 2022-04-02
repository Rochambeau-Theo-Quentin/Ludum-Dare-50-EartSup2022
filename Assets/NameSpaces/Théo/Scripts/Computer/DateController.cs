using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DateController : MonoBehaviour
{
    private TextMeshProUGUI hourText;
    private TextMeshProUGUI dateText;

    private void Awake()
    {
        hourText = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        dateText = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        System.DateTime _date = System.DateTime.Now;

        hourText.text = _date.Hour.ToString("00") + ":" + _date.Minute.ToString("00");
        dateText.text = _date.Month.ToString("00") + "/" + _date.Day.ToString("00") + "/" + _date.Year.ToString("0000");
    }
}

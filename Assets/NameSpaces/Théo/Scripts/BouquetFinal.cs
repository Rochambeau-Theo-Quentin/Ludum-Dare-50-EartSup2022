using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NazioToolKit;

public class BouquetFinal : MonoBehaviour
{
    [Header("Vignette")]
    [SerializeField] private float waitingRedTime;
    [SerializeField] private float timeToRed;
    [SerializeField] private float maxRedValue;

    [Header("Risitas")]
    [SerializeField] private float[] timeBetweenRisitas;
    [SerializeField] private GameObject[] risitas;

    [Header("BlackScreen")]
    [SerializeField] private float[] timeBetweenblackScreen;
    [SerializeField] private float blackScreenDuration;
    [SerializeField] private GameObject view;

    [Header("BlackScreen")]
    [SerializeField] private float[] timeBetweenAberration;
    [SerializeField] private float aberrationDuration;

    private PostProcessController pp;

    private void Awake()
    {
        pp = GetComponent<PostProcessController>();
    }

    private void Start()
    {
        StartCoroutine(ToRed());
        StartCoroutine(Risitas());
        StartCoroutine(BlackScreen());
        StartCoroutine(Aberration());
    }

    private IEnumerator Aberration()
    {
        for (var i = 0; i < timeBetweenAberration.Length; i++)
        {
            yield return new WaitForSeconds(timeBetweenAberration[i]);

           pp.SetAberrationValue(1f);
print(i);

            yield return new WaitForSeconds(aberrationDuration);

            pp.SetAberrationValue(0f);
        }
    }

    private IEnumerator BlackScreen()
    {
        for (var i = 0; i < timeBetweenblackScreen.Length; i++)
        {
            yield return new WaitForSeconds(timeBetweenblackScreen[i]);

            view.SetActive(false);

            yield return new WaitForSeconds(blackScreenDuration);

            view.SetActive(true);
        }
    }

    private IEnumerator Risitas()
    {
        for (var i = 0; i < risitas.Length; i++)
        {
            yield return new WaitForSeconds(timeBetweenRisitas[i]);

            risitas[i].SetActive(true);
        }
    }

    private IEnumerator ToRed()
    {
        yield return new WaitForSeconds(waitingRedTime);

        float _t = 0;

        while (true)
        {
            yield return null;
            _t += Time.deltaTime;

            if (_t > timeToRed)
            {
                pp.ModifyVignette(maxRedValue);
                break;
            }

            pp.ModifyVignette(Mathf.Lerp(0, maxRedValue, _t / timeToRed));
        }
    }
}

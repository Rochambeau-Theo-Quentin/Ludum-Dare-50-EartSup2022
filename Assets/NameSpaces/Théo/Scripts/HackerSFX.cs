using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HackerSFX : MonoBehaviour
{
    [SerializeField] private float spaceProba = 0.1f;
    [SerializeField] private float randomizeCount = 0;
    [SerializeField] private int lineCount = 0;
    [SerializeField] private int letterCount = 0;

    [Header("Prefabs")]
    [SerializeField] private Transform textPrefab;

    private TextMeshProUGUI[] texts;

    private void Start()
    {
        texts = new TextMeshProUGUI[lineCount];

        for (var i = 0; i < lineCount; i++)
        {
            texts[i] = Instantiate(textPrefab, transform.position, Quaternion.identity, transform).GetComponent<TextMeshProUGUI>();
            texts[i].text = GetRandomLine();
        }

        StartCoroutine(WaitForRandomize());
    }

    private IEnumerator WaitForRandomize()
    {
        float _t = 0;

        while (true)
        {
            _t += Time.deltaTime;
            spaceProba = GetNewSpaceProba();

            yield return null;

            if (_t >= randomizeCount)
            {
                _t = 0;
                RandomizeLines();
            }
        }
    }

    private float GetNewSpaceProba()
    {
        float _result = spaceProba + Random.Range(-1f,1f) * Time.deltaTime;
        return Mathf.Clamp(_result, 0.05f,0.5f);
    }

    private void RandomizeLines()
    {
        foreach (var _text in texts)
        {
            _text.text = GetRandomLine();
        }
    }

    private string GetRandomLine()
    {
        string _result = "";

        for (var i = 0; i < letterCount; i++)
        {
            _result += RandomChar();
        }

        return _result;
    }

    private char RandomChar()
    {
        int _num = Random.Range(0, 30);
        char let = (char)('a' + _num);
        if(Random.Range(0f,1f) < spaceProba) let = ' ';

        return let;
    }
}

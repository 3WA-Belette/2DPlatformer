using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _text;

    int _score;

    public void AddScore()
    {
        Debug.Log("YOUPI J'ai gagné des points");

        _score++;
        _text.text = _score.ToString();
    }



}

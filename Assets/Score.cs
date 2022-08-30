using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _text;

    int _score;

    private void Start()
    {
        //_score = 0;
        _score = PlayerPrefs.GetInt("Score");
        _text.text = _score.ToString();
    }

    public void AddScore(int scoreToAdd)
    {
        Debug.Log("YOUPI J'ai gagné des points");

        _score += scoreToAdd;
        _text.text = _score.ToString();

        PlayerPrefs.SetInt("Score", _score);
    }



}

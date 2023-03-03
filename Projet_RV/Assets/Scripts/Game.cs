using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Game : MonoBehaviour
{
    public GameObject ScoreGO;
    public int Score = 0;
    private TextMeshProUGUI tmProScore;
    // Start is called before the first frame update
    void Start()
    {
        tmProScore = ScoreGO.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(int value)
    {
        Score += value;
        if (value < 0)
        {
            value = 0;
        }  
        tmProScore.text = "Score : " + Score.ToString() ;
    }
}

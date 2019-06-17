using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    

    int myScore = 0;
    Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        scoreText.text = myScore.ToString();
    }

    public void ScoreHit(int score)
    {
        myScore += score;
        scoreText.text = myScore.ToString();
    }
}

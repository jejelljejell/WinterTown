using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int score = 0;
    Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    { 
        scoreText.text = "Coin: " + score;
    }

    public static void setScore(int value)
    {
        score += value;
    }

    public static int getScore()
    {
        return score;
    }

}

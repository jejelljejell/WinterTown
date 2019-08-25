using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonEvent : MonoBehaviour
{
    public void OnClickStartButton()
    {
        ScoreManager.score = 0;
        SceneManager.LoadScene("GameScene");
        
    }

    public void OnClickMainButton()
    {
        ScoreManager.score = 0;
        SceneManager.LoadScene("StartScene");
    }

    public void OnClickTutorialButton()
    {
        ScoreManager.score = 0;
        SceneManager.LoadScene("TutorialScene");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionTrigger : MonoBehaviour
{
    public GameObject option_page;
    public GameObject MusicOption;

    public void OptionDown()
    {
        Time.timeScale = 0; //인게임 시간 정지
        option_page.SetActive(true);
    }

    public void OptionConfirm()
    {
        option_page.SetActive(false);
        Time.timeScale = 1;
    }

    public void Restart()
    {
        Time.timeScale = 1;
        ScoreManager.score = 0;
        SceneManager.LoadScene("GameScene");
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        ScoreManager.score = 0;
        SceneManager.LoadScene("StartScene");
    }

    public void MusicDown()
    {
        MusicOption.SetActive(true);
    }

    public void MusicConfirm()
    {
        MusicOption.SetActive(false);
    }
}

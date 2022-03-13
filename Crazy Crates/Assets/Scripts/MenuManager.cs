using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager: MonoBehaviour
{
    public GameObject playButton;
    public GameObject diffButtons;

    public int askedDifficulty;

    public void PlayButton()
    {
        playButton.SetActive(false);
        diffButtons.SetActive(true);
    }

    public void StartGame(int difficulty)
    {
        askedDifficulty = difficulty;
        SceneManager.LoadScene("GameScene");
        DontDestroyOnLoad(gameObject);
    }
}

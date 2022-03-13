using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public int lives = 3;
    public float baseAttackTime;

    public int difficulty = 1;

    public bool gameActive;

    public bool input0;
    public bool input1;
    public bool input2;
    public bool input3;

    public GameObject tas;
    public GameObject player;
    private MenuManager menuManager;

    public GameObject canevas;
    public GameObject gameOverScreen;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;

    public GameObject spawnManagerObject;
    private MissileLauncher missileLauncher;

    public float volume = 1.0f;
    public float musicVolumeModifier = 0.3f;

    private AudioSource musicSource;

    //islands 1er plan :
    public float island1x;
    public float island1z;

    //islands 2nd plan :
    public float island2x;
    public float island2z;


    // Start is called before the first frame update
    void Start()
    {
        menuManager = GameObject.Find("MenuManager").GetComponent<MenuManager>();
        difficulty = menuManager.askedDifficulty;

        baseAttackTime /= difficulty;
        missileLauncher = spawnManagerObject.GetComponent<MissileLauncher>();
        StartCoroutine(missileLauncher.SpawnNewMissile());

        gameActive = true;
        ActuLives(lives - 1);
        UpdateScore(0);

        musicSource = gameObject.GetComponent<AudioSource>();
        musicSource.volume = volume*musicVolumeModifier;
        musicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        input0 = Input.GetKey(KeyCode.Alpha1);
        input1 = Input.GetKey(KeyCode.Alpha2);
        input2 = Input.GetKey(KeyCode.Alpha3);
        input3 = Input.GetKey(KeyCode.Alpha4);
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.SetText("Score : " + score);
    }

    public void GameOver()
    {
        gameActive = false;
        gameOverScreen.gameObject.SetActive(true);

        musicSource.Stop();
    }

    public void CreaObjectOnTheSide(GameObject objet, float centerX, float centerZ, float posY, float offset)
    {
        Vector3 pos = new Vector3(centerX + Random.Range(-offset, offset), posY, centerZ + Random.Range(-offset, offset));
        GameObject nouvObj = Instantiate(objet, pos, gameObject.transform.rotation);
        nouvObj.transform.SetParent(tas.transform);
    }

    public void LiveLost()
    {
        lives--;
        if (lives == 2)
        {
            NewDestuctionState(1);
            ActuLives(lives - 1);
        }

        else if (lives == 1)
        {
            NewDestuctionState(2);
            ActuLives(lives - 1);
        }

        else if (lives == 0)
        {
            NewDestuctionState(3);
            GameOver();
        }
    }

    public void ActuLives(int livesToShow)
    {
        livesText.SetText("Lives : " + livesToShow.ToString());
    }

    private void NewDestuctionState(int destructionLevel)
    {
        destructionLevel += 3;
        
        if (destructionLevel == 4)
        {
            player.transform.GetChild(destructionLevel).gameObject.SetActive(true);
        }
        
        else
        {
            player.transform.GetChild(destructionLevel).gameObject.SetActive(true);
            
            for (int i = 0; i < player.transform.GetChild(destructionLevel-1).childCount; i++)
            {
                ParticleSystem fumée = player.transform.GetChild(destructionLevel-1).GetChild(i).gameObject.GetComponent<ParticleSystem>();
                fumée.Stop();
            }
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Menus");
    }
}
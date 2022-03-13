using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    public GameObject menuManagerObject;
    private MenuManager menuManager;

    private Button button;

    public int difficulty;

    private void Start()
    {
        button = gameObject.GetComponent<Button>();
        menuManager = menuManagerObject.GetComponent<MenuManager>();

        button.onClick.AddListener(SetDifficulty);
    }

    void SetDifficulty()
    {
        Debug.Log(gameObject.name + " was clicked");
        menuManager.StartGame(difficulty);
    }
}

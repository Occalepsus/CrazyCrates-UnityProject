using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject gameManagerObject;

    public float speed;
    public float rangeX;

    public float hInput;

    private void Start()
    {
        gameManager = gameManagerObject.GetComponent<GameManager>();
    }

    void Update()
    {
        if (gameManager.gameActive)
        {
            hInput = Input.GetAxis("Mouse X");

            transform.Translate(Vector3.forward * speed * Time.deltaTime * hInput);

            if (transform.position.x < -rangeX)
            {
                transform.position = new Vector3(-rangeX, transform.position.y, transform.position.z);
            }

            if (transform.position.x > rangeX)
            {
                transform.position = new Vector3(rangeX, transform.position.y, transform.position.z);
            }
        }
    }

    
}

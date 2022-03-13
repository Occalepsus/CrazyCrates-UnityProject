using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targets : MonoBehaviour
{
    //private GameManager gameManager;

    public AudioSource targetAudio;
    public AudioClip targetSound;

    public float maxSpeed; public float minSpeed;
    private float speed;

    public float limitz;

    public int pointValue;

    private void Start()
    {
        //gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        speed = Random.Range(minSpeed, maxSpeed);
        targetAudio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        gameObject.transform.Translate(Vector3.forward * Time.deltaTime * speed);
        if (transform.position.z < limitz)
        {
            Destroy(gameObject);
        }
    }
}
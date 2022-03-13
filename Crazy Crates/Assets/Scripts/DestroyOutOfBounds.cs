using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    public float limity;

    void Update()
    {
        if (gameObject.transform.position.y < limity)
        {
            Destroy(gameObject);
        }
    }
}

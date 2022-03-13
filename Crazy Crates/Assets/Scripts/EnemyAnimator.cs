using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.WSA;

public class EnemyAnimator : MonoBehaviour
{
    private GameObject heliceY;
    private GameObject heliceZ;

    private float speed;
    private float ds;
    private float oldDs1;
    private float oldDs2;
    private float oldDs3;
    private float oldDs4;
    private float oldDs5;
    public float speed1;
    public float speed2;

    public float dsLimit;

    public float forceRange;
    public float stopInMaxFrames;

    public float warningX;
    public float limitX;

    // Start is called before the first frame update
    void Start()
    {
        heliceY = gameObject.transform.GetChild(0).gameObject;
        heliceZ = gameObject.transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        heliceY.transform.Rotate(Vector3.up, speed1 * Time.deltaTime);
        heliceZ.transform.Rotate(Vector3.right, speed2 * Time.deltaTime);

        if (gameObject.transform.position.x < -warningX)
        {
            ds = Random.Range(0, dsLimit);
        }

        else if (warningX < gameObject.transform.position.x)
        {
            ds = Random.Range(-dsLimit, 0);
        }

        else
        {
            ds = Random.Range(-dsLimit, dsLimit);
        }

        speed += ds;
        gameObject.transform.Translate(new Vector3(1,0,0) * speed * Time.deltaTime, Space.World);
        gameObject.transform.Rotate(Vector3.left * (ds + oldDs1 + oldDs2 + oldDs3 + oldDs4 + oldDs5)/6 * Time.deltaTime * 100);

        oldDs5 = oldDs4;
        oldDs4 = oldDs3;
        oldDs3 = oldDs2;
        oldDs2 = oldDs1;
        oldDs1 = ds;

        if (gameObject.transform.position.x < -limitX)
        {
            speed = dsLimit;
            gameObject.transform.rotation = Quaternion.Euler(0, -90, 0);
        }

        else if (limitX < gameObject.transform.position.x)
        {
            speed = -dsLimit;
            gameObject.transform.rotation = Quaternion.Euler(0, -90, 0);
        }
    }
}
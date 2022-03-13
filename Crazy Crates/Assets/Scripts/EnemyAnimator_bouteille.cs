using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyAnimator_bouteille : MonoBehaviour
{
    private GameObject heliceY;
    private GameObject heliceZ;

    private float speed;
    private float ds;
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
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -limitX, limitX), transform.position.y, transform.position.z);

        Vector3 dir = transform.position * speed;
        transform.rotation = Quaternion.LookRotation(dir);
    }
}
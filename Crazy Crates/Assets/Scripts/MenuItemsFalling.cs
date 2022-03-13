using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuItemsFalling : MonoBehaviour
{
    public GameObject[] fallenPrefabs;
    public GameObject objectContainer;

    public float posX;
    public float posY;
    public float posZ;

    public float xzOffset;

    public float timeMin;
    public float timeMax;

    void Start()
    {
        StartCoroutine(CreaNewFalling());
    }

    IEnumerator CreaNewFalling()
    {
        int index = Random.Range(0, fallenPrefabs.Length);
        float nextObj = Random.Range(timeMin, timeMax);

        Vector3 randomPosition = new Vector3(Random.Range(posX - xzOffset, posX + xzOffset), posY, Random.Range(posZ - xzOffset, posZ + xzOffset));
        Vector3 randomTorque = new Vector3(Random.Range(0, 50), Random.Range(0, 50), Random.Range(0, 50));

        GameObject newObject = Instantiate(fallenPrefabs[index], randomPosition, transform.rotation, objectContainer.transform);
        Rigidbody rigidbody = newObject.GetComponent<Rigidbody>();

        rigidbody.AddTorque(randomTorque, ForceMode.Impulse);

        yield return new WaitForSeconds(nextObj);

        StartCoroutine(CreaNewFalling());
    }
}

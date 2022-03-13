using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] prefabs;
    public GameObject spawnManager;
    public GameObject ballon;
    public Material[] ballonColors;

    private Renderer ballonRenderer;

    private GameManager gameManager;
    public GameObject gameManagerObject;

    public float deltaTime;

    public float spawnLimitX = 4f;
    public float spawnPosZ = 75;
    public float spawnPosY = 0.3f;

    void Start()
    {
        gameManager = gameManagerObject.GetComponent<GameManager>();
        StartCoroutine(SpawnLoop());
    }

    void SpawnRandomObject()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnLimitX, spawnLimitX), spawnPosY, spawnPosZ);
        int index = Random.Range(0, prefabs.Length);

        GameObject crate = Instantiate(prefabs[index], spawnPos, prefabs[index].transform.rotation);

        crate.transform.SetParent(spawnManager.transform);

        AttachABallon(crate);
    }

    void AttachABallon(GameObject crate)
    {
        int index = UnityEngine.Random.Range(0, ballonColors.Length);

        GameObject attachment = Instantiate(ballon, crate.transform.position + new Vector3(0,1.85f,0), gameObject.transform.rotation);
        ballonRenderer = attachment.GetComponent<MeshRenderer>();

        ballonRenderer.material = ballonColors[index];

        attachment.transform.SetParent(crate.transform);
    }

    IEnumerator SpawnLoop()
    {
        yield return new WaitForSeconds(deltaTime);
        SpawnRandomObject();
        if (gameManager.gameActive)
        {
            StartCoroutine(SpawnLoop());
        }
    }
}
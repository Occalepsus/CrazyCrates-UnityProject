using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileLauncher : MonoBehaviour
{
    public GameObject missilePrefab;

    public GameObject spawnManager;
    public GameObject enemy;

    private GameManager gameManager;
    public GameObject gameManagerObject;

    private Vector3 spawnRotation = new Vector3(10,180,0);

    public float timeRange;
    private float nextLaunch;

    void Start()
    {
        gameManager = gameManagerObject.GetComponent<GameManager>();
    }

    public IEnumerator SpawnNewMissile()
    {
        Vector3 spawnPosition = enemy.transform.position;
        nextLaunch = gameManager.baseAttackTime + Random.Range(-timeRange,timeRange);

        Instantiate(missilePrefab, spawnPosition, Quaternion.Euler(spawnRotation), gameObject.transform);
        yield return new WaitForSeconds(nextLaunch);

        if (gameManager.gameActive)
        {
            StartCoroutine(SpawnNewMissile());
        }
    }


}

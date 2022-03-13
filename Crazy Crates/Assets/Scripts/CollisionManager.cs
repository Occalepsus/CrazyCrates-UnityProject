using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    private GameManager gameManager;
    private Selector selector;
    public GameObject gameManagerObject;
    private Targets targets;

    public GameObject[] cosmeticPrefabs;

    public ParticleSystem explosionParticle;
    private ParticleSystem flameThrower;

    private AudioSource targetsSource;
    public AudioClip explosionSound;
    public AudioClip goodSound;

    public float posY;
    public float offset;

    public float volumeModifier;

    private void Start()
    {
        gameManager = gameManagerObject.GetComponent<GameManager>();
        selector = gameManagerObject.GetComponent<Selector>();
        targetsSource = gameObject.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider objet)
    {
        if (gameManager.gameActive)
        {
            if (objet.CompareTag("Bad"))
            {
                flameThrower = objet.transform.GetChild(0).gameObject.GetComponent<ParticleSystem>();
                targetsSource.PlayOneShot(explosionSound, gameManager.volume * volumeModifier);
                StartCoroutine(MissileCollision(objet.gameObject));
            }

            if (objet.CompareTag("caisse?") && selector.selection == 0)
            {
                targets = objet.gameObject.GetComponent<Targets>();
                gameManager.UpdateScore(targets.pointValue);
                Destroy(objet.gameObject);
                targetsSource.PlayOneShot(goodSound, gameManager.volume * volumeModifier);
                gameManager.CreaObjectOnTheSide(cosmeticPrefabs[0], gameManager.island1x, gameManager.island1z, posY, offset);
            }

            if (objet.CompareTag("tonneau") && selector.selection == 1)
            {
                targets = objet.gameObject.GetComponent<Targets>();
                gameManager.UpdateScore(targets.pointValue);
                Destroy(objet.gameObject);
                targetsSource.PlayOneShot(goodSound, gameManager.volume * volumeModifier);
                gameManager.CreaObjectOnTheSide(cosmeticPrefabs[1], gameManager.island2x, gameManager.island2z, posY, offset);
            }
    
            if (objet.CompareTag("caisse") && selector.selection == 2)
            {
                targets = objet.gameObject.GetComponent<Targets>();
                gameManager.UpdateScore(targets.pointValue);
                Destroy(objet.gameObject);
                targetsSource.PlayOneShot(goodSound, gameManager.volume * volumeModifier);
                gameManager.CreaObjectOnTheSide(cosmeticPrefabs[2], -gameManager.island2x, gameManager.island2z, posY, offset);
            }

            if (objet.CompareTag("baril") && selector.selection == 3)
            {
                targets = objet.gameObject.GetComponent<Targets>();
                gameManager.UpdateScore(targets.pointValue);
                Destroy(objet.gameObject);
                targetsSource.PlayOneShot(goodSound, gameManager.volume * volumeModifier);
                gameManager.CreaObjectOnTheSide(cosmeticPrefabs[3], -gameManager.island1x, gameManager.island1z, posY, offset);
            }
        }
    }

    IEnumerator MissileCollision(GameObject missile)
    {
        gameManager.LiveLost();

        ParticleSystem explosion = Instantiate(explosionParticle, missile.transform.position, gameObject.transform.rotation);
        Destroy(missile.transform.GetChild(1).gameObject);
        flameThrower.Stop();

        yield return new WaitForSeconds(5);
        Destroy(explosion.gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour
{
    private GameManager gameManager;

    public GameObject particleIndicatorObject;

    public int selection = -1;
    private int prevSel = -1;

    public float particlePosY1;
    public float particlePosY2;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = gameObject.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.gameActive)
        {
            if (gameManager.input0)
            {
                selection = 0;

                DoNewParticle(gameManager.island1x, particlePosY1, gameManager.island1z);
            }

            else if (gameManager.input1)
            {
                selection = 1;
                DoNewParticle(gameManager.island2x, particlePosY2, gameManager.island2z);
            }

            else if (gameManager.input2)
            {
                selection = 2;
                DoNewParticle(-gameManager.island2x, particlePosY2, gameManager.island2z);
            }

            else if (gameManager.input3)
            {
                selection = 3;
                DoNewParticle(-gameManager.island1x, particlePosY1, gameManager.island1z);
            }
        }
        
    }

    void DoNewParticle(float posX, float posY, float posZ)
    {
        if (selection != prevSel)
        {
            prevSel = selection;

            StartCoroutine(NewSelectionIndicator(posX, posY, posZ));
        }
    }

    IEnumerator NewSelectionIndicator(float posX, float posY, float posZ)
    {
        GameObject particuleObject = Instantiate(particleIndicatorObject, new Vector3(posX, posY, posZ), transform.rotation);
        yield return new WaitForSeconds(2);

        Destroy(particuleObject);
    }
}

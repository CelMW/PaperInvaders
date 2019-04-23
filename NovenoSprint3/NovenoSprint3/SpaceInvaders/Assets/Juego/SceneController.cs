using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    //VARIABLES
    public GameObject player;
    public GameObject enemies;
    public GameObject score;
    public GameObject MalisimoParent;
    public GameObject FondoChild;

    public bool isInputEnable = true;
    bool finished;
    Vector3 pos = new Vector3(0, 0, 5.4f);
    void Start()
    {
        if (ScenesController.childMode)
        {
            Instantiate(FondoChild, pos, Quaternion.identity);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.LoadLevel("Menu");
            ScenesController.childMode = false;
        }
        if (!finished)
        {
            if (player != null && player.GetComponent<PersonajeController>().vidas == 0) gameOver();
            if (enemies.GetComponent<EnemiesController>().numeroMarcianos == 0) youWon();
        }       
    }

    void gameOver()
    {
        player.GetComponent<Explosion>().explode();
        Destroy(player.transform.gameObject);      
        Destroy(enemies.transform.gameObject);
        if (MalisimoParent.GetComponent<MaloParent>().destroyHijo())
        {
            Destroy(MalisimoParent.transform.gameObject);
        }
            final();
    }

    void youWon()
    {
        player.GetComponent<Explosion>().explode();
        final();
    }

    void final()
    {
        finished = true;
        score.SetActive(true);
    }
}

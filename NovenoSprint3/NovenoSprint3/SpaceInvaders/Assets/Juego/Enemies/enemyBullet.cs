using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Este script contiene el movimiento de la bala
 * 
 * */

public class enemyBulletController : MonoBehaviour
{
    // Start is called before the first frame update
    //Variables
    public float speed = 1f;
    int rebotes = 0;
    int abajo = 1;
    public bool rebot;

    void Start()
    {
        if (rebot) rebotes = 20;
        //GetComponent<Rigidbody>().AddForce(Vector3.down * speed, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if((transform.position.y > 11f || transform.position.y < -11f) && rebotes < 5) { abajo = -abajo; rebotes++; }
        transform.position += Vector3.down * speed*abajo;

        if (transform.position.y < -20f || transform.position.y > 20f)
        {
            Destroy(this.transform.gameObject);
        }
    }
    public void rebotando()
    {
        rebot = !rebot;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Este Script contiene el movimiento de la bala
 * 
 * */

public class ShotController : MonoBehaviour
{
    //VARIABLES
    float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate (Vector3.up * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("limite"))
        {
            Destroy(this.transform.gameObject);
        }
    }
}
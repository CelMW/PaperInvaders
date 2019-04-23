using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Este script contiene el movimiento de la bala
 * 
 * */

public class enemyBulletController : MonoBehaviour
{
    //Boolean Boton
    public static bool reboteactivado=false;
    // Start is called before the first frame update
    //Variables
    public float speed = 1f;
    int rebotes = 0;
    int abajo = 1;

    void Start()
    {
        
        //GetComponent<Rigidbody>().AddForce(Vector3.down * speed, ForceMode.Impulse);
    }
    public void cambiarebote()
    {
        if (reboteactivado)
        {
            reboteactivado = false;
        }
        else
        {
            reboteactivado = true;
        }
        Debug.Log("Me ejecuto" + reboteactivado);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if((transform.position.y > 11f || transform.position.y < -11f) && (rebotes < 5 )&&(reboteactivado)) { abajo = -abajo; rebotes++; }
        transform.position += Vector3.down * speed*abajo;

        if (transform.position.y < -20f || transform.position.y > 20f)
        {
            Destroy(this.transform.gameObject);
        }
    }
}

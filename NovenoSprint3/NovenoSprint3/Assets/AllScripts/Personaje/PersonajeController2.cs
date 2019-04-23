using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Este script contiene:
 * El movimiento del personaje
 * El disparo del personaje
 * La gestión de vida del personaje
 * */

public class PersonajeController2 : MonoBehaviour
{




    public int vidas = 1;
    public GameObject sceneController;

    //VARIABLES
    //Movimiento
    private float speed = 0.5f;
    private float decelerationSpeed = 0.5f;
    Vector3 position = new Vector3(0f, -9f, 0f); //posicion inicial
    Rigidbody rb;
    private float xmax=15;
    private float ymax=7;
    private float xmin=-15;
    private float ymin=-9.45f;

    //Disparo
    public GameObject shot;
    public Transform shotSpawn;
    private float fireRate = 0.5f;
    private float nextFire = 0f;

    //Impulso
    float impulse = 10f;
    float impulseRate = 3f;
    float nextImpulse = 0f;
    public Animator anim;

    //VARIABLES RANKING
    public GameObject ScoreMan;



    void Start()
    {
        transform.position = position;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        enableShot();
        move();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("EnemyBullet") || collision.gameObject.tag.Equals("enemy") || collision.gameObject.tag.Equals("Malisimo"))
        {
            //Ranking
            ScoreMan.GetComponent<ActualizarScore>().almacenarscore();
            ScoreMan.GetComponent<ActualizarScore>().top();
            //Ranking
            Destroy(collision.gameObject);
            
            vidas--;
        }
    }

    /*
    private void FixedUpdate()
    {
 
        transform.Translate(0, Input.GetAxis("Vertical") * speed, 0);

      
         transform.Translate(Input.GetAxis("Horizontal") * speed,0 , 0);


        if (Input.GetKey(KeyCode.Space))
        {
            impulso();
            transform.Translate(Input.GetAxis("Horizontal") * speed*2, 0, 0);
        }

        GetComponent<Rigidbody>().position = new Vector3
        (Mathf.Clamp(GetComponent<Rigidbody>().position.x, xmin, xmax), Mathf.Clamp(GetComponent<Rigidbody>().position.y,ymin,ymax),
        GetComponent<Rigidbody>().position.z);
    }
    */
    
    void move()
    {
        //ACELERACION
        if (Input.GetKey(KeyCode.W) && transform.position.y < 11f)
        {
            rb.AddForce(Vector3.up * speed, ForceMode.Impulse);
            // transform.position += Vector3.up * speed;
           
        }

        if (Input.GetKey(KeyCode.S) && transform.position.y > -11f)
        {
            rb.AddForce(Vector3.down * speed, ForceMode.Impulse);
            //transform.position += Vector3.down * speed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector3.left * speed, ForceMode.Impulse);
           // transform.position += Vector3.left * speed;
        }

        if (Input.GetKey(KeyCode.D))
        {
             rb.AddForce(Vector3.right * speed, ForceMode.Impulse);
           // transform.position += Vector3.right * speed;
        }

        //DECELERACION
        if (Input.GetKeyUp(KeyCode.W))
        {
            rb.velocity = Vector3.Lerp(rb.velocity, new Vector3(rb.velocity.x, 0, rb.velocity.z), decelerationSpeed);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            rb.velocity = Vector3.Lerp(rb.velocity, new Vector3(rb.velocity.x, 0, rb.velocity.z), decelerationSpeed);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            rb.velocity = Vector3.Lerp(rb.velocity, new Vector3(0, rb.velocity.y, rb.velocity.z), decelerationSpeed);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            rb.velocity = Vector3.Lerp(rb.velocity, new Vector3(0, rb.velocity.y, rb.velocity.z), decelerationSpeed);
        }

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextImpulse)
        {
            nextImpulse = Time.time + impulseRate;
            impulso();
        }
    }


    void enableShot()
    {
        //DISPARO
        if (Input.GetKey(KeyCode.Return) && Time.time > nextFire && !ScenesController.childMode)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }
    }

    public void impulso()
    {
        rb.AddForce(rb.velocity.normalized * impulse, ForceMode.Impulse);

        if (rb.velocity.x < 0) anim.Play("impulseAnimation");
        else anim.Play("impulseAnimationRight");
    }
}

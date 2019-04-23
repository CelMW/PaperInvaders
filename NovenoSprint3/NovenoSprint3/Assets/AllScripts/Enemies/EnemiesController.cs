using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * Este Script contiene:
 * Creacion/Spawn de los enemigos
 * Movimiento de los enemigos
 * */

public class EnemiesController : MonoBehaviour
{
    //VARIABLE CONTROL MUERTE PARA SCOREEEEEES
    public GameObject ControlScore;
    bool hecho = false;
    //VARIABLE CONTROL MUERTE PARA SCOREEEEEES


    //VARIABLES PARA EL CAMBIO DE COLOR
    public Color[] dispo = { Color.magenta, Color.red ,Color.white,Color.cyan,Color.blue,Color.black};
    public List<GameObject> mars;

    //Variables
    public GameObject enemy;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;
    GameObject e;
    public GameObject[,] enemies;
    public Animator anim;
    public GameObject animParent;

    Vector3 spawn = new Vector3(-17, 7, 0);
    public int filas;
    public int columnas;
    public int numeroMarcianos;

    private float speed = 2f;
    float movement;
    bool enBorde = false;
    int level = 2;

    // Start is called before the first frame update
    void Start()
    {
        init();
        createEnemies();
        transform.position += Vector3.right * speed;
        animParent.transform.position += Vector3.right * speed;
        animParent.transform.position = transform.position;
        InvokeRepeating("moveEnemies", movement, movement);
    }

    //INICIALIZACION DE FILAS, COLUMNAS, MOVEMENT Y ARRAY DEPENDIENDO DEL LEVEL
    void init()
    {
        if (level == 1)
        {
            filas = 3;
            columnas = 8;
            movement = 3f;
        }

        if (level == 2)
        {
            filas = 4;
            columnas = 8;
            movement = 2f;
        }

        if (level == 3)
        {
            filas = 5;
            columnas = 8;
            movement = 1f;
        }
        enemies = new GameObject[filas, columnas];
        numeroMarcianos = filas * columnas;
    }


    //CAMBIO DE COLOR
    public void cambioColor(bool sim)
    {
        Color cor;
        if (sim == false) {
            GameObject cebo = mars[0].GetComponent<EnemyController>().cabeza;
            do { 
            cor = dispo[(int)(Random.value * 6)];
            }while(cor==cebo.GetComponent<Renderer>().material.color);

        // Si es solo una colision
            foreach (GameObject enemy in mars)
        {

                GameObject cachola = enemy.GetComponent<EnemyController>().cabeza;
                cachola.GetComponent<Renderer>().material.color = cor;

                
         

        }
        }
        else { 
        //Si son dos a la vez:
        foreach (GameObject enemy in mars)
        {

            GameObject cachola = enemy.GetComponent<EnemyController>().cabeza;
            cachola.GetComponent<Renderer>().material.color = dispo[(int)(Random.value * 6)];
               



        }


        }
      


    }
    //CAMBIO DE COLOR




    //CREACION, SPAWN Y ASIGNACION DEL PADRE DE LOS ENEMIGOS
    void createEnemies()
    {
        for (int i = 0; i < filas; i++)
        {
            for (int j = 0; j < columnas; j++)
            {
                switch (i)
                {
                    case 0:
                        e = Instantiate(enemy, spawn, Quaternion.identity) as GameObject;
                        break;
                    case 1:
                        e = Instantiate(enemy4, spawn, Quaternion.identity) as GameObject;
                        break;
                    case 2:
                        e = Instantiate(enemy2, spawn, Quaternion.identity) as GameObject;
                        break;
                    case 3:
                        e = Instantiate(enemy3, spawn, Quaternion.identity) as GameObject;
                        break;
                    default:
                        break;
                }
                
                e.GetComponent<Transform>().SetParent(this.transform);
                e.GetComponent<EnemyController>().fila = i;
                e.GetComponent<EnemyController>().columna = j;
                enemies[i,j] = e;
                spawn += Vector3.right * 3f;
                if (i == filas - 1) e.GetComponent<EnemyController>().canShoot = true;
                else e.GetComponent<EnemyController>().canShoot = false;
                //Color
                mars.Add(e);
                //Color
            }
            spawn += Vector3.down * 2f;
            spawn.x = -17;
        }
    
    }
    private void Update()
    {
        
        if ((mars.Count == 0)&&(!hecho))
        {
            ControlScore.GetComponent<ActualizarScore>().almacenarscore();
            ControlScore.GetComponent<ActualizarScore>().top();
            
            hecho = true;
        }
        
    }
    //MOVIMIENTO DE LOS ENEMIGOS
    void moveEnemies()
    {
        foreach (GameObject enemy in enemies)
        {
            if (enemy != null) enBorde |= enemy.gameObject.GetComponent<EnemyController>().enBorde;
        }
        if (enBorde) //Si estamos en el borde...
        {
            anim.Play("enemiesMovementBottom");
            new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);
            animParent.transform.position = transform.position;
            speed *= -1;
            enBorde = false;
            foreach (GameObject enemy in enemies)
            {
                if (enemy != null) enemy.GetComponent<EnemyController>().enBorde = false;
            }
        }
        else
        {           
            if (speed>0) anim.Play("enemiesMovementRight"); 
            if (speed<0) anim.Play("enemiesMovementLeft");
            new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);
            //animParent.transform.position += Vector3.right * speed;
            animParent.transform.position = transform.position;
        }
    }
}
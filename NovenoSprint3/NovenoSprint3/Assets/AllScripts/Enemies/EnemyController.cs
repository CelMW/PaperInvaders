using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Este script contiene:
 * Gestiion de los disparos
 * Muerte al colisionar con PlayerShot y ShotLegacy al morir
 * Trigger con el limite
 * */


public class EnemyController : MonoBehaviour
{ 
    
    //VARIABLES
    public GameObject enemies;
    //VARIABLES PARA EL CAMBIO DE COLOR
    public GameObject cabeza;
    public List<GameObject> mars2;
    public GameObject explosion;
    //Color
   

    //Disparo
    public GameObject enemyBullet;
    public bool canShoot = false;   
    float minFireRate = 1f;
    float maxFireRate = 30f;
    float nextFire = 10f;
    int timerel;
    //Para administrar la fila y la columna de cada uno
    public int fila;
    public int columna;
    public bool enBorde = false;

    // Start is called before the first frame update
    void Start()
    {
       
        enemies = GameObject.FindGameObjectWithTag("EnemiesIA");
      
        nextFire = Random.Range(minFireRate, maxFireRate);

        timerel =(int) Time.time;




        //Color
        mars2 = enemies.GetComponent<EnemiesController>().mars;
        //Color
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
        
    }

    //PASO DE CANSHOOT AL MARCIANO DE ARRIBA
    void shootLegacy()
    {
        if (fila == enemies.gameObject.GetComponent<EnemiesController>().filas-1 && enemies.gameObject.GetComponent<EnemiesController>().enemies[fila - 1, columna])
            enemies.gameObject.GetComponent<EnemiesController>().enemies[fila - 1, columna].GetComponent<EnemyController>().canShoot = true;

        if (fila < enemies.gameObject.GetComponent<EnemiesController>().filas - 1 && fila > 0 && enemies.gameObject.GetComponent<EnemiesController>().enemies[fila + 1, columna] == null)
        {
            if (enemies.gameObject.GetComponent<EnemiesController>().enemies[fila - 1, columna] != null)
                enemies.gameObject.GetComponent<EnemiesController>().enemies[fila - 1, columna].GetComponent<EnemyController>().canShoot = true;
            else if (fila > 1 && enemies.gameObject.GetComponent<EnemiesController>().enemies[fila - 1, columna] == null)
                enemies.gameObject.GetComponent<EnemiesController>().enemies[fila - 2, columna].GetComponent<EnemyController>().canShoot = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("PlayerShot") || collision.gameObject.tag.Equals("EnemyBullet") || collision.gameObject.tag.Equals("PlayerLaser"))
        {
            //Si es el laser no lo destruye
            if (collision.gameObject.tag.Equals("PlayerShot") || collision.gameObject.tag.Equals("EnemyBullet")) { 
                Destroy(collision.gameObject);
            }
            shootLegacy();
            Instantiate(explosion, transform.position + new Vector3(0,0,-5), transform.rotation);
            scoreTextController.score += 100;
            enemies.GetComponent<EnemiesController>().numeroMarcianos--;
            //Color
            mars2.Remove(this.gameObject);
            //Color
            Destroy(this.gameObject);
        }
        
    }
  
    private void OnTriggerEnter(Collider obj)
    {
        if (obj.gameObject.tag.Equals("EnemyLimit"))
        {
            enBorde = true;
        }
    }

 void Shoot()
    {
        if (canShoot && nextFire < Time.time-timerel && !ScenesController.childMode)
        {
            nextFire = Time.time + Random.Range(minFireRate, maxFireRate);
            Instantiate(enemyBullet, transform.position + Vector3.down + Vector3.back, transform.rotation);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaloController : MonoBehaviour
{

    //Variables
    private float speed = 0.15f;
    public GameObject enemyBullet;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Shoot",1f,1f); //Dispara cada segundo
    }

    // Update is called once per frame
    void Update()
    {
       transform.position += Vector3.right * speed;
       if(transform.position.x > 24f)
        {
            Destroy(transform.gameObject); //Destruye el malisimo cuando sale de la escena
            
        } 
       
    }
    

    void Shoot()
    {
        if (!ScenesController.childMode)
        {
            Instantiate(enemyBullet, transform.position + Vector3.down + Vector3.back, Quaternion.identity);
        }
            
    }

    //Destruye el malisimo si colisiona, suma al marcador 500 puntos.
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("PlayerShot"))
        {
            Destroy(collision.gameObject);
            scoreTextController.score += 500;
            GetComponent<Explosion>().explode();
            Destroy(this.gameObject);
        }
    }

}

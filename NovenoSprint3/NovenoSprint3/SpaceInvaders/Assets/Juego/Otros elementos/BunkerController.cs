using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunkerController : MonoBehaviour
{

    //VARIABLES PARA EL CAMBIO DE COLOR
    public GameObject enemies;
    public int tiempo;
    static List<int> contactstime = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        tiempo = (int)Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        int index = (int)Time.time-tiempo;
        if (contactstime.Count < index) { 
        contactstime.Add(0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Cambio color
        int index = (int)Time.time-tiempo;
        //Cambio color
      

        if (!(collision.gameObject.tag.Equals("Player") || collision.gameObject.tag.Equals("Particle") || collision.gameObject.tag.Equals("enemy")))
        {
            //CAMBIO DE COLOR
           
           
            contactstime[(index-1)]++;
            

            bool simultaneo = false;
            if (contactstime[(index-1)] > 1)
            {
                simultaneo = true;
            }
           
            enemies.GetComponent<EnemiesController>().cambioColor(simultaneo);
            //CAMBIO DE COLOR
            Destroy(collision.gameObject);
            GetComponent<Explosion>().explode();          
            Destroy(this.transform.gameObject);
        }

        if (collision.gameObject.tag.Equals("enemy"))
        {
            //CAMBIO DE COLOR
           
            
                contactstime[(index-1)]++;
            


            bool simultaneo = false;
            if (contactstime[(index-1)] > 1)
            {
                simultaneo = true;
            }
            enemies.GetComponent<EnemiesController>().cambioColor(simultaneo);
            //CAMBIO DE COLOR


            GetComponent<Explosion>().explode();
            
            Destroy(this.transform.gameObject);
        }
      
       


        
    }
}

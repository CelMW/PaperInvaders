using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaloParent : MonoBehaviour
{
    //Variables
    public GameObject Malisimo;
    public GameObject enemy;
    public GameObject m;

    Vector3 pos = new Vector3(-24, 9, 0);
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("createMalisimo", 10f, 10f); //Invoca al malisimo cada 10 segundos
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }


    void createMalisimo() //Crea el malisimo desde la izquierda
    {
        m = Instantiate(Malisimo, pos, Quaternion.identity) as GameObject;
        
    }

    public bool destroyHijo()
    {
        Destroy(m.transform.gameObject);
        return true;
    }
    
}

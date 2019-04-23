using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.L)){
            Debug.Log("Se ha activado el laser");
            PersonajeController.laser = true;
            Destroy(this.gameObject);
        }
    }
}

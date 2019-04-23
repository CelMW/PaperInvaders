using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPausa : MonoBehaviour
{
    public GameObject menu;
    public GameObject boton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Pausar()
    {
       
           
           if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
            menu.SetActive(true);
           boton.SetActive(false);
            }
            //(Des)Habilitar interfaz
        }
    }


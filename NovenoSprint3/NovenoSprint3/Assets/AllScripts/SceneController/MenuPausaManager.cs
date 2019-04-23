using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPausaManager : MonoBehaviour
{
    public GameObject botonp;
    public GameObject panel;
    public void Reanudar() {
        botonp.SetActive(true);
        panel.SetActive(false);
        Time.timeScale = 1;
    }
    public void Salir() {
        Application.Quit();
    }
    public void MenuPrin() {
        Application.LoadLevel("Menu");
    }
    public void Tutorial() { }
    public void VolumenMas() { }
    public void VolumenMenos() { }


}





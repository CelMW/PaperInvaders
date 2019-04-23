using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActualizarScore : MonoBehaviour
{
    static public Jugadores lista;
    static public Jugador actual;
    public Text Top10;
    public GameObject mej;
    // Start is called before the first frame update
    void Start()
    {
        lista = Playersman.lista;
        actual = Playersman.Actual;
    }
    public void almacenarscore()
    {
        Jugador busca;
        if (actual.nombre == null) {
            busca = lista.Requerido(new Jugador("Jaimito"));
            if (busca == null)
            {
                Jugador nuevo = new Jugador("Jaimito");
                lista.Todos.Add(nuevo);
                 busca = lista.Requerido(nuevo); 
            }
        }
        else
        {
             busca = lista.Requerido(actual);
           
        }
  
        busca.addScore(scoreTextController.score);
        
        Playersman.Guarda();
    }
    public void top()
    {
        mej.SetActive(true);
        string best = "Top 10: \n";
        List < Scores > mejores= lista.top10();
        foreach(Scores j in mejores)
        {
            best =  best + j.nombre + " : " + j.puntuación + " \n";
        }
        
        Top10.text = best;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

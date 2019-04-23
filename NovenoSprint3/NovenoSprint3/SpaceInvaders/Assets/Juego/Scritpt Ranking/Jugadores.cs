using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
//Arbol de conversación
public class Scores
{
    public string nombre;
    public int puntuación;

    public Scores(string n, int p)
    {
        nombre = n;
        puntuación = p;
    }
}
[System.Serializable]
public class Jugadores {
    public List<Jugador> Todos;

    public Jugadores()
    {
        Todos = new List<Jugador>();
    }
    public Jugador Requerido(Jugador n)
    {
        
     foreach(Jugador u in Todos){
            if (u.equals(n))
            {
                return u;
            }
        }
        return null;
    }
    public List <Scores> top10()
    {
        List<Scores> punt = new List<Scores>();
      foreach(Jugador j in Todos)
        {
        foreach(int i in j.puntuaciones)
            {
                punt.Add(new Scores(j.nombre, i));
            }
        }
        compScore cp = new compScore();
        punt.Sort(cp);
        punt.Reverse();
        if (punt.Count < 10)
        {
            return punt;
        }
        else
        {
            return punt.GetRange(0, 10);
        }
       
    }
    public Jugador entrarjugador(string nom)
    {
        Jugador nuevo = new Jugador(nom);
        Jugador usu = Requerido(nuevo);
        if (usu!=null) {
           int index =Todos.IndexOf(usu);
          
            return usu;
            
        }
        else
        {
            Todos.Add(nuevo);
            string jugador = "Jugador" + Todos.IndexOf(nuevo);
            //PlayerPrefs.SetString(jugador, nuevo.nombre);

            return nuevo;
        }
        
    }

}
[System.Serializable]
public class Jugador {
    public string nombre;
    public List<int> puntuaciones;

    public Jugador(string n)
    {
        nombre = n;
        puntuaciones = new List<int>();
    }
    public void addScore(int s)
    {
        puntuaciones.Add(s);
    }
  

    public void OrdenarScores(){

        puntuaciones.Sort();
    }

    

    public bool equals(Jugador n)
    {
        if (n == null)
        {
            return false;
        }
        else { 
        if (n.nombre.Equals(nombre))
        {
            return true;
        }
        else
        {
            return false;
        }
        }
    }
}
public class compScore : IComparer<Scores>
{
    public int Compare(Scores a, Scores b)
    {
        return a.puntuación.CompareTo(b.puntuación);
    }
}






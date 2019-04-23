using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

public class Playersman : MonoBehaviour
{
    static public Jugadores lista= new Jugadores();
    public Text nombre;
    public Text Uipantalla;
 
    public Text ScoresUI;
    static public Jugador Actual = new Jugador(null);
   public Button ok;

    // Start is called before the first frame update
    public static void Guarda()
    {
        foreach (int i in Actual.puntuaciones)
        {
           
        }
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/Scores.gd");
        bf.Serialize(file, lista);
            file.Close();
        


    }
    public static void Cargar()
    {
        if (File.Exists(Application.persistentDataPath + "/Scores.gd"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/Scores.gd", FileMode.Open);
            lista = (Jugadores)bf.Deserialize(file);
            file.Close();
        }
        else
        {
            lista = new Jugadores();
        }
    }

    public void Scores()
    {
        string textscores = "";
     foreach(Jugador j in lista.Todos)
        {
         foreach(int i in j.puntuaciones)
            {
                textscores = textscores + j.nombre + " : " + i + " \n";
            }
        }
        ScoresUI.text = textscores;
    }
    public void Ok()
    {


        Actual = lista.entrarjugador(nombre.text.ToString());
        Guarda();
        Uipantalla.text = Actual.nombre;


    }
    void Start()
    {

        Cargar();
       
  
   
    }

    // Update is called once per frame
 
}
    


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.iOS;

public abstract class Observer : MonoBehaviour
{
    public abstract void OnNotify(object value, TipoNot.TipoNotificacion nt);
}
public abstract class Subject : MonoBehaviour
{
    private List<Observer> observers = new List<Observer>();
    // Start is called before the first frame update
   public void RegisterObserver(Observer obs)
    {
        observers.Add(obs);
    }

    // Update is called once per frame
    public void Notify(object value, TipoNot.TipoNotificacion nt)
    {
        foreach(var ob in observers)
        {
            ob.OnNotify(value, nt);
        }
    }
}

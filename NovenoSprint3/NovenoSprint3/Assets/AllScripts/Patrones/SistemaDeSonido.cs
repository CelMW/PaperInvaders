using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.iOS;

public class SistemaDeSonido : Observer
{

    public List<AudioSource> sonidos = new List<AudioSource>();

        
    
  
    // Start is called before the first frame update
    private void Start()
    {
        
        foreach(var p in FindObjectsOfType<Subject>())
        {
            p.RegisterObserver(this);
        }
    }

    public override void OnNotify(object value, TipoNot.TipoNotificacion nt)
    {
        if ( nt == TipoNot.TipoNotificacion.disparo)
        {
            sonidos[1].Play();
        }
        if (nt == TipoNot.TipoNotificacion.aceleracion)
        {
            sonidos[3].Play();
        }
        if (nt == TipoNot.TipoNotificacion.click)
        {
            sonidos[0].Play();
        }
        if ( nt == TipoNot.TipoNotificacion.subirvol)
        {
        foreach( AudioSource a in sonidos)
            {
                
                a.volume= a.volume +0.1f;
            
            }
        }
        if(nt == TipoNot.TipoNotificacion.muerte)
        {
            sonidos[4].Play();
        }
        if (nt == TipoNot.TipoNotificacion.bajarvol)
        {
            foreach (AudioSource a in sonidos)
            {
                a.volume = a.volume - 0.1f;
               
            }
        }
        return;
        throw new System.NotImplementedException();
    }




    // Update is called once per frame
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfectosDeSonido : Subject
{
    private float nextFire = 0f;
    private float fireRate = 0.5f;
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Notify(null, TipoNot.TipoNotificacion.aceleracion);
        }
        if ((Input.GetKey(KeyCode.Return))&& (Time.time > nextFire))
        {
            Notify(null, TipoNot.TipoNotificacion.disparo);
            nextFire = Time.time + fireRate;
        }

    }
}

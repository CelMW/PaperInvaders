using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointOfInterest : Subject
{
    [SerializeField]
    public string poiName;
 
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(poiName);
        if (poiName.Equals("Personaje")&& (collision.gameObject.tag.Equals("EnemyBullet") || collision.gameObject.tag.Equals("enemy") || collision.gameObject.tag.Equals("Malisimo")))
            {
            Notify(null, TipoNot.TipoNotificacion.muerte);
        }
        else if(poiName.Equals("Enemy")&&((collision.gameObject.tag.Equals("PlayerShot") || collision.gameObject.tag.Equals("EnemyBullet") || collision.gameObject.tag.Equals("PlayerLaser"))))
            {
            Notify(null, TipoNot.TipoNotificacion.muerte);
        }
        else if( (poiName.Equals("Malisimo"))&& (collision.gameObject.tag.Equals("PlayerShot")))
        {
            Notify(null, TipoNot.TipoNotificacion.muerte);
        }
        else if (poiName.Equals("Bunker")&& ((collision.gameObject.tag.Equals("PlayerShot") || collision.gameObject.tag.Equals("PlayerLaser") || collision.gameObject.tag.Equals("EnemyBullet"))))
            {
            Notify(null, TipoNot.TipoNotificacion.muerte);
        }
    }
}

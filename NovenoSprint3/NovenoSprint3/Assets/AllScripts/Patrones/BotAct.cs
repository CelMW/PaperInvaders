using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotAct : Subject
{
   public void ActivarSonido()
    {
        Notify(null, TipoNot.TipoNotificacion.click);
    }
    public void SubirVolumen()
    {
        Notify(null, TipoNot.TipoNotificacion.subirvol);
    }
    public void BajarVolumen()
    {
        Notify(null, TipoNot.TipoNotificacion.bajarvol);
    }
}

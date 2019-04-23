using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GifController : MonoBehaviour
{
    public Texture2D[] frames;
    public int fps = 24;
    public bool pausa;
    public GameObject gif;
    int contpaus = 0;
    float tiempo;
    int index;
    // Start is called before the first frame update
   
        void Start()
    {
            
        tiempo = Time.time;
    }
    // Update is called once per frame
    void Update()
            
    {
        
       
        if (!pausa)
        {

             index = (int)(Time.time * fps) % frames.Length;
            if (Time.time - tiempo > 6)
            {
                Application.LoadLevel("EscenaPrincipal");
            }
        }
        else
        {
            index = contpaus%frames.Length;
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                gif.SetActive(false);
            }
            contpaus++;
        }
          GetComponent<RawImage>().texture = frames[index];
    }
}

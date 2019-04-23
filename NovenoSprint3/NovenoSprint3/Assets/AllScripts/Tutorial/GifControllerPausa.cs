using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GifControllerPausa : MonoBehaviour
{
    public Texture2D[] frames;
    public int fps = 24;
    float tiempo;
    // Start is called before the first frame update
   
        void Start()
    {
        tiempo = Time.time;
    }
    // Update is called once per frame
    void Update()
    {
        int index = (int)(Time.time * fps) % frames.Length;
        GetComponent<RawImage>().texture = frames[index];
      
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleController : MonoBehaviour
{
    //Variables
    public Color lerpColor = Color.white;
    public Color firstColor;
    public Color secondColor;
    public float colorTransition;

    public float time = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lerpColor = Color.Lerp(firstColor, secondColor, Mathf.PingPong(Time.time, colorTransition));
        GetComponent<Renderer>().material.color = lerpColor;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Player") || collision.gameObject.tag.Equals("Bunker"))
        {
            Destroy(this.transform.gameObject);
        }
    }
}


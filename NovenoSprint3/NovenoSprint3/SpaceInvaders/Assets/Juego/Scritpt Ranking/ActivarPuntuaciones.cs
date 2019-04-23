using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarPuntuaciones : MonoBehaviour
{
    public GameObject scrollview;
    public GameObject playman;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("PlayerShot"))
        {
            scrollview.SetActive(true);
            playman.GetComponent<Playersman>().Scores();
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape)){
            scrollview.SetActive(false);
        }
        
    }
}

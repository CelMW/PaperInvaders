using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreTextController : MonoBehaviour
{
    public static int score;
    public GameObject scoreText;

    private void Awake()
    {
        score = 0;
    }
    private void Update()
    {
        scoreText.GetComponent<UnityEngine.UI.Text>().text = " Score: \n" + score;
    }
}

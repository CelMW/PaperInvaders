using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    //Variables
    public float cubeSize = 0.2f;
    public int cubesInRow = 5;
    public float explosionRadius = 4f;
    public float explosionForce = 100;
    public float explosionUpward = 0.4f;
    GameObject[,,] particles;

    float cubesPivotDistance;
    Vector3 cubesPivot;

    public GameObject particle;

    public Color lerpColor = Color.white;
    public Color firstColor;
    public Color secondColor;
    public float colorTransition;

    void Start()
    {
        //Calculate pivot distance
        cubesPivotDistance = cubeSize * cubesInRow / 2;
        //Use this value to create pivot vector
        cubesPivot = new Vector3(cubesPivotDistance, cubesPivotDistance, cubesPivotDistance);
        particles = new GameObject[cubesInRow, cubesInRow, cubesInRow];
    }

    public void explode()
    {
        gameObject.SetActive(false);

        //Loop 3 times and create a cubesInRow*cubesInRow*cubesInRow pieces in x,y,z coordinates
        for (int x = 0; x < cubesInRow; x++)
        {
            for (int y = 0; y < cubesInRow; y++)
            {
                for (int z = 0; z < cubesInRow; z++)
                {
                    createPiece(x, y, z);
                }
            }
        }

        //Get explosion position
        Vector3 explosionPos = transform.position;
        //Get colliders in that position and radius
        Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);
        //Add explosion force to al colliders in the overlap Sphere
        foreach(Collider hit in colliders)
        {
            //Get rigidbody from collider object
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                //add explosion force to this body with given parameters
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, explosionUpward);
            }
        }
    }

    void createPiece(int x, int y, int z)
    {
        //Create piece
        GameObject piece;
        piece = GameObject.Instantiate(particle);
        piece.GetComponent<particleController>().firstColor = firstColor;
        piece.GetComponent<particleController>().secondColor = secondColor;
        piece.GetComponent<particleController>().colorTransition = colorTransition;
        piece.GetComponent<particleController>().lerpColor = lerpColor;

        //GameObject.CreatePrimitive(PrimitiveType.Sphere);
        particles[x, y, z] = piece;
        piece.SetActive(true);

        //Set piece position and scale
        piece.transform.position = transform.position + new Vector3(cubeSize * x, cubeSize * y, cubeSize * z) - cubesPivot;
        piece.transform.localScale = new Vector3(cubeSize, cubeSize, cubeSize);

        //Add rigidbody and set mass
        piece.AddComponent<Rigidbody>();
        piece.GetComponent<Rigidbody>().mass = cubeSize;

        //piece.GetComponent<Renderer>().material.color = lerpColor;
    }
}

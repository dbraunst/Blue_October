using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    static public int numSources = 9;

    LayerMask mask = -2; //raycast ignores layer 2

    private float maxRayDist = 100.0f;

    public RaycastHit hit;

    public float[] distanceToWall = new float[numSources];
    public Vector3[] hitLocations = new Vector3[numSources];

    // Start is called before the first frame update
    void Awake()
    {
        getRaycasthits();
    }

    // Update is called once per frame
    void Update()
    {
        getRaycasthits();
    }

    void getRaycasthits()
    {

        // Left
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit, maxRayDist))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * hit.distance, Color.cyan);
            distanceToWall[0] = hit.distance;
            hitLocations[0] = hit.point;
            //Debug.Log("Did Hit");
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * 200, Color.white);
            //Debug.Log("Did not Hit");
        }

        // Right
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, maxRayDist))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.magenta);
            distanceToWall[1] = hit.distance;
            hitLocations[1] = hit.point;
            //Debug.Log("Did Hit");
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * 200, Color.white);
            //Debug.Log("Did not Hit");
        }

        // Left Front
        if (Physics.Raycast(transform.position, transform.TransformDirection(-1, 0, 1), out hit, maxRayDist))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(-1, 0, 1) * hit.distance, Color.cyan);
            distanceToWall[2] = hit.distance;
            hitLocations[2] = hit.point;
            //Debug.Log("Did Hit");
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(-1, 0, 1) * 200, Color.white);
            //Debug.Log("Did not Hit");
        }

        // Right Front
        if (Physics.Raycast(transform.position, transform.TransformDirection(1, 0, 1), out hit, maxRayDist))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(1, 0, 1) * hit.distance, Color.magenta);
            distanceToWall[3] = hit.distance;
            hitLocations[3] = hit.point;
            //Debug.Log("Did Hit");
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(1, 0, 1) * 200, Color.white);
            //Debug.Log("Did not Hit");
        }

        // Left Back
        if (Physics.Raycast(transform.position, transform.TransformDirection(-1, 0, -1), out hit, maxRayDist))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(-1, 0, -1) * hit.distance, Color.cyan);
            distanceToWall[4] = hit.distance;
            hitLocations[4] = hit.point;
            //Debug.Log("Did Hit");
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(-1, 0, -1) * 200, Color.white);
            //Debug.Log("Did not Hit");
        }

        // Right Back
        if (Physics.Raycast(transform.position, transform.TransformDirection(1, 0, -1), out hit, maxRayDist))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(1, 0, -1) * hit.distance, Color.magenta);
            distanceToWall[5] = hit.distance;
            hitLocations[5] = hit.point;
            //Debug.Log("Did Hit");
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(1, 0, -1) * 200, Color.white);
            //Debug.Log("Did not Hit");
        }

        // Front
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, maxRayDist))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.magenta);
            distanceToWall[6] = hit.distance;
            hitLocations[6] = hit.point;
            //Debug.Log("Did Hit");
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 200, Color.white);
            //Debug.Log("Did not Hit");
        }

        // FrontFrontLeft
        if (Physics.Raycast(transform.position, transform.TransformDirection(-1, 0, 2), out hit, maxRayDist))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(-1, 0, 2) * hit.distance, Color.magenta);
            distanceToWall[7] = hit.distance;
            hitLocations[7] = hit.point;
            //Debug.Log("Did Hit");
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(-1, 0, 2) * 200, Color.white);
            //Debug.Log("Did not Hit");
        }

        // FrontFrontRight
        if (Physics.Raycast(transform.position, transform.TransformDirection(1, 0, 2), out hit, maxRayDist))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(1, 0, 2) * hit.distance, Color.magenta);
            distanceToWall[8] = hit.distance;
            hitLocations[8] = hit.point;
            //Debug.Log("Did Hit");
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(1, 0, 2) * 200, Color.white);
            //Debug.Log("Did not Hit");
        }
    }
}
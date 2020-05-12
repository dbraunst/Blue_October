using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public GameObject player;

    public GameObject[] checkPoints;
    public int numCheckPointsHit = 0;

    //intial/end/intended position of objective
    public Vector3 finalPos;

    public float totalDistance = 0.0f;

    private Vector3 playerToCheckpoint;
    private Vector3 dir;

    void Awake()
    {
        //set final pos based on set position in scene
        finalPos = transform.position;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Start()
    {
        if (checkPoints[0] == null)
        {
            Debug.Log("Error: No Checkpoints Set");
        }

        totalDistance = getRemainingDistance(numCheckPointsHit);
    }

    //calculates the distance from each remaining checkpoint to the next until the
    //objective, returning 0 once the last checkpoint has been hit
    float getRemainingDistance(int _numCheckPointsHit)
    {
        float remainingDist = 0.0f;

        //set total distance from player to objective
        for (int i = _numCheckPointsHit; i < checkPoints.Length - 1; i++)
        {
            remainingDist += Vector3.Distance(checkPoints[i].transform.position,
                    checkPoints[i+1].transform.position);
        }
        //lastly, add distance from last checkpoint to objective
        if (numCheckPointsHit < checkPoints.Length)
        {
            remainingDist += Vector3.Distance(checkPoints[checkPoints.Length - 1].transform.position,
                    finalPos);
        }

        return remainingDist;
    }


    void Update()
    {
        //get total distance offset of objective to next checkpoint
        totalDistance = getRemainingDistance(numCheckPointsHit);

        //pivot position around the next checkpoint while remaining distanced from player
        if (numCheckPointsHit < checkPoints.Length)
        {
            //get vector3 direction between player
            dir = checkPoints[numCheckPointsHit].transform.position
                  - player.transform.position;
            dir.y = 0.0f; //make offset only on x and Z planes

            transform.position = checkPoints[numCheckPointsHit].transform.position + (dir.normalized * totalDistance);
            transform.position.Set(transform.position.x, finalPos.y, transform.position.z);
        }
        else if (numCheckPointsHit == checkPoints.Length)
        {
            transform.position = finalPos;
        }
    }


    //This function is called from CheckPointHandler.cs when player enters a
    //  trigger with the tag 'checkpoint'
    public void playerTriggerEnter(Collider other)
    {
        //if we still have checkpoints left to hit
        if (numCheckPointsHit < checkPoints.Length)
        {
            //AND if the object we hit was the next checkpoint
            if (other.gameObject == checkPoints[numCheckPointsHit])
            {
                //increment the checkpoints hit
                numCheckPointsHit++;
            }
        }
    }


    public void LoadNextLevel()
    {
        int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentLevelIndex + 1);
    }

    private void OnTriggerEnter(Collider other)
    {
        LoadNextLevel();
    }


}

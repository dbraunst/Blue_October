using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    private GameObject player = null;

    //sound source index is as follows:
    // 0: Left Wall Reflection  (-90)
    // 1: Right Wall Refelction ( 90)
    // 2: Left Front  (-45)
    // 3: Right Front ( 45)
    // 4: Left Back   (-135)
    // 5: Right Back  ( 135)
    public int soundSourceIndex = 0;

    public float absWallDistance = 8.0f;

    //v3 offset multiplier

    private Vector3 offset = Vector3.zero;
    // THOUGHTS: smarter to do offset / object managemenet via 
    // 1: predetermined sources (e.g. L, R, U, D)
    // 2: raycasts out in directions and flipping distance to wall
    // 3: ???

    private void Awake()
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        setSourceOffset();
    }

    // Update is called once per frame
    void Update()
    {
        setSourceOffset();
    }

    // set location of soundsource away from wall based on player location
    void setSourceOffset()
    {
        ///get player distance to wall based on 
        absWallDistance = Mathf.Abs(player.GetComponent<Player>().distanceToWall[soundSourceIndex]);
        
        switch (soundSourceIndex)
        {

            case 0: // left
                offset = (Vector3.left * absWallDistance) + player.GetComponent<Player>().hitLocations[0];
                transform.position = offset;
                break;
            case 1: // right
                offset = (Vector3.right * absWallDistance) + player.GetComponent<Player>().hitLocations[1];
                transform.position = offset;
                break;
            case 2: // front left
                offset = ((Vector3.left + Vector3.forward) * absWallDistance) + player.GetComponent<Player>().hitLocations[2];
                transform.position = offset;
                break;
            case 3: // front right
                offset = ((Vector3.right + Vector3.forward) * absWallDistance) + player.GetComponent<Player>().hitLocations[3];
                transform.position = offset;
                break;
            case 4: // back left
                offset = ((Vector3.left + Vector3.back) * absWallDistance) + player.GetComponent<Player>().hitLocations[4];
                transform.position = offset;
                break;
            case 5: // back right
                offset = ((Vector3.right + Vector3.back) * absWallDistance) + player.GetComponent<Player>().hitLocations[5];
                transform.position = offset;
                break;

            default:
                break;
        }
    }
}

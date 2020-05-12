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
    // 6: Front (0)
    // 7: FrontFrontLeft
    // 8: FrontFrontRight

    public int soundSourceIndex = 0;
    public float lerpSpeed = 1.7f;
    public float distance = 0.0f;

    private Vector3 dir;

    public float absWallDistance = 8.0f;


    //v3 offset multiplier

    public Vector3 offset = Vector3.zero;
    public Vector3 newOffset;
    private Vector3 lastPos;

    private Vector3 direction;
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


        GetComponent<MeshRenderer>().enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        setSourceOffsetStart();
    }

    // Update is called once per frame
    void Update()
    {
        setSourceOffset();
    }

    // set location of soundsource away from wall based on player location
    void setSourceOffsetStart()
    {
        ///get player distance to wall based on 
        absWallDistance = Mathf.Abs(player.GetComponent<Player>().distanceToWall[soundSourceIndex]);
        lastPos = transform.position;
        
        switch (soundSourceIndex)
        {

            case 0: // left
                direction = player.GetComponent<Player>().hitLocations[0] - player.transform.position;
                offset = player.GetComponent<Player>().hitLocations[0] + direction;
                transform.position = offset;
                break;
            case 1: // right
                direction = player.GetComponent<Player>().hitLocations[1] - player.transform.position;
                offset = player.GetComponent<Player>().hitLocations[1] + direction;
                transform.position = offset;
                break;
            case 2: // front left
                direction = player.GetComponent<Player>().hitLocations[2] - player.transform.position;
                offset = player.GetComponent<Player>().hitLocations[2] + direction;
                transform.position = offset;
                break;
            case 3: // front right
                direction = player.GetComponent<Player>().hitLocations[3] - player.transform.position;
                offset = player.GetComponent<Player>().hitLocations[3] + direction;
                transform.position = offset;
                break;
            case 4: // back left
                direction = player.GetComponent<Player>().hitLocations[4] - player.transform.position;
                offset = player.GetComponent<Player>().hitLocations[4] + direction;
                transform.position = offset;
                break;
            case 5: // back right
                direction = player.GetComponent<Player>().hitLocations[5] - player.transform.position;
                offset = player.GetComponent<Player>().hitLocations[5] + direction;
                transform.position = offset;
                break;
            case 6: // front
                direction = player.GetComponent<Player>().hitLocations[6] - player.transform.position;
                offset = player.GetComponent<Player>().hitLocations[6] + direction;
                transform.position = offset;
                break;
            case 7: // frontfrontleft
                direction = player.GetComponent<Player>().hitLocations[7] - player.transform.position;
                offset = player.GetComponent<Player>().hitLocations[7] + direction;
                transform.position = offset;
                break;
            case 8: // frontfrontright
                direction = player.GetComponent<Player>().hitLocations[8] - player.transform.position;
                offset = player.GetComponent<Player>().hitLocations[8] + direction;
                transform.position = offset;
                break;

            default:
                break;
        }
    }

    void setSourceOffset()
    {
        ///get player distance to wall based on 
        absWallDistance = Mathf.Abs(player.GetComponent<Player>().distanceToWall[soundSourceIndex]);
        lastPos = transform.position;

        switch (soundSourceIndex)
        {

            case 0: // left
                direction = player.GetComponent<Player>().hitLocations[0] - player.transform.position;
                offset = player.GetComponent<Player>().hitLocations[0] + direction;

                updatePositionWithinBounds(15.0f);
                break;
            case 1: // right
                direction = player.GetComponent<Player>().hitLocations[1] - player.transform.position;
                offset = player.GetComponent<Player>().hitLocations[1] + direction;

                updatePositionWithinBounds(15.0f);
                break;
            case 2: // front left
                direction = player.GetComponent<Player>().hitLocations[2] - player.transform.position;
                offset = player.GetComponent<Player>().hitLocations[2] + direction;

                updatePositionWithinBounds(15.0f);
                break;
            case 3: // front right
                direction = player.GetComponent<Player>().hitLocations[3] - player.transform.position;
                offset = player.GetComponent<Player>().hitLocations[3] + direction;

                updatePositionWithinBounds(15.0f);
                break;
            case 4: // back left
                direction = player.GetComponent<Player>().hitLocations[4] - player.transform.position;
                offset = player.GetComponent<Player>().hitLocations[4] + direction;

                updatePositionWithinBounds(15.0f);
                break;
            case 5: // back right
                direction = player.GetComponent<Player>().hitLocations[5] - player.transform.position;
                offset = player.GetComponent<Player>().hitLocations[5] + direction;

                updatePositionWithinBounds(15.0f);
                break;
            case 6: // front
                direction = player.GetComponent<Player>().hitLocations[6] - player.transform.position;
                offset = player.GetComponent<Player>().hitLocations[6] + direction;

                updatePositionWithinBounds(20.0f);
                break;
            case 7: // frontfrontleft
                direction = player.GetComponent<Player>().hitLocations[7] - player.transform.position;
                offset = player.GetComponent<Player>().hitLocations[7] + direction;

                updatePositionWithinBounds(20.0f);
                break;
            case 8: // frontfrontright
                direction = player.GetComponent<Player>().hitLocations[8] - player.transform.position;
                offset = player.GetComponent<Player>().hitLocations[8] + direction;

                updatePositionWithinBounds(20.0f);
                break;
            default:
                break;
        }
    }

    void updatePositionWithinBounds(float _maxDist)
    {
        //get total distance to soundsource
        distance = Vector3.Distance(player.transform.position, offset);
    
        if (distance > 15.0f)
        {
            //if sound is 'too far', get it's direction, normalize, and offset distance by
            // 'max distance'. Also disable the meshrenderer so it's invisible while close
            dir = offset - player.transform.position;
            offset = player.transform.position + (dir.normalized * _maxDist);

            //GetComponent<MeshRenderer>().enabled = false;   <= temporarily removed meshrenderer bit for testing purposes
        }
        //else if (!GetComponent<MeshRenderer>().enabled)
        //{
        //    //re-enable the mesh renderer if within bounds
        //    GetComponent<MeshRenderer>().enabled = true;
        //}

        //lerp position for smooth transition
        transform.position = Vector3.Lerp(lastPos, offset, Time.deltaTime * lerpSpeed);
    }
}

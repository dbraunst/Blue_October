using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sonar : MonoBehaviour
{
    public AudioSource sonarPing;
    AudioClip sonarPingClip;

    public AudioSource sonarReturn;
    AudioClip sonarReturnClip;


    public GameObject player;

    float timeDelay;
    public float arbNumber;

    void Start()
    {
        
        
    }

    void Update()
    {
        timeDelay = Vector3.Distance(player.transform.position, this.transform.position)/50;

        if (Input.GetButtonDown("Fire1") && sonarPing.isPlaying == false)
        {
            sonarPing.Play();
            StartCoroutine(SonarReturn());
        }
           
    }

    IEnumerator SonarReturn()
    {        
        yield return new WaitForSeconds(timeDelay);
        sonarReturn.Play();
    }

}

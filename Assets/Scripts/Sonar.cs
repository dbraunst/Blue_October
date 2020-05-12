using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sonar : MonoBehaviour
{
    public AudioSource sonarPing;
    AudioClip sonarPingClip;

    public AudioSource sonarReturn;
    AudioClip sonarReturnClip;

    public int cutoffFreq = 500;
    public GameObject player;

    float speedOfSound = 1450.0f;
    [Tooltip("Scale Multiplicaiton of distance, in Meters")]
    public float timeScale = 10.0f;

    [Tooltip("In Seconds")]
    public float timeDelay;
    public float arbNumber;

    void Start()
    {
        sonarPing.spatialize = false;
        sonarPing.bypassEffects = true;}

    void Update()
    {
        timeDelay = Vector3.Distance(player.transform.position, transform.position) * timeScale / speedOfSound;

        if (Input.GetButtonDown("Fire1") && sonarPing.isPlaying == false)
        {

            sonarPing.Play();
            sonarReturn.PlayDelayed(timeDelay);
            //StartCoroutine(SonarReturn());
        }


        sonarReturn.GetComponentInParent<AudioLowPassFilter>().cutoffFrequency = cutoffFreq;

    }


    /*IEnumerator SonarReturn()
    {
        Debug.Log("timeDelay" + Time.time);
        yield return new WaitForSeconds(timeDelay);
        Debug.Log("Play" + Time.time);
        sonarReturn.Play();
    }*/

}

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
        sonarPing.bypassEffects = true;
        sonarReturn.bypassEffects = true;
        player = GameObject.FindGameObjectWithTag("Player");

        sonarReturn.GetComponentInParent<AudioLowPassFilter>().cutoffFrequency = cutoffFreq;
    }

    void Update()
    {
        timeDelay = Vector3.Distance(player.transform.position, transform.position) * timeScale / speedOfSound;

        if (Input.GetButtonDown("Fire1") && (sonarPing.isPlaying == false || sonarReturn.isPlaying == false))
        {
            sonarPing.Play();
            Debug.Log("Play 1");
            StartCoroutine(SonarReturn());
        }
    }

    IEnumerator SonarReturn()
    {
        sonarReturn.priority = 10;
        Debug.Log("Call Time " + Time.time);
        yield return new WaitForSeconds(timeDelay);
        Debug.Log("Delayed Time: " + Time.time);
        sonarReturn.Play();
    }
}

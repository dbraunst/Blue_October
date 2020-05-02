using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceUtility : MonoBehaviour
{
    AudioSource audiosource;
    AudioClip clip;

    public GameObject player;

    float maxDistance;

    void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    void Update()
    {
        maxDistance = audiosource.maxDistance + 0.5f;
        Debug.Log("MadDis: " + maxDistance);

        float distance = Vector3.Distance(player.transform.position, transform.position);

        if (distance <= maxDistance && audiosource.isPlaying == false)
        {
            PlaySound();
        }

        if (distance > maxDistance)
        {
            audiosource.Stop();
        }

    }

    void PlaySound()
    {
        clip = audiosource.clip;
        audiosource.time = Random.Range(0f, clip.length);
        audiosource.Play();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceUtility : MonoBehaviour
{
    AudioSource audiosource;
    AudioClip clip;

    public GameObject player;

    public float maxVol = 1.0f;
    public float fadeInTime = 1.0f;
    public float fadeOutTime = 1.0f;

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
            StartCoroutine ("PlaySound");
        }

        if (distance > maxDistance)
        {
            StartCoroutine("StopSound");
        }

    }

    IEnumerator PlaySound()
    {
        audiosource.volume = 0f;
        clip = audiosource.clip;
        audiosource.time = Random.Range(0f, clip.length);
        
        audiosource.Play();

        while (audiosource.volume < maxVol)
        {
            audiosource.volume += Time.deltaTime / fadeInTime;

            yield return null;
        }

        audiosource.volume = maxVol;
    }

    IEnumerator StopSound()
    {
        while (audiosource.volume > 0.01f)
        {
            audiosource.volume -= Time.deltaTime / fadeOutTime;

            yield return null;
        }

        audiosource.volume = 0;
        audiosource.Stop();
    }

}

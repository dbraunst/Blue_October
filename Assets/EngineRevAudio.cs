using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineRevAudio : MonoBehaviour
{

    AudioSource audiosource;
    AudioClip clip;

    public float maxVol = 1.0f;
    public float volFadeInTime = 1.0f;
    public float volFadeOutTime = 1.0f;


    public float maxPitch = 1.0f;
    public float pitchFadeInTime = 1.0f;
    public float pitchFadeOutTime = 1.0f;




    void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StopCoroutine("StopEngineRev");
            StartCoroutine("EngineRev");
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            StartCoroutine("StopEngineRev");
        }
    }

    IEnumerator EngineRev()
    {
        audiosource.volume = 0f;
        audiosource.pitch = 0f;
        clip = audiosource.clip;
        audiosource.time = Random.Range(0f, clip.length);

        audiosource.Play();

        while (audiosource.volume < maxVol)
        {
            audiosource.volume += Time.deltaTime / volFadeInTime;
            

            yield return null;
        }

        audiosource.volume = maxVol;

        while (audiosource.pitch < maxPitch)
        {
            audiosource.pitch += Time.deltaTime / pitchFadeInTime;

            yield return null;
        }
        
        audiosource.pitch = maxPitch;
    }

    IEnumerator StopEngineRev()
    {
        while (audiosource.volume > 0.01f)
        {
            audiosource.volume -= Time.deltaTime / volFadeOutTime;

            yield return null;
        }

        while (audiosource.pitch > 0.01f)
        {
            audiosource.pitch -= Time.deltaTime / pitchFadeOutTime;

            yield return null;
        }

        audiosource.volume = 0;
       
        audiosource.pitch = 0;

        audiosource.Stop();

    

  
        
        
    }
}

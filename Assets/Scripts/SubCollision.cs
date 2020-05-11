using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubCollision : MonoBehaviour
{
    public GameObject player;
    public AudioSource collisionSource;

    // Start is called before the first frame update
    void Start()
    {
        collisionSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision player)
    {
        collisionSource.Play();
    }

}

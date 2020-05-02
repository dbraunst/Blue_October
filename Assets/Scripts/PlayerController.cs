using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 2.0f;
    public float accelSpeed = 0.0f;
    public float turnSpeed = 1.0f;

    public bool swapVerticalAxes = false;
    private int swapVertAxes = 1;

    private float rotationY;
    private float rotationX;

    // Start is called before the first frame update
    void Start()
    {
        if (swapVerticalAxes) swapVertAxes = -1;
    }

    // FixedUpdate is frame-rate independent (put physics stuff here)
    private void FixedUpdate()
    {
        //spacebar to move forward
        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }

        // Get Input axes for movement controls
        // LR as normal, flip UP/DOWN controls bc submarine.
        // 'swapVerticalAxes' lets user switch this if they want
        rotationX = Input.GetAxis("Vertical") * turnSpeed * swapVertAxes * Time.deltaTime;
        rotationY = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;

        //rotate left/right relative to world, up down relative to self
        transform.Rotate(0.0f, rotationY, 0.0f, Space.World); //Left/Right
        transform.Rotate(rotationX, 0.0f, 0.0f, Space.Self); //Up/Down
    }

    // Update is called once per frame (put visual stuff here)
    void Update()
    {
        
    }
}

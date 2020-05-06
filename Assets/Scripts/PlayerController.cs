using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 20.0f;
    public float turnSpeed = 5.0f;

    public bool swapVerticalAxes = false;
    private int swapVertAxes = 1;

    private float rotationY;
    private float rotationX;

    private float lockPos = 0.0f;

    private Rigidbody body;

    // Start is called before the first frame update
    void Start()
    {
        if (swapVerticalAxes) swapVertAxes = -1;

        body = GetComponent<Rigidbody>();
    }

    // FixedUpdate is frame-rate independent (put physics stuff here)
    private void FixedUpdate()
    {
        //spacebar to move forward
        if (Input.GetKey(KeyCode.Space))
        {
            //body.AddForce(Vector3.forward * 1.0f * moveSpeed * Time.deltaTime, ForceMode.Force );
            body.AddForce(transform.forward * moveSpeed, ForceMode.Force);
        }

        // Get Input axes for movement controls
        // LR as normal, flip UP/DOWN controls bc submarine.
        // 'swapVerticalAxes' lets user switch this if they want
        body.AddTorque(transform.right * swapVertAxes * turnSpeed / 2 * Input.GetAxis("Vertical"), ForceMode.Force);
        body.AddTorque(transform.up * turnSpeed * Input.GetAxis("Horizontal"), ForceMode.Force);

        //Lock Z rotation
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, lockPos);
    }

    // Update is called once per frame (put visual stuff here)
    void Update()
    {
        
    }
}

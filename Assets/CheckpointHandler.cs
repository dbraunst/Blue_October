using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointHandler : MonoBehaviour
{

    public GameObject objective;

    private void Awake()
    {
        if (objective == null)
        {
            objective = GameObject.FindGameObjectWithTag("Objective");
        }
    }

    //If we hit the checkpoints as specified by the objective, call the
    //  playerTriggerEnter script from objective's SceneManagement script
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CheckPoint"))
        {
            Debug.Log("thru checkpoint trigger");

            objective.GetComponent<SceneManagement>().playerTriggerEnter(other);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public void LoadNextLevel()
    {
        int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentLevelIndex + 1);
    }

    private void OnTriggerEnter(Collider other)
    {
        LoadNextLevel();
    }

}

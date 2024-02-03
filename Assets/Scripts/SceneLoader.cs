using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Loading the home screen after initial cutscene
    void OnEnable()
    {
        SceneManager.LoadScene("HOME", LoadSceneMode.Single);
    }
}

// For Loading the laptop scene from home scene

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartPC : MonoBehaviour
{
    
    [SerializeField]public Canvas cutsceneCanvas;
    private Scene2CutsceneManger scene2CutsceneManger;
    
    // Start is called before the first frame update
    [SerializeField] float interactionDistance = 4;
    void Start()
    {
        scene2CutsceneManger = FindObjectOfType<Scene2CutsceneManger>();
    }

    // Update is called once per frame
    void Update()
    {
        if (scene2CutsceneManger.cutsceneEnded && interactionDistance >= Vector2.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("PC Scene Started");
                SceneManager.LoadScene("LAPTOP SCREEN");
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Navigator : MonoBehaviour
{
    
   
    void Update()
    {
        int activeScene = SceneManager.GetActiveScene().buildIndex;
        if (Input.GetKeyDown(KeyCode.Space)) {
            activeScene++;
            SceneManager.LoadScene(activeScene);
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown("return"))
        {
            SceneManager.LoadScene("OvenScene");
        }
    }

    public void OnPress()
    {
        Application.Quit();
    }
    
}

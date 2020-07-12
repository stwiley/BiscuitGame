using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject PauseCanv;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape") && PauseCanv.activeSelf == false){
            PauseCanv.SetActive(true);
            Time.timeScale = 0f;
        }
        else if(Input.GetKeyDown("escape") && PauseCanv.activeSelf == true)
        {
            PauseCanv.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void Unpause()
    {
        PauseCanv.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Restart()
    {
        SceneManager.LoadScene("OvenScene");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class SuccessScript : MonoBehaviour
{

    public GameObject VicCanv;
    public void OnTriggerEnter(Collider other)
    {
        VicCanv.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Replay()
    {
        SceneManager.LoadScene("OvenScene");
        Time.timeScale = 1f;
    }

    public void titlescreen()
    {
        SceneManager.LoadScene("StartScene");
        Time.timeScale = 1f;
    }

}

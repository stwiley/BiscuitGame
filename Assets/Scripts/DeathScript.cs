using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class DeathScript : MonoBehaviour
{
    public GameObject DeathCanv;

    public void OnTriggerEnter(Collider other)
    {
        DeathCanv.SetActive(true);
    }

    public void OnPress()
    {
        SceneManager.LoadScene("OvenScene");
    }

}

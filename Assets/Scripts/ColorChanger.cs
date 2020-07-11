using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public GameObject Obj;
    public Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = Obj.GetComponent<Renderer>();
    }

    public void OnPress()
    {
        rend.material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
    }
}

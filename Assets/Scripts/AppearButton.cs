using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearButton : MonoBehaviour
{
    public GameObject Obj;
    public GameObject canv;
    MeshRenderer mr;
    // Start is called before the first frame update
    void Start()
    {
        mr = Obj.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    public void OnPress()
    {
        mr.enabled = true;
        canv.SetActive(false);
    }
}

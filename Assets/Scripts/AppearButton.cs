using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearButton : MonoBehaviour
{
    public GameObject Obj;
    public GameObject canv;
    public GameObject cam;
    MeshRenderer mr;
    public Mesh objMesh;

    public float squeezeValue;
    public float explodeValue;
    // Start is called before the first frame update
    void Start()
    {
        mr = Obj.GetComponent<MeshRenderer>();
        objMesh = Obj.GetComponent<MeshFilter>().mesh;
    }

    // Update is called once per frame
    public void OnPress()
    {
        mr.enabled = true;
        canv.SetActive(false);

        this.GetComponent<MeshAdjuster>().SqueezyBoy(objMesh, squeezeValue);
        this.GetComponent<MeshAdjuster>().Explode(objMesh, 1.2f, 1.5f,  explodeValue);

        Obj.GetComponent<MeshCollider>().enabled = false;
        Obj.GetComponent<Rigidbody>().useGravity = true;
        Obj.GetComponent<Rigidbody>().AddForce(Vector3.up * 10, ForceMode.Impulse);
        Obj.GetComponent<BiscMove>().doingLaunchTimer = true;
        cam.GetComponent<CamFollow>().active = true;
    }
}

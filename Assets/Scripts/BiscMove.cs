using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiscMove : MonoBehaviour // Script should go on the biscuit! "active" is set to true when the biscuit first collides with something.
{
    public GameObject cam;
    private Vector3 movevec = Vector3.zero;
    private bool active = false;
    [HideInInspector]
    public bool doingLaunchTimer = false;
    private float launchtimer = 2;

    private void Update()
    {
        if(doingLaunchTimer)
        {
            launchtimer -= Time.deltaTime;
            if(launchtimer <= 0)
            {
                GetComponent<MeshCollider>().enabled = true;
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(active) // movement is relative to the camera, make sure "CamFollow" is enabled before trying to move.
        {
            movevec = Vector3.zero;
            if (Input.GetKey(KeyCode.W))
            {
                Vector3 tmpvec = transform.position - cam.transform.position;
                movevec += new Vector3(tmpvec.x, 0, tmpvec.z);
            }
            if (Input.GetKey(KeyCode.S))
            {
                Vector3 tmpvec = cam.transform.position - transform.position;
                movevec += new Vector3(tmpvec.x, 0, tmpvec.z);
            }
            if (Input.GetKey(KeyCode.D))
            {
                Vector3 tmpvec = cam.transform.right;
                movevec += new Vector3(tmpvec.x, 0, tmpvec.z);
            }
            if (Input.GetKey(KeyCode.A))
            {
                Vector3 tmpvec = -cam.transform.right;
                movevec += new Vector3(tmpvec.x, 0, tmpvec.z);
            }
            GetComponent<Rigidbody>().AddForce(Vector3.Normalize(movevec));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(!active)
        {
            active = true;
        }
    }
}

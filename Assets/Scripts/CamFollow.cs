using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform targetTransform;
    public bool active = false;
    private Vector3 moveTo;
    private float speed;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(active)
        {
            moveTo = targetTransform.position + (Vector3.up * 1.5f) + (new Vector3(Vector3.Normalize(transform.position - targetTransform.position).x * 3, 0, Vector3.Normalize(transform.position - targetTransform.position).z * 3));
            speed = Vector3.Distance(transform.position, moveTo) * Time.deltaTime * 10f;
            transform.position = Vector3.MoveTowards(transform.position, moveTo, speed);
            transform.LookAt(targetTransform.position + new Vector3(0f, 0.5f, 0f));
        }
    }
}

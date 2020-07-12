using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshAdjuster : MonoBehaviour
{
    //
    public GameObject biscuit;
    private Mesh biscMesh; // the initial biscuit mesh taken at runtime
    private Vector3[] vertices; // the initial vertex positions taken at runtime

    // Start is called before the first frame update
    void Start()
    {
        if(biscuit != null)
        {
            biscMesh = biscuit.GetComponent<MeshFilter>().mesh;
            vertices = biscMesh.vertices;
        }
    }

    public void Explode(Mesh ms, float strengthmin, float strengthmax, float saturation) // Pushes "saturation"% of the vertices away from the center randomly. saturation is 0% <-> 100%.
    {
        Vector3 center = Vector3.zero;
        Mesh numesh = ms;
        Vector3[] nuverts = vertices;

        for(int i=0; i<vertices.Length; i++)
        {
            if(Random.Range(0,100) < saturation) //Vertex has been chosen!
            {
                bool seam = false;
                float randstrength = Random.Range(strengthmin, strengthmax);
                for (int j = 0; j < vertices.Length; j++)
                {
                    if (vertices[j] == vertices[i] && j != i) //Check for duplicate/seam verts
                    {
                        nuverts[j] = vertices[j] * randstrength;
                    }
                }
                nuverts[i] = vertices[i] * randstrength * (seam ? 0.5f : 1f);
            }
        }

        numesh.vertices = nuverts;
        biscuit.GetComponent<MeshFilter>().mesh = numesh;
        biscuit.GetComponent<MeshFilter>().mesh.RecalculateBounds();
        biscuit.GetComponent<MeshFilter>().mesh.RecalculateNormals();
        biscuit.GetComponent<MeshFilter>().mesh.RecalculateTangents();
        biscuit.GetComponent<MeshCollider>().sharedMesh = numesh;
    }

    public void SqueezyBoy(Mesh ms, float percent) // Pushes the vertices away or towards the center based on local position by "percent".
    {
        Vector3 center = Vector3.zero;
        Mesh numesh = ms;
        Vector3[] nuverts = vertices;

        for (int i = 0; i < vertices.Length; i++)
        {
            float distance = Vector3.Distance(center, vertices[i]);
            Vector3 awayvec = Vector3.Normalize(vertices[i] - center) * distance;
            nuverts[i] = vertices[i] + awayvec * Mathf.Abs(vertices[i].y) * (percent/200);
        }

        numesh.vertices = nuverts;
        biscuit.GetComponent<MeshFilter>().mesh = numesh;
        biscuit.GetComponent<MeshFilter>().mesh.RecalculateBounds();
        biscuit.GetComponent<MeshFilter>().mesh.RecalculateNormals();
        biscuit.GetComponent<MeshFilter>().mesh.RecalculateTangents();
        biscuit.GetComponent<MeshCollider>().sharedMesh = numesh;
    }
}

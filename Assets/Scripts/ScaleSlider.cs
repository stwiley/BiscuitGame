using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;
using Vector3 = UnityEngine.Vector3;


public class ScaleSlider : MonoBehaviour
{
    public Slider xslider;
    public Slider yslider;
    public Slider zslider;
    public Slider squishslider;
    public Slider explodeslider;
    //public Mesh bisquitMesh;
    Vector3 Scale;

    void Start()
    {
        xslider = GameObject.Find("xSlider").GetComponent<Slider>();
        yslider = GameObject.Find("ySlider").GetComponent<Slider>();
        zslider = GameObject.Find("zSlider").GetComponent<Slider>();
        squishslider = GameObject.Find("squishSlider").GetComponent<Slider>();
        explodeslider = GameObject.Find("explodeSlider").GetComponent<Slider>();
        Scale = new Vector3(0.5f, 0.5f, 0.5f);
        transform.localScale = Scale;
    }

    public void xSlider()
    {
        Scale.x = xslider.value;
        transform.localScale = Scale;
    }

    public void ySlider()
    {
        Scale.y = yslider.value;
        transform.localScale = Scale;
    }

    public void zSlider()
    {
        Scale.z = zslider.value;
        transform.localScale = Scale;
    }

    public void squishSlider()
    {
        GameObject.Find("EventSystem").GetComponent<AppearButton>().squeezeValue = squishslider.value;
    }

    public void explodeSlider()
    {
        GameObject.Find("EventSystem").GetComponent<AppearButton>().explodeValue = explodeslider.value;
    }
}

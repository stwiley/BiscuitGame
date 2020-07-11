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
    Vector3 Scale;

    void Start()
    {
        xslider = GameObject.Find("xSlider").GetComponent<Slider>();
        yslider = GameObject.Find("ySlider").GetComponent<Slider>();
        zslider = GameObject.Find("zSlider").GetComponent<Slider>();
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
}

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

    private float timer;
    private bool zSliderMoved;

    void Start()
    {
        xslider = GameObject.Find("xSlider").GetComponent<Slider>();
        yslider = GameObject.Find("ySlider").GetComponent<Slider>();
        zslider = GameObject.Find("zSlider").GetComponent<Slider>();
        squishslider = GameObject.Find("squishSlider").GetComponent<Slider>();
        explodeslider = GameObject.Find("explodeSlider").GetComponent<Slider>();
        Scale = new Vector3(0.5f, 0.5f, 0.5f);
        transform.localScale = Scale;
        timer = 0.2f;
    }

    private void Update()
    {
        if (!GameObject.Find("EventSystem").GetComponent<AppearButton>().startedGame && timer <= 0) //fucks with the settings while the hud is up
        {
            annoyingSliders();
            timer = 0.3f;
        }
        timer -= Time.deltaTime;
    }

    public void annoyingSliders()
    {
        if(xslider.value > xslider.minValue) //xslider just slowly goes down
        {
            xslider.value -= .01f;
        }

        if(yslider.normalizedValue > xslider.normalizedValue && yslider.normalizedValue > squishslider.normalizedValue) //yslider tries to stay between x and squish
        {
            yslider.value -= .01f;
        }
        else if(yslider.normalizedValue < xslider.normalizedValue && yslider.normalizedValue < squishslider.normalizedValue)
        {
            yslider.value += .01f;
        }

        if(zSliderMoved) //moving zslider makes explodeslider go up and down
        {
            explodeslider.value += 2*Mathf.Sin(zslider.value);
            zSliderMoved = false;
        }


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
        zSliderMoved = true;
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

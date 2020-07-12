using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChanger : MonoBehaviour
{
    public GameObject Obj;
    public Renderer rend;

    public Slider hueSlider;
    public Slider valSlider;

    // Start is called before the first frame update
    void Start()
    {
        rend = Obj.GetComponent<Renderer>();
    }

    public void OnPress()
    {
        float hueVal = Random.Range(0f, 1f);
        float valVal = Random.Range(0.5f, 1f);

        hueSlider.value = hueVal;
        valSlider.value = valVal;
        
        rend.material.color = Color.HSVToRGB(hueVal, 1f, valVal);
    }
}

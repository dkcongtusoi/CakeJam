using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MixingCakeScript : MonoBehaviour
{
    public float currentValue;
    public float reduceSpeed;
    public Slider slider;
    bool doneBaking = false;
    // Start is called before the first frame update
    void Start()
    {
        slider.value = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!doneBaking)
        {
            if (slider.value >= slider.minValue && slider.value < slider.maxValue)
            {
                slider.value -= reduceSpeed * Time.deltaTime;
            }
            else if (slider.value < slider.minValue)
            {
                slider.value = 0.01f;
            }
            else
            {
                slider.value = slider.maxValue;
                doneBaking = true;
            }
        }
        

        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            slider.value += currentValue;
        }

    }
    
}

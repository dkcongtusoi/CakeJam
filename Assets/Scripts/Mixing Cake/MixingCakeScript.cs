using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MixingCakeScript : MonoBehaviour
{
    public float currentValue;
    public float reduceSpeed;
    public Slider slider;
    public bool doneBaking = false;
    bool gameStarted = false;
    // Start is called before the first frame update
    void Start()
    {
        slider.value = 0.5f;
        StartCoroutine(StartGame());
    }

    // Update is called once per frame
    void Update()
    {
        if (!doneBaking && gameStarted)
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
                gameObject.SetActive(false);
            }
        }
        

        if (Input.GetKeyDown(KeyCode.Space) && gameStarted) 
        {
            slider.value += currentValue;
        }

    }
    
    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(5);
        gameStarted = true;
    }
}

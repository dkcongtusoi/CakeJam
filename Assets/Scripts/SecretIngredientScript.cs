using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class SecretIngredientScript : MonoBehaviour
{
    public string[] secretIngredientList;
    public string secretIngredient;

    public string requiredItem;
    public int price;

    [Header("1st Place Cake")]
    public string mysteryOne;

    [Header("2nd Place Cake")]
    public string mysteryTwo;

    [Header("2nd Place Cake")]
    public string mysteryThree;

    [Header("Last Place Cake")]
    public string mysteryFour;

    // Start is called before the first frame update
    void Start()
    {
        secretIngredient = secretIngredientList[Random.Range(0, secretIngredientList.Length)];
        GetCakeRecipe();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void GetCakeRecipe()
    {
        switch (secretIngredient)
        {
            case var value when value == mysteryOne:
                requiredItem = "egg";
                
                price = 3;

                break;
            case var value when value == mysteryTwo:
                requiredItem = "saliva";
                price = 2;

                break;
            case var value when value == mysteryThree:
                requiredItem = "cheese";
                price = 2;

                break;
            case var value when value == mysteryFour:
                requiredItem = "tears";
                price = 1;

                break;
            default:
                break;
        }
        GameManager.Instance.requiredItem = requiredItem;
        GameManager.Instance.secretIngredient = secretIngredient;
        GameManager.Instance.price = price;
    }
}

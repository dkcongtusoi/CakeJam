using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RecipeScript : MonoBehaviour
{
    public string[] ingredientName;
    public int ingredientEntry = 0;
    public int maxEntry = 3;
    public bool enoughItem = false;

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

    public bool bakeSuccesful;
    bool hasBaked;
    // Start is called before the first frame update
    void Start()
    {
        secretIngredient = secretIngredientList[Random.Range(0, secretIngredientList.Length)];
        GetCakeRecipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (ingredientEntry == maxEntry)
        {
            enoughItem = true;            
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            BakeCake();
        }
        
        if (hasBaked)
        {
            if (!bakeSuccesful)
            {
                price = 4;
                Debug.Log("Uh oh, you burnt the cake!");
            }
            else
            {
                Debug.Log("Congratz, you won " + price + " price");
            }
        }
    }

    public void AddToRecipe(string ingredient)
    {
        if (ingredientName.Count() > 0 && ingredientEntry < maxEntry)
        {
            ingredientName[ingredientEntry] = ingredient;
            ingredientEntry++;
        }
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
                Debug.Log(".");
                break;
        }
    }

    void BakeCake()
    {
        foreach (var item in ingredientName)
        {
            if (!bakeSuccesful)
            {
                if (item == requiredItem)
                {
                    bakeSuccesful = true;
                    Debug.Log("baked");
                    break;
                }
            }
        }
        hasBaked = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class RecipeScript : MonoBehaviour
{
    public string[] ingredientName;
    public int ingredientEntry = 0;
    public int maxEntry = 3;
    public bool enoughItem = false;

    public Image[] basketItems;
    public int basketEntry = 0;
    public int maxBasket = 3;

    public bool hasRequiredItem;
    bool hasChecked;

    public GameObject checkoutButton;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (ingredientEntry == maxEntry)
        {
            enoughItem = true;            
        }
        
        //if (hasChecked)
        //{
        //    if (!hasRequiredItem)
        //    {
        //        GameManager.Instance.price = 4;
        //        Debug.Log("Uh oh, you burnt the cake!");
        //    }
        //    else
        //    {
        //        Debug.Log("Congratz, you won " + GameManager.Instance.price + " price");
        //    }
        //}

        if (ingredientEntry == maxEntry && !hasChecked)
        {
            CheckRequirement();
        }

        if (enoughItem)
        {
            checkoutButton.SetActive(true);
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

    public void AddToBasket(Image sprite)
    {
        if (basketItems.Count() > 0 && basketEntry < maxBasket)
        {
            basketItems[basketEntry].sprite = sprite.sprite;
            basketItems[basketEntry].SetNativeSize();
            basketEntry++;
        }
    }

    public void DisableButton(Button yourButton)
    {
        if (yourButton != null)
        {
            yourButton.interactable = false;
        }
    }

    void CheckRequirement()
    {
        foreach (var item in ingredientName)
        {
            if (!hasRequiredItem)
            {
                if (item == GameManager.Instance.requiredItem)
                {
                    hasRequiredItem = true;
                    GameManager.Instance.hasRequiredItem = true;
                    Debug.Log("got the correct item");
                    break;
                }
            }
        }
        hasChecked = true;
    }

    public void ChangeScene(string sceneName)
    {
        GameManager.Instance.ChangeScene(sceneName);
    }
}

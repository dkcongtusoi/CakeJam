using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonControl : MonoBehaviour
{
    public RecipeScript recipeManager;
    Button button;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if (recipeManager != null)
        {
            if (recipeManager.enoughItem)
            {
                button.interactable = false;
            }
        }
    }
}

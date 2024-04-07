using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;



public class IngredientScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public ItemScriptableObject item;
    public float spriteScale = 10f;
    public RectTransform bgTransform;
    Image image;
    RectTransform rectTransform;

    public Image backgroundImage;
    private bool isSelected = false;
    private bool mouse_over = false;
    public RecipeScript recipeManager;
    // Start is called before the first frame update
    void Awake()
    {        
        image = GetComponent<Image>();
        rectTransform = GetComponent<RectTransform>();
    }
    void Start()
    {
        if (item != null && image != null)
        {
            image.sprite = item.itemSprite;
            rectTransform.sizeDelta = new Vector2(item.itemSprite.bounds.size.x * spriteScale, item.itemSprite.bounds.size.y * spriteScale);
            bgTransform.sizeDelta = new Vector2(item.itemSprite.bounds.size.x * spriteScale, item.itemSprite.bounds.size.y * spriteScale);
        }
    }
    void Update()
    {
        if (!isSelected)
        {
            if (mouse_over)
            {
                if (!recipeManager.enoughItem)
                {
                    //Debug.Log("Mouse Over");
                    if (Input.GetMouseButtonDown(0))
                    {
                        isSelected = true;
                        //recipeManager.AddToRecipe(item.itemName);
                    }
                    backgroundImage.color = Color.red;
                }                
            }
            else
            {
                backgroundImage.color = Color.white;
            }
        }
        else
        {
            backgroundImage.color = Color.gray;
        }

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        mouse_over = true;
        //Debug.Log("Mouse enter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouse_over = false;
        //Debug.Log("Mouse exit");
    }

}

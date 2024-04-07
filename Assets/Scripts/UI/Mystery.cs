using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using TMPro;

public class Mystery : MonoBehaviour
{
    // Start is called before the first frame update
    private DialogueRunner dialogueRunner;
    public Animator MysteryUI;
    public Animator MysteryItem;

    //private GameManager gameManager;

    private void Awake()
    {
        dialogueRunner = FindObjectOfType<Yarn.Unity.DialogueRunner>();
        dialogueRunner.AddCommandHandler("MysteryCombo", MysteryCombo);

        //gameManager = GameManager.Instance;
        Debug.Log("Manager Accessed");
    }

    private void MysteryCombo()
    {
        string secretIngredient = GameManager.Instance.secretIngredient;
        Debug.Log("Combo Accessed");

        Debug.Log("Secret Ingredient: " + secretIngredient);

        if (secretIngredient == "Love" )
        {
            MysteryUI.SetTrigger("Love");
            MysteryItem.SetTrigger("Love");
        }
        else if (secretIngredient == "Crisis")
        {
            MysteryUI.SetTrigger("Crisis");
            MysteryItem.SetTrigger("Crisis");
        }
        else if (secretIngredient == "Souls")
        {
            MysteryUI.SetTrigger("Souls");
            MysteryItem.SetTrigger("Souls");
        }
        else if (secretIngredient == "Fear")
        {
            MysteryUI.SetTrigger("Fear");
            MysteryItem.SetTrigger("Fear");
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

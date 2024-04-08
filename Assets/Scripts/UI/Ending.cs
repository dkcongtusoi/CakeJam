using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using TMPro;

public class Ending : MonoBehaviour
{
    // Start is called before the first frame update
    private DialogueRunner dialogueRunner;
    public GameObject JackCake;
    public GameObject AshCake;
    public GameObject GhostCake;
    public GameObject MouseCake;
    public GameObject TruckCake;
    public Animator JackBox;

    //private GameManager gameManager;

    private void Awake()
    {
        dialogueRunner = FindObjectOfType<Yarn.Unity.DialogueRunner>();
        dialogueRunner.AddCommandHandler("EndCake", EndCake);

        //dialogueRunner.AddCommandHandler<string>("JackBox", JackBox);

        //gameManager = GameManager.Instance;

        JackCake.SetActive(false);
        AshCake.SetActive(false);
        GhostCake.SetActive(false);
        MouseCake.SetActive(false);
        TruckCake.SetActive(false);
    }

    private void EndCake()
    {
        string secretIngredient = GameManager.Instance.secretIngredient;
        bool hasRequiredItem = GameManager.Instance.hasRequiredItem;
        int prize = GameManager.Instance.prize;

        if (hasRequiredItem && prize == 1)
        {
            JackCake.SetActive(true);
            JackBox.SetTrigger("Eat");

        }
        else if (secretIngredient == "Fear" && hasRequiredItem && prize == 2)
        {
            MouseCake.SetActive(true);
            JackBox.SetTrigger("Eat");
        }
        else if (secretIngredient == "Souls" && hasRequiredItem && prize == 2)
        {
            GhostCake.SetActive(true);
            JackBox.SetTrigger("Eat");
        }
        else if (hasRequiredItem && prize == 3)
        {
            TruckCake.SetActive(true);
            JackBox.SetTrigger("Eat");
        }
        else if (hasRequiredItem == false)
        {
            AshCake.SetActive(true);
            JackBox.SetTrigger("Eat");
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

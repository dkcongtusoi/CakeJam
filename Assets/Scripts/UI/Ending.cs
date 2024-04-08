using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using TMPro;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    [SerializeField] private string JackCakeEnd;
    [SerializeField] private string AshCakeEnd;
    [SerializeField] private string GhostCakeEnd;
    [SerializeField] private string TruckCakeEnd;
    [SerializeField] private string MouseCakeEnd;

    public GameObject JackCake;
    public GameObject AshCake;
    public GameObject GhostCake;
    public GameObject MouseCake;
    public GameObject TruckCake;
    public Animator JackBox;

    public GameObject GoodEnding;
    public GameObject BadEnding;

    //private GameManager gameManager;

    // internal properties not exposed to editor
    private DialogueRunner dialogueRunner;
    private bool isCurrentConversation = false;

    private void Awake()
    {
        dialogueRunner = FindObjectOfType<Yarn.Unity.DialogueRunner>();
        dialogueRunner.onDialogueComplete.AddListener(EndConversation);

        //dialogueRunner.AddCommandHandler("EndCake", EndCake);


        dialogueRunner.AddCommandHandler<string>("JackBoxAnim", JackBoxAnim);
        dialogueRunner.AddCommandHandler("JackOn", JackOn);
        dialogueRunner.AddCommandHandler("AshOn", AshOn);
        dialogueRunner.AddCommandHandler("MouseOn", MouseOn);
        dialogueRunner.AddCommandHandler("GhostOn", GhostOn);
        dialogueRunner.AddCommandHandler("TruckOn", TruckOn);

        dialogueRunner.AddCommandHandler("GoodEnd", GoodEnd);
        dialogueRunner.AddCommandHandler("BadEnd", BadEnd);

        //gameManager = GameManager.Instance;

        JackCake.SetActive(false);
        AshCake.SetActive(false);
        GhostCake.SetActive(false);
        MouseCake.SetActive(false);
        TruckCake.SetActive(false);
        GoodEnding.SetActive(false);
        BadEnding.SetActive(false);

    }
    private void GoodEnd()
    {
        GoodEnding.SetActive(true);
    }
    private void BadEnd()
    {
        BadEnding.SetActive(true);
    }
    private void JackOn()
    {
        JackCake.SetActive(true);
    }

    private void AshOn()
    {
        AshCake.SetActive(true);
    }

    private void MouseOn()
    {
        MouseCake.SetActive(true);
    }

    private void GhostOn()
    {
        GhostCake.SetActive(true);
    }

    private void TruckOn()
    {
        TruckCake.SetActive(true);
    }


    private void JackBoxAnim(string trigger)
    {
        JackBox.SetTrigger(trigger);
    }
    void Start()
    {
        // Check if the current scene is scene 5
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.buildIndex == 4) // assuming scene 5 is index 4
        {
            EndCake();
        }
    }
    private void EndCake()
    {
        string secretIngredient = GameManager.Instance.secretIngredient;
        bool hasRequiredItem = GameManager.Instance.hasRequiredItem;
        int prize = GameManager.Instance.prize;

        if (hasRequiredItem && prize == 1)
        {

            Debug.Log($"Started conversation with {name}.");
            isCurrentConversation = true;
            dialogueRunner.StartDialogue(JackCakeEnd);

            JackCake.SetActive(true);


        }
        else if (secretIngredient == "Fear" && hasRequiredItem && prize == 2)
        {
            Debug.Log($"Started conversation with {name}.");
            isCurrentConversation = true;
            dialogueRunner.StartDialogue(MouseCakeEnd);
            
            MouseCake.SetActive(true);
        }
        else if (secretIngredient == "Souls" && hasRequiredItem && prize == 2)
        {
            Debug.Log($"Started conversation with {name}.");
            isCurrentConversation = true;
            dialogueRunner.StartDialogue(GhostCakeEnd); 
            
            GhostCake.SetActive(true);
        }
        else if (hasRequiredItem && prize == 3)
        {
            Debug.Log($"Started conversation with {name}.");
            isCurrentConversation = true;
            dialogueRunner.StartDialogue(TruckCakeEnd);


            TruckCake.SetActive(true);
        }
        else if (hasRequiredItem == false)
        {
            Debug.Log($"Started conversation with {name}.");
            isCurrentConversation = true;
            dialogueRunner.StartDialogue(AshCakeEnd);

            AshCake.SetActive(true);
        }

    }

    private void EndConversation()
    {
        if (isCurrentConversation)
        {
            isCurrentConversation = false;
            Debug.Log($"Ended conversation with {name}.");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

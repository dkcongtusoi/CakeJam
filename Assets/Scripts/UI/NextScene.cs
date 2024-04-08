using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class NextScene : MonoBehaviour
{
    [SerializeField] private string JackCakeEnd;
    [SerializeField] private string AshCakeEnd;
    [SerializeField] private string GhostCakeEnd;
    [SerializeField] private string TruckCakeEnd;
    [SerializeField] private string MouseCakeEnd;

    public Animator JackCake;
    public Animator AshCake;
    public Animator GhostCake;
    public Animator MouseCake;
    public Animator TruckCake;

    MixingCakeScript mixingCakeScript;

    // internal properties not exposed to editor
    private DialogueRunner dialogueRunner;
    private bool isCurrentConversation = false;

    // Start is called before the first frame update

    private void Awake()
    {
        dialogueRunner = FindObjectOfType<Yarn.Unity.DialogueRunner>();
        dialogueRunner.onDialogueComplete.AddListener(EndConversation);

        //dialogueRunner.AddCommandHandler("EndCake", EndCake);

        dialogueRunner.AddCommandHandler<string>("JackOn", JackOn);
        dialogueRunner.AddCommandHandler<string>("AshOn", AshOn);
        dialogueRunner.AddCommandHandler<string>("MouseOn", MouseOn);
        dialogueRunner.AddCommandHandler<string>("GhostOn", GhostOn);
        dialogueRunner.AddCommandHandler<string>("TruckOn", TruckOn);


    }
    private void JackOn(string trigger)
    {
        JackCake.SetTrigger(trigger);
    }

    private void AshOn(string trigger)
    {
        AshCake.SetTrigger(trigger);
    }

    private void MouseOn(string trigger)
    {
        MouseCake.SetTrigger(trigger);
    }

    private void GhostOn(string trigger)
    {
        GhostCake.SetTrigger(trigger);
    }

    private void TruckOn(string trigger)
    {
        TruckCake.SetTrigger(trigger);
    }


    public void Start()
    {
        // Find the MixingCakeScript component in the scene
        dialogueRunner = FindObjectOfType<Yarn.Unity.DialogueRunner>();
        dialogueRunner.onDialogueComplete.AddListener(EndConversation);
        mixingCakeScript = FindObjectOfType<MixingCakeScript>();

        // Check if the MixingCakeScript instance is found
        if (mixingCakeScript != null)
        {
            // Start a coroutine to continuously check doneBaking
            StartCoroutine(CheckDoneBaking());
        }
        else
        {
            Debug.LogWarning("MixingCakeScript not found in the scene!");
        }
    }

    private IEnumerator CheckDoneBaking()
    {
        while (true)
        {
            yield return new WaitForSeconds(1); // Check every second, adjust as needed
            // Access the doneBaking variable from the MixingCakeScript
            if (mixingCakeScript.doneBaking == true)
            {
                Debug.Log("The cake is done baking!");
                if (!dialogueRunner.IsDialogueRunning)
                {
                    EndCake();
                }
            }
            else
            {
                Debug.Log("The cake is still baking...");
            }
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




        }
        else if (secretIngredient == "Fear" && hasRequiredItem && prize == 2)
        {
            Debug.Log($"Started conversation with {name}.");
            isCurrentConversation = true;
            dialogueRunner.StartDialogue(MouseCakeEnd);


        }
        else if (secretIngredient == "Souls" && hasRequiredItem && prize == 2)
        {
            Debug.Log($"Started conversation with {name}.");
            isCurrentConversation = true;
            dialogueRunner.StartDialogue(GhostCakeEnd);


        }
        else if (hasRequiredItem && prize == 3)
        {
            Debug.Log($"Started conversation with {name}.");
            isCurrentConversation = true;
            dialogueRunner.StartDialogue(TruckCakeEnd);



        }
        else if (hasRequiredItem == false)
        {
            Debug.Log($"Started conversation with {name}.");
            isCurrentConversation = true;
            dialogueRunner.StartDialogue(AshCakeEnd);


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
}
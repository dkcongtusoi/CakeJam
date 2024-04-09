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
    [SerializeField] private GameObject avatars;

    public Animator JackCake;
    public Animator AshCake;
    public Animator GhostCake;
    public Animator MouseCake;
    public Animator TruckCake;

    public Animator JackBox;

    public GameObject GoodEnding;
    public GameObject BadEnding;

    public Animator Clown;
    public Animator Outro;

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
        dialogueRunner.AddCommandHandler<string>("JackOn", JackOn);
        dialogueRunner.AddCommandHandler<string>("AshOn", AshOn);
        dialogueRunner.AddCommandHandler<string>("MouseOn", MouseOn);
        dialogueRunner.AddCommandHandler<string>("GhostOn", GhostOn);
        dialogueRunner.AddCommandHandler<string>("TruckOn", TruckOn);

        dialogueRunner.AddCommandHandler("GoodEnd", GoodEnd);
        dialogueRunner.AddCommandHandler("BadEnd", BadEnd);

        dialogueRunner.AddCommandHandler<string>("ClownBG", ClownBG);
        dialogueRunner.AddCommandHandler<string>("OutroText", OutroText);

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

    private void ClownBG(string trigger)
    {
        Clown.SetTrigger(trigger);
    }
    private void OutroText(string trigger)
    {
        Outro.SetTrigger(trigger);
        StartCoroutine(ShowAvatars());
        //avatars.SetActive(true);
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
            EndResult();
        }
    }
    private void EndResult()
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

    IEnumerator ShowAvatars()
    {
        yield return new WaitForSeconds(0.5f);
        avatars.SetActive(true);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class NextScene : MonoBehaviour
{
    MixingCakeScript mixingCakeScript;

    [SerializeField] private string conversationStartNode;

    // internal properties not exposed to editor
    private DialogueRunner dialogueRunner;
    private bool isCurrentConversation = false;

    // Start is called before the first frame update
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
                    StartConversation();
                }
            }
            else
            {
                Debug.Log("The cake is still baking...");
            }
        }
    }

    public void StartConversation()
    {
        Debug.Log($"Started conversation with {name}.");
        isCurrentConversation = true;
        dialogueRunner.StartDialogue(conversationStartNode);
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
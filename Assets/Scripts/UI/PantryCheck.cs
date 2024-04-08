using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class PantryCheck : MonoBehaviour
{
    RecipeScript recipeScript;
    // Start is called before the first frame update

    [SerializeField] private string conversationStartNode;

    // internal properties not exposed to editor
    private DialogueRunner dialogueRunner;
    private bool isCurrentConversation = false;

    public void Start()
    {
        // Find the MixingCakeScript component in the scene
        dialogueRunner = FindObjectOfType<Yarn.Unity.DialogueRunner>();
        dialogueRunner.onDialogueComplete.AddListener(EndConversation);
        recipeScript = FindObjectOfType<RecipeScript>();

        // Check if the MixingCakeScript instance is found
        if (recipeScript != null)
        {
            // Start a coroutine to continuously check doneBaking
            StartCoroutine(CheckPantryDone());
        }
        else
        {
            Debug.LogWarning("RecipeScript not found in the scene!");
        }
    }

    private IEnumerator CheckPantryDone()
    {
        while (true)
        {
            yield return new WaitForSeconds(1); // Check every second, adjust as needed
            // Access the doneBaking variable from the MixingCakeScript
            if (recipeScript.enoughItem == true)
            {
                Debug.Log("The pantrys done");
                if (!dialogueRunner.IsDialogueRunning)
                {
                    StartConversation();
                }
            }
            else
            {
                Debug.Log("Still choosing");
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

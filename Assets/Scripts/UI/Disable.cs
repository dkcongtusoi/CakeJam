using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using TMPro;

public class Disable : MonoBehaviour
{
    // Start is called before the first frame update
    private DialogueRunner dialogueRunner;
    public GameObject DialoguePanel;
    public GameObject ReactPanel;
    public GameObject FadePanel;
    public GameObject CurtPanel;
    public GameObject SpritePanel;

    //private GameManager gameManager;

    private void Awake()
    {
        dialogueRunner = FindObjectOfType<Yarn.Unity.DialogueRunner>();
        dialogueRunner.AddCommandHandler("DialogueOff", DialogueOff);
        dialogueRunner.AddCommandHandler("DialogueOn", DialogueOn);
        dialogueRunner.AddCommandHandler("SpriteOn", SpriteOn);
        dialogueRunner.AddCommandHandler("ReactOff", ReactOff);
        dialogueRunner.AddCommandHandler("ReactOn", ReactOn);
        dialogueRunner.AddCommandHandler("FadeOn", FadeOn);
        dialogueRunner.AddCommandHandler("FadeOff", FadeOff);
        dialogueRunner.AddCommandHandler("CurtOn", CurtOn);
        dialogueRunner.AddCommandHandler("CurtOff", CurtOff);

        DialoguePanel.SetActive(true);
        ReactPanel.SetActive(false);
        FadePanel.SetActive(true);
        CurtPanel.SetActive(false);

    }

    private void DialogueOff()
    {
        DialoguePanel.SetActive(false);
    }
    private void DialogueOn()
    {
        DialoguePanel.SetActive(true);
    }

    private void SpriteOn()
    {
        SpritePanel.SetActive(true);
    }

    private void ReactOff()
    {
        ReactPanel.SetActive(false);
    }

    private void ReactOn()
    {
        ReactPanel.SetActive(true);
    }

    private void FadeOn()
    {
        FadePanel.SetActive(true);
    }

    private void FadeOff()
    {
        FadePanel.SetActive(false);
    }

    private void CurtOn()
    {
        CurtPanel.SetActive(true);
    }
    private void CurtOff()
    {
        CurtPanel.SetActive(false);
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

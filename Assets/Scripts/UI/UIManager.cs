using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using TMPro;

public class UIManager : MonoBehaviour
{
    public DialogueRunner dialogueRunner;

    public FadeLayer fadeLayer;

    public Animator Jack;
    public Animator Reaction;
    //public Animator Mystery;
    public Animator Curtain;
    public Animator MysteryBox;

    public GameObject Confetti;

    public AudioSource genericAudioSource;
    public float SFXVolume = 0.5f;
    public AudioClip ReactSFX;

    public AudioClip CurtSFX;
    public AudioClip MysterySFX;


    // Start is called before the first frame update
    private void Awake()
    {

        dialogueRunner = GameObject.FindGameObjectWithTag("DialogueRunner").GetComponent<DialogueRunner>();
        fadeLayer = GameObject.FindGameObjectWithTag("FadeLayer").GetComponent<FadeLayer>();

        dialogueRunner.AddCommandHandler<string>("ReactAnim", ReactAnim);
        //dialogueRunner.AddCommandHandler<string>("BoxAnim", BoxAnim);
        dialogueRunner.AddCommandHandler<string>("CurtAnim", CurtAnim);
        dialogueRunner.AddCommandHandler<string>("JackAnim", JackAnim);

        Confetti.SetActive(false);
        //<<fadeIn DURATION>> and <<fadeOut DURATION>>
        dialogueRunner.AddCommandHandler<float>("fadeIn", FadeIn);
        dialogueRunner.AddCommandHandler<float>("fadeOut", FadeOut);

        dialogueRunner.AddCommandHandler("ConfettiAnim", ConfettiAnim);

        dialogueRunner.AddCommandHandler<string>("MysteryAnim", MysteryAnim);

        dialogueRunner.AddCommandHandler<string>("ChangeScene", ChangeScene);
    }

    private void Start()
    {
        
    }

    private void ChangeScene(string sceneName)
    {
        GameManager.Instance.ChangeScene(sceneName);
    }

    private void ConfettiAnim()
    {
        Confetti.SetActive(true);
    }
    private void JackAnim(string trigger)
    {
        Jack.SetTrigger(trigger);
    }
    private void MysteryAnim(string trigger)
    {
        MysteryBox.SetTrigger(trigger);
        genericAudioSource.clip = MysterySFX;
        genericAudioSource.volume = SFXVolume;
        genericAudioSource.Play();
    }
    private void ReactAnim(string trigger)
    {
        Reaction.SetTrigger(trigger);
        genericAudioSource.clip = ReactSFX;
        genericAudioSource.volume = SFXVolume;
        genericAudioSource.Play();
    }

    //private void BoxAnim(string trigger)
    //{
    //    Mystery.SetTrigger(trigger);
    //}

    private void CurtAnim(string trigger)
    {
        Curtain.SetTrigger(trigger);
        genericAudioSource.clip = CurtSFX;
        genericAudioSource.volume = SFXVolume;
        genericAudioSource.Play();
    }

    private Coroutine FadeIn(float time = 1f)
    {
        Debug.Log($"Fading in from black over {time} seconds.");
        return StartCoroutine(fadeLayer.ChangeAlphaOverTime(0, time));
    }

    // fades out to a black screen over {time} seconds
    private Coroutine FadeOut(float time = 1f)
    {
        Debug.Log($"Fading out to black over {time} seconds.");
        return StartCoroutine(fadeLayer.ChangeAlphaOverTime(1, time));
    }

    void Update()
    {
        
    }
}

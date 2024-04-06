using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using TMPro;

public class UIManager : MonoBehaviour
{
    private DialogueRunner dialogueRunner;
    private FadeLayer fadeLayer;

    public Animator HUD;
    public Animator Reaction;
    public Animator Mystery;

    public AudioSource genericAudioSource;
    public float SFXVolume = 0.5f;
    public AudioClip clocktick;



    // Start is called before the first frame update
    private void Awake()
    {
        dialogueRunner = FindObjectOfType<Yarn.Unity.DialogueRunner>();
        fadeLayer = FindObjectOfType<FadeLayer>();

        dialogueRunner.AddCommandHandler<string>("HUDAnim", HUDAnim);
        dialogueRunner.AddCommandHandler<string>("ReactAnim", ReactAnim);
        dialogueRunner.AddCommandHandler<string>("BoxAnim", BoxAnim);

        //<<fadeIn DURATION>> and <<fadeOut DURATION>>
        dialogueRunner.AddCommandHandler<float>("fadeIn", FadeIn);
        dialogueRunner.AddCommandHandler<float>("fadeOut", FadeOut);

    }

    private void HUDAnim(string trigger)
    {
        HUD.SetTrigger(trigger);
        genericAudioSource.clip = clocktick;
        genericAudioSource.volume = SFXVolume;
        genericAudioSource.Play();
    }

    private void ReactAnim(string trigger)
    {
        Reaction.SetTrigger(trigger);
        genericAudioSource.clip = clocktick;
        genericAudioSource.volume = SFXVolume;
        genericAudioSource.Play();
    }

    private void BoxAnim(string trigger)
    {
        Mystery.SetTrigger(trigger);
        genericAudioSource.clip = clocktick;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip clickSFX;
    [SerializeField] private AudioClip goldNuggetSFX;
    [SerializeField] private AudioClip bigGoldNuggetSFX;
    [SerializeField] private AudioClip footStepSFX;

    private AudioSource myAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayClick()
    {
        myAudioSource.PlayOneShot(clickSFX);
    }

    public void PlayGoldNugget()
    {
        myAudioSource.PlayOneShot(goldNuggetSFX);
    }

    public void PlayBigGoldNugget()
    {
        myAudioSource.PlayOneShot(bigGoldNuggetSFX);
    }

    public void PlayFootStep()
    {
        myAudioSource.PlayOneShot(footStepSFX);
    }

}

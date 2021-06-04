using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip clickSFX;
    [SerializeField] private AudioClip goldNuggetSFX;
    [SerializeField] private AudioClip bigGoldNuggetSFX;
    [SerializeField] private AudioClip footStepSFX;
    [SerializeField] private AudioClip sieveShakeSFX;
    [SerializeField] private AudioClip splooshSFX;
    [SerializeField] private AudioClip lockSFX;

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
        myAudioSource.volume = 0.5f;
        myAudioSource.PlayOneShot(clickSFX);
    }

    public void PlayGoldNugget()
    {
        myAudioSource.volume = 1f;
        myAudioSource.PlayOneShot(goldNuggetSFX);
    }

    public void PlayBigGoldNugget()
    {
        myAudioSource.volume = 1f;
        myAudioSource.PlayOneShot(bigGoldNuggetSFX);
    }

    public void PlayFootStep()
    {
        myAudioSource.volume = 1f;
        myAudioSource.PlayOneShot(footStepSFX);
    }

    public void PlaySieveShake()
    {
        myAudioSource.volume = 1f;
        myAudioSource.PlayOneShot(sieveShakeSFX);
    }

    public void PlaySploosh()
    {
        myAudioSource.volume = 1f;
        myAudioSource.PlayOneShot(splooshSFX);
    }

    public void PlayLock()
    {
        myAudioSource.volume = 1f;
        myAudioSource.PlayOneShot(lockSFX);
    }
}

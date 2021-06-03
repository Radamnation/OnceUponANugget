using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    [SerializeField] private float initalWaitTime = 1f;
    [SerializeField] private float fadeInTime = 0.5f;
    [SerializeField] private float fadeOutTime = 0.5f;
    [SerializeField] private float waitTime = 3f;

    private float fadeInTimer;
    private float fadeOutTimer;
    private float stayOnTimer;

    [SerializeField] private Text foolboxText;
    [SerializeField] private SpriteRenderer logo;
    [SerializeField] private Text presentsText;

    private Color white;
    private Color invisible;

    // Start is called before the first frame update
    void Start()
    {
        white = Color.white;
        invisible = Color.white;
        invisible.a = 0;

        foolboxText.color = invisible;
        logo.color = invisible;
        presentsText.color = invisible;

        StartCoroutine(InitialWait());
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeInTimer > 0)
        {
            var ratio = (fadeInTime - fadeInTimer) / fadeInTime;
            foolboxText.color = Color.Lerp(invisible, white, ratio);
            logo.color = Color.Lerp(invisible, white, ratio);
            presentsText.color = Color.Lerp(invisible, white, ratio);
            fadeInTimer -= Time.deltaTime;
        }
        else if (fadeOutTimer > 0)
        {
            var ratio = (fadeOutTime - fadeOutTimer) / fadeOutTime;
            foolboxText.color = Color.Lerp(white, invisible, ratio);
            logo.color = Color.Lerp(white, invisible, ratio);
            presentsText.color = Color.Lerp(white, invisible, ratio);
            fadeOutTimer -= Time.deltaTime;
        }
    }

    private IEnumerator InitialWait()
    {
        yield return new WaitForSeconds(initalWaitTime);
        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        fadeInTimer = fadeInTime;
        yield return new WaitForSeconds(fadeInTime);
        StartCoroutine(Wait());
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(waitTime);
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        fadeOutTimer = fadeOutTime;
        yield return new WaitForSeconds(fadeOutTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

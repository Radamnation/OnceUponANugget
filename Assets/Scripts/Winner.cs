using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Winner : MonoBehaviour
{
    [SerializeField] private float initalWaitTime = 1f;
    [SerializeField] private float fadeInTime = 0.5f;
    [SerializeField] private float fadeInRestTime = 0.5f;
    [SerializeField] private float waitTime = 1f;

    private float fadeInTimer;
    private float fadeInRestTimer;

    [SerializeField] private TextMeshProUGUI retryTMP;
    [SerializeField] private TextMeshProUGUI backToTitleTMP;
    [SerializeField] private TextMeshProUGUI winnerTMP;
    // [SerializeField] private TilemapRenderer rulesLayout;

    private Color white;
    private Color invisible;

    // Start is called before the first frame update
    void Start()
    {
        white = Color.white;
        invisible = Color.white;
        invisible.a = 0;

        retryTMP.color = invisible;
        backToTitleTMP.color = invisible;
        winnerTMP.color = invisible;

        StartCoroutine(InitialWait());
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeInTimer > 0)
        {
            var ratio = (fadeInTime - fadeInTimer) / fadeInTime;
            winnerTMP.color = Color.Lerp(invisible, white, ratio);
            fadeInTimer -= Time.deltaTime;
        }
        if (fadeInRestTimer > 0)
        {
            var ratio = (fadeInRestTime - fadeInRestTimer) / fadeInRestTime;
            retryTMP.color = Color.Lerp(invisible, white, ratio);
            backToTitleTMP.color = Color.Lerp(invisible, white, ratio);
            fadeInRestTimer -= Time.deltaTime;
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
        StartCoroutine(FadeRestIn());
    }

    private IEnumerator FadeRestIn()
    {
        fadeInRestTimer = fadeInRestTime;
        yield return new WaitForSeconds(fadeInRestTime);
        retryTMP.GetComponent<Retry>().Active = true;
        backToTitleTMP.GetComponent<BackToTitle>().Active = true;
    }
}

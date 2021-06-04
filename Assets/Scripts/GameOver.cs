using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    [SerializeField] private float initalWaitTime = 1f;
    [SerializeField] private float fadeInTime = 0.5f;
    [SerializeField] private float fadeInRestTime = 0.5f;
    [SerializeField] private float waitTime = 1f;

    [SerializeField] private Nugget nuggetPrefab;
    [SerializeField] private float nuggetSpawnTime = 0.1f;
    [SerializeField] private float nuggetSpawnHeight = 10f;
    [SerializeField] private float nuggetSpawnLength = 10f;
    [SerializeField] private float nuggetTorque = 1f;

    private float nuggetSpawnTimer;
    private float fadeInTimer;
    private float fadeInRestTimer;

    [SerializeField] private TextMeshProUGUI retryTMP;
    [SerializeField] private TextMeshProUGUI backToTitleTMP;
    [SerializeField] private TextMeshProUGUI looseTMP;
    // [SerializeField] private TilemapRenderer rulesLayout;

    private Color white;
    private Color invisible;
    private bool goldFalling = false;

    // Start is called before the first frame update
    void Start()
    {
        white = Color.white;
        invisible = Color.white;
        invisible.a = 0;

        retryTMP.color = invisible;
        backToTitleTMP.color = invisible;
        looseTMP.color = invisible;

        nuggetSpawnTimer = nuggetSpawnTime;

        StartCoroutine(InitialWait());
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeInTimer > 0)
        {
            var ratio = (fadeInTime - fadeInTimer) / fadeInTime;
            looseTMP.color = Color.Lerp(invisible, white, ratio);
            fadeInTimer -= Time.deltaTime;
        }
        if (fadeInRestTimer > 0)
        {
            var ratio = (fadeInRestTime - fadeInRestTimer) / fadeInRestTime;
            retryTMP.color = Color.Lerp(invisible, white, ratio);
            backToTitleTMP.color = Color.Lerp(invisible, white, ratio);
            fadeInRestTimer -= Time.deltaTime;
        }
        if (goldFalling)
        {
            nuggetSpawnTimer -= Time.deltaTime;
            if (nuggetSpawnTimer < 0)
            {
                var nuggetSpawnPosition = new Vector3(Random.Range(-nuggetSpawnLength, nuggetSpawnLength), nuggetSpawnHeight);
                var newNugget = Instantiate(nuggetPrefab, nuggetSpawnPosition, Quaternion.identity);
                newNugget.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-nuggetTorque, nuggetTorque));
                var bigNuggetChance = Random.Range(0, 100);
                if (bigNuggetChance < 20)
                {
                    newNugget.BigNugget = true;
                }
                nuggetSpawnTimer = nuggetSpawnTime;
            }
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
        goldFalling = true;
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

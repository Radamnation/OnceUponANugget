using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class TitleScreen : MonoBehaviour
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

    private float fadeInTimer;
    private float fadeInRestTimer;
    private float nuggetSpawnTimer;

    [SerializeField] private Text titleText;
    [SerializeField] private Text rulesText;
    [SerializeField] private Text playText;
    [SerializeField] private Text actualRulesText;
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

        titleText.color = invisible;
        rulesText.color = invisible;

        playText.enabled = false;
        actualRulesText.enabled = false;
        // rulesLayout.enabled = false;

        nuggetSpawnTimer = nuggetSpawnTime;

        StartCoroutine(InitialWait());
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeInTimer > 0)
        {
            var ratio = (fadeInTime - fadeInTimer) / fadeInTime;
            titleText.color = Color.Lerp(invisible, white, ratio);
            fadeInTimer -= Time.deltaTime;
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
        if (fadeInRestTimer > 0)
        {
            var ratio = (fadeInRestTime - fadeInRestTimer) / fadeInRestTime;
            rulesText.color = Color.Lerp(invisible, white, ratio);
            playText.color = Color.Lerp(invisible, white, ratio);
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
        goldFalling = true;
        yield return new WaitForSeconds(waitTime);
        StartCoroutine(FadeRestIn());
    }

    private IEnumerator FadeRestIn()
    {
        fadeInRestTimer = fadeInRestTime;
        yield return new WaitForSeconds(fadeInRestTime);
        rulesText.GetComponent<Rules>().Active = true;
    }

    public void ShowRules()
    {
        rulesText.GetComponent<Rules>().Active = false;
        playText.GetComponent<Play>().Active = true;

        titleText.enabled = false;
        rulesText.enabled = false;

        playText.enabled = true;
        actualRulesText.enabled = true;
        // rulesLayout.enabled = true;
    }
}

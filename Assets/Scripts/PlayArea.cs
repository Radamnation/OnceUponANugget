using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayArea : MonoBehaviour
{
    [SerializeField] private SpriteRenderer backgroundSpriteRenderer;
    [SerializeField] private Sprite[] backgroundSprites;
    [SerializeField] private KeyItem keyItem;
    [SerializeField] private GameObject transition;
    [SerializeField] private Vector3 transitionPositionLeft = new Vector3(-12, 12, 0);
    [SerializeField] private Vector3 transitionPositionRight = new Vector3(12, -12, 0);
    [SerializeField] private float transitionTime;
    [SerializeField] private GameObject myFireplace;
    [SerializeField] private Door myDoor;
    [SerializeField] private Chair myChair;
    [SerializeField] private AudioSource riverSound;

    private int currentLocation = 0;
    private Sieve mySieve;
    private bool[] keyItemFound = { false, false, false, false, false, false, false };
    private float transitionTimer = 0;
    private Vector3 targetPosition;

    public int CurrentLocation { get => currentLocation; set => currentLocation = value; }
    public bool[] KeyItemFound { get => keyItemFound; set => keyItemFound = value; }

    // Start is called before the first frame update
    void Start()
    {
        riverSound.enabled = false;
        mySieve = GetComponentInChildren<Sieve>();
        UpdateLocation();
    }

    // Update is called once per frame
    void Update()
    {
        if (transitionTimer > 0)
        {
            var ratio = (transitionTime - transitionTimer) / transitionTime;
            transition.transform.localPosition = Vector3.Lerp(transition.transform.localPosition, targetPosition, ratio);
            transitionTimer -= Time.deltaTime;
        }
    }

    public void ItemFound()
    {
        KeyItemFound[currentLocation] = true;
    }

    public void UpdatePlayArea(int index)
    {
        CurrentLocation = index;
        FindObjectOfType<SoundManager>().PlayFootStep();
        StartCoroutine(TransitionScreen());
    }

    private IEnumerator TransitionScreen()
    {
        targetPosition = new Vector3(0, 0, 0);
        transition.transform.localPosition = transitionPositionLeft;
        transitionTimer = transitionTime;

        yield return new WaitForSeconds(transitionTime);

        UpdateLocation();
        targetPosition = transitionPositionRight;
        transitionTimer = transitionTime;
    }

    private void UpdateLocation()
    {
        UpdateBackgroundSprite();
        if (CurrentLocation == 0)
        {
            myFireplace.gameObject.SetActive(true);
            myDoor.gameObject.SetActive(true);
            myChair.gameObject.SetActive(true);
            mySieve.gameObject.SetActive(false);
            riverSound.enabled = false;
        }
        else
        {
            myFireplace.gameObject.SetActive(false);
            myDoor.gameObject.SetActive(false);
            myChair.gameObject.SetActive(false);
            mySieve.gameObject.SetActive(true);
            mySieve.InitializeSieve();
            riverSound.enabled = true;
        }
        if (KeyItemFound[CurrentLocation])
        {
            keyItem.gameObject.SetActive(false);
        }
        else
        {
            keyItem.gameObject.SetActive(true);
            keyItem.UpdateItem(CurrentLocation);
        }
    }

    private void UpdateBackgroundSprite()
    {
        backgroundSpriteRenderer.sprite = backgroundSprites[CurrentLocation];
    }
}

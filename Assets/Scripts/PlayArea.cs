using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayArea : MonoBehaviour
{
    [SerializeField] private SpriteRenderer backgroundSpriteRenderer;
    [SerializeField] private Sprite[] backgroundSprites;
    [SerializeField] private KeyItem keyItem;

    private int currentLocation = 0;
    private Sieve mySieve;
    private bool[] keyItemFound = { false, false, false, false, false, false, false };

    // Start is called before the first frame update
    void Start()
    {
        mySieve = GetComponentInChildren<Sieve>();
        UpdatePlayArea(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdatePlayArea(int index)
    {
        currentLocation = index;
        UpdateBackgroundSprite();
        if (index == 0)
        {
            mySieve.gameObject.SetActive(false);
        }
        else
        {
            mySieve.gameObject.SetActive(true);
            mySieve.InitializeSieve();
        }
        if (keyItemFound[currentLocation])
        {
            keyItem.gameObject.SetActive(false);
        }
        else
        {
            keyItem.gameObject.SetActive(true);
            keyItem.UpdateItem(currentLocation);
        }
    }

    private void UpdateBackgroundSprite()
    {
        backgroundSpriteRenderer.sprite = backgroundSprites[currentLocation];
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FireStatus { EMPTY, WOOD, FIRE }

public class Rock : MonoBehaviour
{
    [SerializeField] private SpriteRenderer myHighlightSpriteRenderer;
    [SerializeField] private Sprite[] mySprites;
    [SerializeField] private Sprite[] myHighlightSprites;
    [SerializeField] private GameObject myFire;

    private PlayArea playArea;
    private SpriteRenderer mySpriteRenderer;
    private FireStatus myFireStatus = FireStatus.EMPTY;

    public FireStatus MyFireStatus { get => myFireStatus; set => myFireStatus = value; }

    // Start is called before the first frame update
    void Start()
    {
        myFire.SetActive(false);
        playArea = FindObjectOfType<PlayArea>();
        myHighlightSpriteRenderer.enabled = false;
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseOver()
    {
        if (myFireStatus == FireStatus.EMPTY)
        {
            if (playArea.KeyItemFound[3])
            {
                myHighlightSpriteRenderer.enabled = true;
            }
        }
        else if (myFireStatus == FireStatus.WOOD)
        {
            if (playArea.KeyItemFound[4])
            {
                myHighlightSpriteRenderer.enabled = true;
            }
        }
    }

    private void OnMouseExit()
    {
        myHighlightSpriteRenderer.enabled = false;
    }

    private void OnMouseDown()
    {
        if (myFireStatus == FireStatus.EMPTY)
        {
            if (playArea.KeyItemFound[3])
            {
                myFireStatus = FireStatus.WOOD;
                mySpriteRenderer.sprite = mySprites[1];
                myHighlightSpriteRenderer.sprite = myHighlightSprites[1];
                myHighlightSpriteRenderer.enabled = false;
            }
        }
        else if (myFireStatus == FireStatus.WOOD)
        {
            if (playArea.KeyItemFound[4])
            {
                myFireStatus = FireStatus.FIRE;
                myHighlightSpriteRenderer.enabled = false;
                myFire.SetActive(true);
            }
        }
    }
}

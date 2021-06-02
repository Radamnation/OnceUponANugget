using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DoorStatus { CLOSED, OPEN }

public class Door : MonoBehaviour
{
    [SerializeField] private SpriteRenderer myHighlightSpriteRenderer;
    [SerializeField] private Sprite[] mySprites;

    private PlayArea playArea;
    private SpriteRenderer mySpriteRenderer;
    private DoorStatus myDoorStatus = DoorStatus.CLOSED;
    private BoxCollider2D myBoxCollider2D;

    // Start is called before the first frame update
    void Start()
    {
        playArea = FindObjectOfType<PlayArea>();
        myHighlightSpriteRenderer.enabled = false;
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        myBoxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseOver()
    {
        if (myDoorStatus == DoorStatus.CLOSED)
        {
            if (playArea.KeyItemFound[5])
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
        if (myDoorStatus == DoorStatus.CLOSED)
        {
            if (playArea.KeyItemFound[5])
            {
                myDoorStatus = DoorStatus.OPEN;
                mySpriteRenderer.sprite = mySprites[1];
                myHighlightSpriteRenderer.enabled = false;
                myBoxCollider2D.enabled = false;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HookStatus { EMPTY, POT, FULL }

public class Hook : MonoBehaviour
{
    [SerializeField] private SpriteRenderer myHighlightSpriteRenderer;
    [SerializeField] private Sprite[] mySprites;
    [SerializeField] private Sprite[] myHighlightSprites;

    private PlayArea playArea;
    private SpriteRenderer mySpriteRenderer;
    private HookStatus myHookStatus = HookStatus.EMPTY;

    public HookStatus MyHookStatus { get => myHookStatus; set => myHookStatus = value; }

    // Start is called before the first frame update
    void Start()
    {
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
        if (myHookStatus == HookStatus.EMPTY)
        {
            if (playArea.KeyItemFound[0])
            {
                myHighlightSpriteRenderer.enabled = true;
            }
        }
        else if (myHookStatus == HookStatus.POT)
        {
            if (playArea.KeyItemFound[1] && playArea.KeyItemFound[2] && playArea.KeyItemFound[6])
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
        if (myHookStatus == HookStatus.EMPTY)
        {
            if (playArea.KeyItemFound[0])
            {
                myHookStatus = HookStatus.POT;
                mySpriteRenderer.sprite = mySprites[1];
                myHighlightSpriteRenderer.sprite = myHighlightSprites[1];
                myHighlightSpriteRenderer.enabled = false;
            }
        }
        else if (myHookStatus == HookStatus.POT)
        {
            if (playArea.KeyItemFound[1] && playArea.KeyItemFound[2] && playArea.KeyItemFound[6])
            {
                myHookStatus = HookStatus.FULL;
                myHighlightSpriteRenderer.enabled = false;
            }
        }
    }
}

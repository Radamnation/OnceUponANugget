using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chair : MonoBehaviour
{
    [SerializeField] private SpriteRenderer myHighlightSpriteRenderer;

    private PlayArea playArea;
    private Hook hook;
    private Rock rock;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        playArea = FindObjectOfType<PlayArea>();
        gameManager = FindObjectOfType<GameManager>();
        hook = FindObjectOfType<Hook>();
        rock = FindObjectOfType<Rock>();
        myHighlightSpriteRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseOver()
    {
        if (rock.MyFireStatus == FireStatus.FIRE && hook.MyHookStatus == HookStatus.FULL)
        {
            myHighlightSpriteRenderer.enabled = true;
        }
    }

    private void OnMouseExit()
    {
        myHighlightSpriteRenderer.enabled = false;
    }

    private void OnMouseDown()
    {
        if (rock.MyFireStatus == FireStatus.FIRE && hook.MyHookStatus == HookStatus.FULL)
        {
            gameManager.Win();
            myHighlightSpriteRenderer.enabled = false;
        }
    }
}

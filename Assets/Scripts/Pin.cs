using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    [SerializeField] private int myID;
    [SerializeField] private SpriteRenderer myHighlightSpriteRenderer;

    private CircleCollider2D myCircleCollider2D;
    private PlayArea playArea;

    // Start is called before the first frame update
    void Start()
    {
        myCircleCollider2D = GetComponent<CircleCollider2D>();
        playArea = FindObjectOfType<PlayArea>();
        if (playArea.CurrentLocation != myID)
        {
            myHighlightSpriteRenderer.enabled = false;
        }
        else
        {
            myHighlightSpriteRenderer.color = Color.yellow;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        myHighlightSpriteRenderer.enabled = true;
    }

    private void OnMouseExit()
    {
        if (playArea.CurrentLocation != myID)
        {
            myHighlightSpriteRenderer.enabled = false;
        }
    }

    private void OnMouseDown()
    {
        if (playArea.CurrentLocation != myID)
        {
            var pins = FindObjectsOfType<Pin>();
            foreach (Pin pin in pins)
            {
                pin.myHighlightSpriteRenderer.color = Color.white;
                pin.myHighlightSpriteRenderer.enabled = false;
            }
            myHighlightSpriteRenderer.color = Color.yellow;
            playArea.UpdatePlayArea(myID);
        }
    }
}

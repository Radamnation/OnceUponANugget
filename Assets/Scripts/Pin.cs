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
        myHighlightSpriteRenderer.enabled = false;
        myCircleCollider2D = GetComponent<CircleCollider2D>();
        playArea = FindObjectOfType<PlayArea>();
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
        myHighlightSpriteRenderer.enabled = false;
    }

    private void OnMouseDown()
    {
        playArea.UpdatePlayArea(myID);
    }
}

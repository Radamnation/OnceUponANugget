using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sieve : MonoBehaviour
{
    [SerializeField] private Sprite[] mySprites;
    [SerializeField] private SpriteRenderer myHighlightSpriteRenderer;
    [SerializeField] private float shakeThreshold = 50f;

    private bool asBeenShaken = false;
    private Vector3 myInitialPosition;
    private CapsuleCollider2D myCapsuleCollider2D;
    private SpriteRenderer mySpriteRenderer;

    private bool asEnteredWater = false;
    private Vector2 oldMouseAxis;


    // Start is called before the first frame update
    void Start()
    {
        myHighlightSpriteRenderer.enabled = false;
        myInitialPosition = transform.localPosition;
        myCapsuleCollider2D = GetComponent<CapsuleCollider2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckPosition();
        MouseShake();
    }

    private void CheckPosition()
    {
        if (transform.localPosition.y < -2)
        {
            asEnteredWater = true;
            mySpriteRenderer.sprite = mySprites[1];
        }
        else if (transform.localPosition.y > -2 && asEnteredWater == true)
        {
            asBeenShaken = false;
            mySpriteRenderer.sprite = mySprites[2];
            asEnteredWater = false;
        }
        else if (transform.localPosition.y > -2 && asBeenShaken == true)
        {
            mySpriteRenderer.sprite = mySprites[0];
        }
    }

    private void MouseShake()
    {
        Vector2 mouseAxis = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        asBeenShaken = mouseAxis.x - oldMouseAxis.x > shakeThreshold || mouseAxis.y - oldMouseAxis.y > shakeThreshold;
        oldMouseAxis = mouseAxis;
    }

    private void OnMouseOver()
    {
        myHighlightSpriteRenderer.enabled = true;
    }

    private void OnMouseExit()
    {
        myHighlightSpriteRenderer.enabled = false;
    }

    private void OnMouseDrag()
    {
        var newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(newPosition.x, newPosition.y);
    }

    private void OnMouseUp()
    {
        myHighlightSpriteRenderer.enabled = false;
        transform.localPosition = myInitialPosition;
    }
}

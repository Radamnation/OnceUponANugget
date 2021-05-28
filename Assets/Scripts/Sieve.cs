using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sieve : MonoBehaviour
{
    [SerializeField] private Sprite[] mySprites;
    [SerializeField] private SpriteRenderer myHighlightSpriteRenderer;
    [SerializeField] private float shakeThreshold = 50f;
    
    [SerializeField] private Nugget nuggetPrefab;
    [SerializeField] private float nuggetHorizontalPosition = 1.5f;
    [SerializeField] private float nuggetVerticalPosition = 0.75f;

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
            var nuggets = GetComponentsInChildren<Nugget>();
            foreach (Nugget nugget in nuggets)
            {
                Destroy(nugget.gameObject);
            }
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
            SpawnNuggets();
        }
    }

    private void SpawnNuggets()
    {
        var nuggetToSpawn = Random.Range(0, 3);
        for (int i = 0; i < nuggetToSpawn; i++)
        {
            var xPosition = Random.Range(-nuggetHorizontalPosition, nuggetHorizontalPosition);
            var yPosition = Random.Range(-nuggetVerticalPosition, nuggetVerticalPosition);
            var newNugget = Instantiate(nuggetPrefab, transform);
            newNugget.transform.localPosition = new Vector3(xPosition, yPosition, -1);
            var bigNuggetChance = Random.Range(0, 100);
            if (bigNuggetChance < 20)
            {
                newNugget.BigNugget = true;
            }
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

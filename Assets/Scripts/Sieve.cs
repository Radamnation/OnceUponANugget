using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SieveState { EMPTY, WATER, SOIL};

public class Sieve : MonoBehaviour
{
    [SerializeField] private Sprite[] mySprites;
    [SerializeField] private SpriteRenderer myHighlightSpriteRenderer;
    [SerializeField] private float shakeThreshold = 50f;
    [SerializeField] private float waterLimit = -2.5f;
    
    [SerializeField] private Nugget nuggetPrefab;
    [SerializeField] private Key keyPrefab;
    [SerializeField] private float nuggetHorizontalPosition = 1.5f;
    [SerializeField] private float nuggetVerticalPosition = 0.75f;

    private SieveState myState = SieveState.EMPTY;
    private bool asBeenShaken = false;
    private Vector3 myInitialPosition;
    private CapsuleCollider2D myCapsuleCollider2D;
    private SpriteRenderer mySpriteRenderer;
    private PlayArea playArea;

    private Vector2 oldMouseAxis;

    private void Awake()
    {
        myHighlightSpriteRenderer.enabled = false;
        myInitialPosition = transform.localPosition;
        myCapsuleCollider2D = GetComponent<CapsuleCollider2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        playArea = FindObjectOfType<PlayArea>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CheckState();
        MouseShake();
    }

    public void InitializeSieve()
    {
        myState = SieveState.EMPTY;
        mySpriteRenderer.sprite = mySprites[0];
        DestroyNuggets();
    }

    private void CheckState()
    {
        if ((myState == SieveState.EMPTY || myState == SieveState.SOIL) && transform.localPosition.y < waterLimit)
        {
            myState = SieveState.WATER;
            FindObjectOfType<SoundManager>().PlaySploosh();
            mySpriteRenderer.sprite = mySprites[1];
            DestroyNuggets();
        }
        if (myState == SieveState.WATER && transform.localPosition.y > waterLimit)
        {
            myState = SieveState.SOIL;
            mySpriteRenderer.sprite = mySprites[2];
            asBeenShaken = false;
        }
        if (myState == SieveState.SOIL && asBeenShaken == true)
        {
            myState = SieveState.EMPTY;
            FindObjectOfType<SoundManager>().PlaySieveShake();
            mySpriteRenderer.sprite = mySprites[0];
            SpawnNuggets();
        }
    }

    private void SpawnNuggets()
    {
        if (playArea.CurrentLocation != 5)
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
        else if (!playArea.KeyItemFound[playArea.CurrentLocation])
        {
            var keyChance = Random.Range(0, 100);
            if (keyChance < 50)
            {
                var xPosition = Random.Range(-nuggetHorizontalPosition, nuggetHorizontalPosition);
                var yPosition = Random.Range(-nuggetVerticalPosition, nuggetVerticalPosition);
                var newKey = Instantiate(keyPrefab, transform);
                newKey.transform.localPosition = new Vector3(xPosition, yPosition, -1);
            }
        }
    }

    private void DestroyNuggets()
    {
        var nuggets = GetComponentsInChildren<Nugget>();
        foreach (Nugget nugget in nuggets)
        {
            Destroy(nugget.gameObject);
        }
        var keys = GetComponentsInChildren<Key>();
        foreach (Key key in keys)
        {
            Destroy(key.gameObject);
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

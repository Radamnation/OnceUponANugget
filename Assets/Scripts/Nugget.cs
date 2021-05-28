using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nugget : MonoBehaviour
{
    [SerializeField] private bool bigNugget = false;
    [SerializeField] private Sprite[] mySprites;
    [SerializeField] private SpriteRenderer myHighlightSpriteRenderer;

    private SpriteRenderer mySpriteRenderer;
    private GameManager gameManager;

    public bool BigNugget { get => bigNugget; set => bigNugget = value; }

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        if (BigNugget)
        {
            SetBigNugget();
        }
        myHighlightSpriteRenderer.enabled = false;
    }

    private void SetBigNugget()
    {
        mySpriteRenderer.sprite = mySprites[2];
        myHighlightSpriteRenderer.sprite = mySprites[3];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void IncreaseScore()
    {
        if (BigNugget)
        {
            gameManager.ScoreBigNugget();
        }
        else
        {
            gameManager.ScoreNugget();
        }
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
        IncreaseScore();
        Destroy(gameObject);
    }
}

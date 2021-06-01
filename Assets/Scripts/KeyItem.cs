using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItem : MonoBehaviour
{
    [SerializeField] Vector3[] myKeyItemsPosition;
    [SerializeField] Sprite[] myKeyItemsSprites;
    [SerializeField] Sprite[] myKeyItemsHighlightSprites;
    [SerializeField] SpriteRenderer myHighlightSpriteRenderer;

    private SpriteRenderer mySpriteRenderer;
    private PlayArea playArea;

    // Start is called before the first frame update
    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        playArea = FindObjectOfType<PlayArea>();
        myHighlightSpriteRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateItem(int index)
    {
        transform.localPosition = myKeyItemsPosition[index];
        mySpriteRenderer.sprite = myKeyItemsSprites[index];
        myHighlightSpriteRenderer.sprite = myKeyItemsHighlightSprites[index];
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
        playArea.ItemFound();
        myHighlightSpriteRenderer.enabled = false;
        gameObject.SetActive(false);
    }
}

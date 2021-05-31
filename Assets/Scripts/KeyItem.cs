using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItem : MonoBehaviour
{
    [SerializeField] Vector3[] myKeyItemsPosition;
    [SerializeField] Sprite[] myKeyItemsSprites;
    [SerializeField] Sprite[] myKeyItemsHighlightSprites;
    // [SerializeField] SpriteRenderer myHighlightSpriteRenderer;

    private SpriteRenderer mySpriteRendrerer;

    // Start is called before the first frame update
    void Start()
    {
        mySpriteRendrerer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateItem(int index)
    {
        transform.localPosition = myKeyItemsPosition[index];
        mySpriteRendrerer.sprite = myKeyItemsSprites[index];
        // myHighlightSpriteRenderer.sprite = myKeyItemsHighlightSprites[index];
    }
}

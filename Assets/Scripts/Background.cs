using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] private Sprite[] backgroundSprites;

    private SpriteRenderer mySpriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        mySpriteRenderer.sprite = backgroundSprites[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateSprite(int index)
    {
        mySpriteRenderer.sprite = backgroundSprites[index];
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private SpriteRenderer myHighlightSpriteRenderer;

    private PlayArea playArea;

    // Start is called before the first frame update
    void Start()
    {
        playArea = FindObjectOfType<PlayArea>();
        myHighlightSpriteRenderer.enabled = false;
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
        playArea.ItemFound();
        FindObjectOfType<SoundManager>().PlayClick();
        Destroy(gameObject);
    }
}

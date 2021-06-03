using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    private Text myText;
    private bool active = false;

    public bool Active { get => active; set => active = value; }

    // Start is called before the first frame update
    void Start()
    {
        myText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        if (active)
        {
            myText.color = Color.yellow;
        }
    }

    private void OnMouseExit()
    {
        if (active)
        {
            myText.color = Color.white;
        }
    }

    private void OnMouseDown()
    {
        if (active)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}

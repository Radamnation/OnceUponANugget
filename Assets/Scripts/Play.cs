using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Play : MonoBehaviour
{
    private TextMeshProUGUI myTMP;
    private bool active = false;

    public bool Active { get => active; set => active = value; }

    // Start is called before the first frame update
    void Start()
    {
        myTMP = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        if (active)
        {
            myTMP.color = Color.yellow;
        }
    }

    private void OnMouseExit()
    {
        if (active)
        {
            myTMP.color = Color.white;
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

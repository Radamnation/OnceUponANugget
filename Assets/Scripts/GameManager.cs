using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float timeLimit = 12000f;
    [SerializeField] private Text timerText;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = timeLimit;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime * 100;
        UpdateTime();
    }

    private void UpdateTime()
    {
        int milliseconds = (int) timer % 100;
        int seconds = (int) (timer - milliseconds) / 100 % 60;
        int minutes = (int) (timer - milliseconds - seconds * 60) / 100 / 60;
        timerText.text = minutes + ":" + seconds + "." + milliseconds;
    }
}

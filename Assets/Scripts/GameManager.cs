using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float timeLimit = 12000f;
    [SerializeField] private Text timerText;

    [SerializeField] private Text nuggetText;
    [SerializeField] private Text bigNuggetText;

    private int nuggetScore = 0;
    private int bigNuggetScore = 0;
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
        if (timer < 0)
        {
            Loose();
        }
        else
        {
            UpdateTime();
        }
    }

    private void UpdateTime()
    {
        int milliseconds = (int) timer % 100;
        int seconds = (int) (timer - milliseconds) / 100 % 60;
        // int minutes = (int) (timer - milliseconds - seconds * 60) / 1000 / 60;
        timerText.text = seconds + "." + milliseconds;
    }

    public void ScoreNugget()
    {
        nuggetScore++;
        nuggetText.text = "";
        for (int i = nuggetScore.ToString().Length; i < 3; i++)
        {
            nuggetText.text += "0";
        }
        nuggetText.text += nuggetScore.ToString();
    }

    public void ScoreBigNugget()
    {
        bigNuggetScore++;
        bigNuggetText.text = "";
        for (int i = bigNuggetScore.ToString().Length; i < 3; i++)
        {
            bigNuggetText.text += "0";
        }
        bigNuggetText.text += bigNuggetScore.ToString();
    }

    private void Loose()
    {
        Debug.Log("You Lose");
    }

    public void Win()
    {
        Debug.Log("You Win");
    }
}

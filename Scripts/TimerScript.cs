using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
    public Text timeText;
    public float matchLengthSeconds;

    private float minutes;
    private float seconds;

    private AccountScript accountScript;

    private ScoreController scoreController;


    private void Awake()
    {
        accountScript = FindObjectOfType<AccountScript>();

        scoreController = FindObjectOfType<ScoreController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(matchLengthSeconds >= 0f)
        {
            DisplayTime();
        }

        else
        {
            accountScript.EndGame(int.Parse(scoreController.playerScoreText.text), int.Parse(scoreController.opponentScoreText.text));
            SceneManager.LoadScene("EndGame");
        }
    }

   

    private void DisplayTime()
    {
        minutes = Mathf.FloorToInt(matchLengthSeconds / 60);
        seconds = Mathf.FloorToInt(matchLengthSeconds % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        matchLengthSeconds = matchLengthSeconds - Time.deltaTime;

    }
}

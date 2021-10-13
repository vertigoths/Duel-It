using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerScriptTwoPlayer : MonoBehaviour
{
    public Text timeText;
    public float matchLengthSeconds;

    private float minutes;
    private float seconds;

    // Update is called once per frame
    void Update()
    {
        if (matchLengthSeconds >= 0f)
        {
            DisplayTime();
        }

        else
        {
            SceneManager.LoadScene("Lobby");
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

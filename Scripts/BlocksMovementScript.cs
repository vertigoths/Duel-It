using UnityEngine;
using UnityEngine.UI;

public class BlocksMovementScript : MonoBehaviour
{
    public GameObject[] obstacles;
    private float count;

    private bool flag;

    public Text highScoreText;

    private void Awake()
    {
        highScoreText.text = PlayerPrefs.GetInt("CollectGameHighScore").ToString();
    }

    private void Update()
    {
        obstacles[0].transform.Translate(new Vector3(count * Time.deltaTime, 0f, 0f));
        obstacles[1].transform.Translate(new Vector3(-count * Time.deltaTime, 0f, 0f));
        obstacles[2].transform.Translate(new Vector3(0f, count * Time.deltaTime, 0f));
        obstacles[3].transform.Translate(new Vector3(0f, -count * Time.deltaTime, 0f));

        if (count > 0.99f)
        {
            flag = false;
        }

        else if(count < -0.99f)
        {
            flag = true;
        }

        if (flag)
        {
            count += Time.deltaTime;
        }

        else
        {
            count -= Time.deltaTime;
        }
    }

    
}

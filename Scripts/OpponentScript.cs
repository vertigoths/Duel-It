using UnityEngine;
using UnityEngine.UI;

public class OpponentScript : MonoBehaviour
{
    public GameObject puck;
    private Rigidbody2D rigidBody;
    private Vector2 temp;

    public Text highScoreText;


    private void Awake()
    {
        highScoreText.text = PlayerPrefs.GetInt("HockeyGameHighScore").ToString();

        rigidBody = GetComponent<Rigidbody2D>();
        temp = new Vector2(0f, 0f);
       
    }

    private void FixedUpdate()
    {
        if ((puck.transform.position.x < -2.15f) || (puck.transform.position.x > 2.15f))
        {
            temp.x = Mathf.Clamp(temp.x, -2.10f, 2.10f);
            temp.y = puck.transform.position.y;
            puck.transform.position = Vector2.Lerp(puck.transform.position, temp, Time.fixedDeltaTime);
        }

        if ((puck.transform.position.y < 4.5f) && (puck.transform.position.y > -0.01f))
        {
            rigidBody.MovePosition(Vector2.MoveTowards(rigidBody.position, puck.transform.position, Random.Range(9f,15f) * Time.fixedDeltaTime));
        }

        else
        {
            temp.x = 0f;
            temp.x = Mathf.Clamp(temp.x, -2f, 2f);
            temp.y = 3.97f;
            temp.y = Mathf.Clamp(temp.y, 0f, 4f);
            rigidBody.MovePosition(Vector2.MoveTowards(rigidBody.position, temp, Random.Range(5f,6f) * Time.fixedDeltaTime));
        }
    }

}

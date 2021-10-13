using UnityEngine;
using UnityEngine.UI;

public class ControlColliderScript : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private Vector2 tempVector;

    public Text playerScoreText;
    public Text opponentScoreText;

    private int score;

    public AudioSource goalAudio;
    public AudioSource goalAudioOpponent;

    private void Awake()
    {
        tempVector = new Vector2(0f, 0f);
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    { 
    
        rigidBody = collision.collider.GetComponent<Rigidbody2D>();

        if (gameObject.CompareTag("Background"))
        {
            collision.collider.transform.position = new Vector3(0f, 0f, 0f);
        }


        else if (gameObject.CompareTag("PlayerGoalpost"))
        {
            collision.collider.transform.position = new Vector3(0f, -1f, 0f);
            score = int.Parse(opponentScoreText.text);
            score++;
            opponentScoreText.text = score.ToString();
            goalAudioOpponent.Play();
        }


        else if (gameObject.CompareTag("OpponentGoalpost"))
        {
            collision.collider.transform.position = new Vector3(0f, 1f, 0f);
            score = int.Parse(playerScoreText.text);
            score++;
            playerScoreText.text = score.ToString();
            goalAudio.Play();
        }

        rigidBody.velocity = tempVector;
        rigidBody = null;

    }
}

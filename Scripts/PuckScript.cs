using UnityEngine;

public class PuckScript : MonoBehaviour
{
    private Rigidbody2D rigidBody;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if((rigidBody.velocity.x > 0f) && (rigidBody.velocity.y > 0f))
        {
            rigidBody.velocity = Vector2.ClampMagnitude(rigidBody.velocity, 25f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        audioSource.Play();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BladeScript : MonoBehaviour
{
    public Text scoreText;
    public Text animationText;

    public Text highScoreText;

    private Vector2 positionVector;
    private Vector3 touchPosition;

    private Rigidbody2D rigidBody;

    private FruitSpawnerScript fruitSpawnerScript;

    private CircleCollider2D circleCollider;

    private int score;

    private AudioSource audioSource;



    private void Awake()
    {
        highScoreText.text = PlayerPrefs.GetInt("SliceGameHighScore").ToString();

        audioSource = GetComponent<AudioSource>();
        fruitSpawnerScript = FindObjectOfType<FruitSpawnerScript>();
        rigidBody = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
    }

    private void Update()
    {
    
        if((!circleCollider.enabled) && (Input.touchCount == 1))
        {
            circleCollider.enabled = true;
        }

        for(int i = 0; i < Input.touchCount; i++)
        {
            touchPosition = Camera.main.ScreenToWorldPoint(Input.touches[i].position);
            positionVector.x = Mathf.Clamp(touchPosition.x, -2f, 2f);
            positionVector.y = Mathf.Clamp(touchPosition.y, -4f, 4f);
            rigidBody.MovePosition(positionVector);
        }

        if((gameObject.activeInHierarchy) && (Input.touchCount == 0))
        {
            circleCollider.enabled = false;
        }

        
        

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        score++;
        scoreText.text = score.ToString();

        audioSource.Play();

        if(score == 20)
        {
            animationText.gameObject.SetActive(true);
        }

        else if(score == 25)
        {
            animationText.gameObject.SetActive(false);
        }

        else if(score == 50)
        {
            animationText.gameObject.SetActive(true);
            animationText.text = "Excellent";
        }

        else if(score == 55)
        {
            animationText.gameObject.SetActive(false);
        }

        else if(score == 100)
        {
            animationText.gameObject.SetActive(true);
            animationText.text = "Legendary";
        }

        if (collision.collider.name.Equals("Apple(Clone)"))
        {
            if(fruitSpawnerScript.slicedApplePool.Count != 0)
            {
                GameObject temp = fruitSpawnerScript.slicedApplePool.Dequeue();
                temp.SetActive(true);
                temp.transform.position = collision.collider.gameObject.transform.position;
            }

            if (fruitSpawnerScript.slicedApplePool.Count != 0)
            {
                GameObject temp = fruitSpawnerScript.slicedApplePool.Dequeue();
                temp.SetActive(true);
                temp.transform.position = collision.collider.gameObject.transform.position;
            }

            collision.collider.gameObject.SetActive(false);

            fruitSpawnerScript.fruitPool.Enqueue(collision.collider.gameObject);
        }

        else if (collision.collider.name.Equals("Banana(Clone)"))
        {
            if (fruitSpawnerScript.slicedBananaPool.Count != 0)
            {
                GameObject temp = fruitSpawnerScript.slicedBananaPool.Dequeue();
                temp.SetActive(true);
                temp.transform.position = collision.collider.gameObject.transform.position;
            }

            if (fruitSpawnerScript.slicedApplePool.Count != 0)
            {
                GameObject temp = fruitSpawnerScript.slicedBananaPool.Dequeue();
                temp.SetActive(true);
                temp.transform.position = collision.collider.gameObject.transform.position;
            }

            collision.collider.gameObject.SetActive(false);

            fruitSpawnerScript.fruitPool.Enqueue(collision.collider.gameObject);
        }

        else if (collision.collider.name.Equals("Watermelon(Clone)"))
        {
            if (fruitSpawnerScript.slicedWatermelonPool.Count != 0)
            {
                GameObject temp = fruitSpawnerScript.slicedWatermelonPool.Dequeue();
                temp.SetActive(true);
                temp.transform.position = collision.collider.gameObject.transform.position;
            }

            if (fruitSpawnerScript.slicedWatermelonPool.Count != 0)
            {
                GameObject temp = fruitSpawnerScript.slicedWatermelonPool.Dequeue();
                temp.SetActive(true);
                temp.transform.position = collision.collider.gameObject.transform.position;
            }

            collision.collider.gameObject.SetActive(false);

            fruitSpawnerScript.fruitPool.Enqueue(collision.collider.gameObject);
        }
    }
}

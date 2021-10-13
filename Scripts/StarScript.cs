using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarScript : MonoBehaviour
{
    private CoinSpawnerScript coinSpawnerScript;

    private AudioSource audioSource;

    private void Awake()
    {
        coinSpawnerScript = FindObjectOfType<CoinSpawnerScript>();
        audioSource = coinSpawnerScript.gameObject.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Equals("Roundy"))
        {
            if(Random.Range(0,11) == 0)
            {
                coinSpawnerScript.boostText.gameObject.SetActive(true);
                coinSpawnerScript.playerScore++;
            }

            coinSpawnerScript.playerScore++;
            coinSpawnerScript.playerScoreText.text = coinSpawnerScript.playerScore.ToString();

            audioSource.Play();
        }

        else if (collision.name.Equals("BadRoundy"))
        {
            if (Random.Range(0, 11) == 0)
            {
                coinSpawnerScript.boostText.gameObject.SetActive(true);
                coinSpawnerScript.opponentScore++;
            }

            coinSpawnerScript.opponentScore++;
            coinSpawnerScript.opponentScoreText.text = coinSpawnerScript.opponentScore.ToString();

            audioSource.Play();
        }

        gameObject.transform.position = new Vector3(Random.Range(-2f, 2f), Random.Range(-4f, 4f), 0f);
        gameObject.SetActive(false);
        coinSpawnerScript.coins.Enqueue(gameObject);
    }


    
}

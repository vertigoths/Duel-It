using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinSpawnerScriptTwoPlayer : MonoBehaviour
{
    public GameObject coinPrefab;
    public Queue<GameObject> coins;

    public int coinsAmount;
    private bool isGenerated;


    public int playerScore;
    public int opponentScore;
    public Text playerScoreText;
    public Text opponentScoreText;
    public Text boostText;


    private void Awake()
    {
        coins = new Queue<GameObject>();

        for (int i = 0; i < coinsAmount; i++)
        {
            GameObject coin = Instantiate(coinPrefab, new Vector3(Random.Range(-2f, 2f), Random.Range(-4f, 4f), 0f), Quaternion.identity);
            coin.SetActive(false);
            coins.Enqueue(coin);
        }
    }


    private void Update()
    {
        if (!isGenerated)
        {
            StartCoroutine("GenerateCoin");
        }
    }


    private IEnumerator GenerateCoin()
    {
        if (coins.Count != 0)
        {
            isGenerated = true;

            yield return new WaitForSeconds(1.2f);

            coins.Dequeue().SetActive(true);

            isGenerated = false;
        }
    }


}

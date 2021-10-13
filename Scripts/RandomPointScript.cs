using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RandomPointScript : MonoBehaviour
{
    private bool isGenerated;
    private int score;
    public Text opponentScoreText;


    private void Update()
    {
        if (!isGenerated)
        {
            StartCoroutine("GenerateRandomScore");
        }
    }

    private IEnumerator GenerateRandomScore()
    {
        isGenerated = true;
        yield return new WaitForSeconds(Random.Range(0.4f,0.57f));
        score += Random.Range(0, 2);
        opponentScoreText.text = score.ToString();
        isGenerated = false;
    }
}

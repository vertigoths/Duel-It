using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public int playerPoints;
    public int enemyPoints;
    public int playerCardsAmount;
    public int enemyCardsAmount;

    public Image[] cardHolder;

    public Sprite cardback;

    public Text playerScoreText;
    public Text opponentScoreText;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }


    public void DistributePoints(int points,int amount,int player) 
    { 
        if(player == 0)
        {
            playerPoints += points;
            playerCardsAmount += amount;
            cardHolder[1].sprite = cardback;
            playerScoreText.text = playerPoints.ToString();
            audioSource.Play();
        }

        else 
        {
            enemyPoints += points;
            enemyCardsAmount += amount;
            cardHolder[0].sprite = cardback;
            opponentScoreText.text = enemyPoints.ToString();
        }
    }
}

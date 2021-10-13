using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextController : MonoBehaviour
{
    public Text playerScoreText;
    public Text opponentScoreText;

    public Text infoText;

    public Text positiveText;
    public Text negativeText;
    public Text drawText;

    
    private AccountScript accountScript;

    private RewardedAdsScript ads;
    


    private void Awake()
    {
        ads = FindObjectOfType<RewardedAdsScript>();
        accountScript = FindObjectOfType<AccountScript>();

        positiveText.gameObject.SetActive(false);
        negativeText.gameObject.SetActive(false);
        drawText.gameObject.SetActive(false);

        playerScoreText.text = accountScript.playerDuelWins.ToString();
        opponentScoreText.text = accountScript.opponentDuelWins.ToString();

        if(accountScript.count == 3)
        {
            if(accountScript.playerDuelWins > accountScript.opponentDuelWins)
            {
                PlayerPrefs.SetInt("WinsTotal", PlayerPrefs.GetInt("WinsTotal") + 1);
            }

            else if(accountScript.opponentDuelWins > accountScript.playerDuelWins)
            {
                PlayerPrefs.SetInt("LosesTotal", PlayerPrefs.GetInt("LosesTotal") + 1);
            }

            

            StartCoroutine("GoBackToMenu");

            
        }

        else
        {
            StartCoroutine("StartNextMatch");
        }
    }


    public IEnumerator GoBackToMenu()
    {
        if(accountScript.playerDuelWins > accountScript.opponentDuelWins)
        {
            positiveText.gameObject.SetActive(true);
        }

        else if(accountScript.opponentDuelWins > accountScript.playerDuelWins)
        {
            negativeText.gameObject.SetActive(true);
        }

        else
        {
            drawText.gameObject.SetActive(true);
        }

        infoText.text = "Returning to menu...";

        yield return new WaitForSeconds(1.5f);

        ads.ShowRewardedVideo();


    }


    public IEnumerator StartNextMatch()
    {
        yield return new WaitForSeconds(1f);

        infoText.text = "Next map is ready!";

        yield return new WaitForSeconds(1f);

        accountScript.LoadGame();
    }
}

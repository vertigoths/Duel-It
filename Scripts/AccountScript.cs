using UnityEngine;
using UnityEngine.SceneManagement;

public class AccountScript : MonoBehaviour
{
    private AccountScript accountScript;
    private int[] array;
    public int count;

    public int playerDuelWins;
    public int opponentDuelWins;


    void Start()
    {
        if(accountScript == null) 
        {
            accountScript = this;
            DontDestroyOnLoad(this);
        }

        else if(this != accountScript) 
        {
            Destroy(gameObject);
        }
    }


    public void InitializeGames(int[] array)
    {
        playerDuelWins = 0;
        opponentDuelWins = 0;
        count = 0;
        this.array = array;
        LoadGame();
    }


    public void LoadGame()
    {
        if (array[count] == 0)
        {
            SceneManager.LoadScene("CardGame");
        }

        else if (array[count] == 1)
        {
            SceneManager.LoadScene("SliceGame");
        }

        else if (array[count] == 2)
        {
            SceneManager.LoadScene("CollectGame");
        }

        else if (array[count] == 3)
        {
            SceneManager.LoadScene("HockeyGame");
        }

        else if (array[count] == 4)
        {
            SceneManager.LoadScene("JumpGame");
        }

        count++;
    }


    public void EndGame(int currentPlayerPoint,int currentOpponentPoint)
    {
        if(currentPlayerPoint > currentOpponentPoint)
        {
            playerDuelWins++;
        }

        else if(currentOpponentPoint> currentPlayerPoint)
        {
            opponentDuelWins++;
        }


        if(array[count-1] == 0)
        {
            if(currentPlayerPoint > PlayerPrefs.GetInt("CardGameHighScore"))
            {
                PlayerPrefs.SetInt("CardGameHighScore", currentPlayerPoint);
            }
        }

        else if (array[count - 1] == 1)
        {
            if (currentPlayerPoint > PlayerPrefs.GetInt("SliceGameHighScore"))
            {
                PlayerPrefs.SetInt("SliceGameHighScore", currentPlayerPoint);
            }
        }

        else if (array[count - 1] == 2)
        {
            if (currentPlayerPoint > PlayerPrefs.GetInt("CollectGameHighScore"))
            {
                PlayerPrefs.SetInt("CollectGameHighScore", currentPlayerPoint);
            }
        }

        else if (array[count - 1] == 3)
        {
            if (currentPlayerPoint > PlayerPrefs.GetInt("HockeyGameHighScore"))
            {
                PlayerPrefs.SetInt("HockeyGameHighScore", currentPlayerPoint);
            }
        }

        else if (array[count - 1] == 4)
        {
            if (currentPlayerPoint > PlayerPrefs.GetInt("JumpGameHighScore"))
            {
                PlayerPrefs.SetInt("JumpGameHighScore", currentPlayerPoint);
            }
        }
    }
    
}

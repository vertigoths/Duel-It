using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyButtonController : MonoBehaviour
{
    public void OnDuel()
    {
        SceneManager.LoadScene("GameChooseScreen");
    }

    public void LoadCardGameTwoPlayer()
    {
        SceneManager.LoadScene("TwoPlayerCardGame");
    }

    public void LoadSliceGameTwoPlayer()
    {
        SceneManager.LoadScene("TwoPlayerSliceGame");
    }

    public void LoadCollectGameTwoPlayer()
    {
        SceneManager.LoadScene("TwoPlayerCollectGame");
    }

    public void LoadHockeyGameTwoPlayer()
    {
        SceneManager.LoadScene("TwoPlayerHockeyGame");
    }

    public void LoadJumpGameTwoPlayer()
    {
        SceneManager.LoadScene("TwoPlayerJumpGame");
    }
}

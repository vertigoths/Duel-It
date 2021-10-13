using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public Text text;
    public Text placeHolder;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(text.text);
        if (PlayerPrefs.HasKey("Username")) 
        {
            SceneManager.LoadScene("Lobby");
        }
    }



    public void OnGameStart() 
    {
        if (text.text.Equals(""))
        {
            PlayerPrefs.SetString("Username", "Guest#" + Random.Range(5000,50000));
            SceneManager.LoadScene("Lobby");
        }
        else 
        {
            PlayerPrefs.SetString("Username", text.text);
            SceneManager.LoadScene("Lobby");
        }
    }
}

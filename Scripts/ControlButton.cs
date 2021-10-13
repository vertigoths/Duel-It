using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ControlButton : MonoBehaviour
{
    public Text helpText;
    private int count;
    private bool isPressed;

    public Text highScoreText;

    private void Awake()
    {
        highScoreText.text = PlayerPrefs.GetInt("CardGameHighScore").ToString();
    }


    public void OnClick()
    {
        if (!isPressed)
        {
            if (count % 4 == 0)
            {
                helpText.text = "Game called Sipti";
            }

            else if (count % 4 == 1)
            {
                helpText.text = "Drag same cards";
            }

            else if (count % 4 == 2)
            {
                helpText.text = "Beware worthless cards!";
            }

            else
            {
                helpText.text = "J takes all";
            }

            helpText.gameObject.SetActive(true);
            StartCoroutine("CloseText");
            count++;
        }
    }


    private IEnumerator CloseText()
    {
        isPressed = true;
        yield return new WaitForSeconds(2f);
        isPressed = false;
        helpText.gameObject.SetActive(false);
    }
}

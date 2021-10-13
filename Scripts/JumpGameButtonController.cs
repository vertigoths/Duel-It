using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class JumpGameButtonController : MonoBehaviour
{
    private CharacterScript characterScript;
    private GameController gameController;
    public float differenceX;

    private Camera currentCamera;

    public GameObject eventSystem;

    private AudioSource audioSource;

    public Text highScoreText;

    private void Awake()
    {
        highScoreText.text = PlayerPrefs.GetInt("JumpGameHighScore").ToString();
        audioSource = GetComponent<AudioSource>();
        currentCamera = Camera.main;
        characterScript = FindObjectOfType<CharacterScript>();
        gameController = FindObjectOfType<GameController>();
    }


    public void OnRightClick()
    {

        if (!gameController.lastDirection)
        {
            StartCoroutine("MoveRight");
            characterScript.score++;
            audioSource.Play();
        }

        else
        {
            if(characterScript.score > 0)
            {
                characterScript.score--;
            }
        }

        characterScript.scoreText.text = characterScript.score.ToString();
    }

    public void OnLeftClick()
    {
        if (gameController.lastDirection)
        {
            StartCoroutine("MoveLeft");
            characterScript.score++;
            audioSource.Play();
        }

        else
        {
            if (characterScript.score > 0)
            {
                characterScript.score--;
            }
        }

        characterScript.scoreText.text = characterScript.score.ToString();
    }



    private IEnumerator MoveRight()
    {
        eventSystem.SetActive(false);

        characterScript.animator.SetBool("isJump", true);
        
        for(int i = 0; i < 66; i++)
        {
            currentCamera.transform.position = Vector3.Lerp(currentCamera.transform.position, new Vector3(0f, characterScript.transform.position.y + 0.76f, -10f), 5f * Time.deltaTime);
            characterScript.transform.position = Vector3.Lerp(characterScript.transform.position, new Vector3(gameController.nextGameObject.transform.position.x + differenceX - 0.27f, gameController.nextGameObject.transform.position.y + 1.06f, 0f), 5f * Time.deltaTime);
            yield return new WaitForSeconds(0.001f);
        }

        characterScript.animator.SetBool("isJump", false);
        gameController.GeneratePlatform();

        eventSystem.SetActive(true);
    }


    private IEnumerator MoveLeft()
    {
        eventSystem.SetActive(false);

        characterScript.animator.SetBool("isJump", true);
        
        for (int i = 0; i < 66; i++)
        {
            currentCamera.transform.position = Vector3.Lerp(currentCamera.transform.position, new Vector3(0f, characterScript.transform.position.y + 0.76f, -10f), 5f * Time.deltaTime);
            characterScript.transform.position = Vector3.Lerp(characterScript.transform.position, new Vector3(gameController.nextGameObject.transform.position.x + differenceX, gameController.nextGameObject.transform.position.y + 1.06f, 0f) , 5f * Time.deltaTime);
            yield return new WaitForSeconds(0.001f);
        }
        
        characterScript.animator.SetBool("isJump", false);
        gameController.GeneratePlatform();

        eventSystem.SetActive(true);
    }
}

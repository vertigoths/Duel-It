using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class JumpGameButtonControllerTwoPlayer : MonoBehaviour
{
    private CharacterScriptTwoPlayer characterScript;
    private CharacterScriptUpPlayer characterScriptUp;
    private GameControllerScriptTwoPlayer gameController;
    private GameControllerScriptUpPlayer gameControllerUp;
    public float differenceX;

    [SerializeField] private Camera[] currentCameras;

    public GameObject[] eventSystems;

    private AudioSource audioSource;

    public Text highScoreText;

    private void Awake()
    {
        highScoreText.text = PlayerPrefs.GetInt("JumpGameHighScore").ToString();
        audioSource = GetComponent<AudioSource>();
        characterScript = FindObjectOfType<CharacterScriptTwoPlayer>();
        characterScriptUp = FindObjectOfType<CharacterScriptUpPlayer>();
        gameController = FindObjectOfType<GameControllerScriptTwoPlayer>();
        gameControllerUp = FindObjectOfType<GameControllerScriptUpPlayer>();
    }


    public void OnRightClick()
    {
        if (eventSystems[0].activeInHierarchy)
        {
            if (!gameController.lastDirection)
            {
                StartCoroutine("MoveRight");
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
    }

    public void OnRightClickTwoPlayer()
    {
        if (eventSystems[1].activeInHierarchy)
        {
            if (!gameControllerUp.lastDirection)
            {
                StartCoroutine("MoveRightUp");
                characterScript.opponentScore++;
                audioSource.Play();
            }

            else
            {
                if (characterScript.opponentScore > 0)
                {
                    characterScript.opponentScore--;
                }
            }

            characterScript.opponentText.text = characterScript.opponentScore.ToString();
        }
    }

    public void OnLeftClickTwoPlayer()
    {
        if (eventSystems[1].activeInHierarchy)
        {
            if (gameControllerUp.lastDirection)
            {
                StartCoroutine("MoveLeftUp");
                characterScript.opponentScore++;
                audioSource.Play();
            }

            else
            {
                if (characterScript.opponentScore > 0)
                {
                    characterScript.opponentScore--;
                }
            }

            characterScript.opponentText.text = characterScript.opponentScore.ToString();
        }
    }

    public void OnLeftClick()
    {
        if (eventSystems[0].activeInHierarchy)
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
    }



    private IEnumerator MoveRight()
    {
        eventSystems[0].SetActive(false);

        characterScript.animator.SetBool("isJump", true);

        for (int i = 0; i < 66; i++)
        {
            currentCameras[0].transform.position = Vector3.Lerp(currentCameras[0].transform.position, new Vector3(0f, characterScript.transform.position.y + 0.76f, -10f), 5f * Time.deltaTime);
            characterScript.transform.position = Vector3.Lerp(characterScript.transform.position, new Vector3(gameController.nextGameObject.transform.position.x + differenceX - 0.27f, gameController.nextGameObject.transform.position.y + 2.26f, 0f), 5f * Time.deltaTime);
            yield return new WaitForSeconds(0.001f);
        }

        characterScript.animator.SetBool("isJump", false);
        gameController.GeneratePlatform();

        eventSystems[0].SetActive(true);
    }

    private IEnumerator MoveRightUp()
    {
        eventSystems[1].SetActive(false);

        characterScriptUp.animator.SetBool("isJump", true);

        for (int i = 0; i < 66; i++)
        {
            currentCameras[1].transform.position = Vector3.Lerp(currentCameras[1].transform.position, new Vector3(19.4f, characterScriptUp.transform.position.y + 0.76f, -10f), 5f * Time.deltaTime);
            characterScriptUp.transform.position = Vector3.Lerp(characterScriptUp.transform.position, new Vector3(gameControllerUp.nextGameObject.transform.position.x + differenceX - 0.27f, gameControllerUp.nextGameObject.transform.position.y + 2.26f, 0f), 5f * Time.deltaTime);
            yield return new WaitForSeconds(0.001f);
        }

        characterScriptUp.animator.SetBool("isJump", false);
        gameControllerUp.GeneratePlatform();

        eventSystems[1].SetActive(true);
    }


    private IEnumerator MoveLeft()
    {
        eventSystems[0].SetActive(false);

        characterScript.animator.SetBool("isJump", true);

        for (int i = 0; i < 66; i++)
        {
            currentCameras[0].transform.position = Vector3.Lerp(currentCameras[0].transform.position, new Vector3(0f, characterScript.transform.position.y + 0.76f, -10f), 5f * Time.deltaTime);
            characterScript.transform.position = Vector3.Lerp(characterScript.transform.position, new Vector3(gameController.nextGameObject.transform.position.x + differenceX, gameController.nextGameObject.transform.position.y + 2.26f, 0f), 5f * Time.deltaTime);
            yield return new WaitForSeconds(0.001f);
        }

        characterScript.animator.SetBool("isJump", false);
        gameController.GeneratePlatform();

        eventSystems[0].SetActive(true);
    }


    private IEnumerator MoveLeftUp()
    {
        eventSystems[1].SetActive(false);

        characterScriptUp.animator.SetBool("isJump", true);

        for (int i = 0; i < 66; i++)
        {
            currentCameras[1].transform.position = Vector3.Lerp(currentCameras[1].transform.position, new Vector3(19.4f, characterScriptUp.transform.position.y + 0.76f, -10f), 5f * Time.deltaTime);
            characterScriptUp.transform.position = Vector3.Lerp(characterScriptUp.transform.position, new Vector3(gameControllerUp.nextGameObject.transform.position.x + differenceX, gameControllerUp.nextGameObject.transform.position.y + 2.26f, 0f), 5f * Time.deltaTime);
            yield return new WaitForSeconds(0.001f);
        }

        characterScriptUp.animator.SetBool("isJump", false);
        gameControllerUp.GeneratePlatform();

        eventSystems[1].SetActive(true);
    }
}

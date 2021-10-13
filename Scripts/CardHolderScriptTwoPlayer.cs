using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CardHolderScriptTwoPlayer : MonoBehaviour, IDropHandler
{
    public Image lastCard;
    public Sprite UIMask;
    public GameObject eventSystem;

    private PlaceHolderScriptTwoPlayer placeHolderScript;
    private PlayerScript playerScript;

    private AccountScript accountScript;

    private int turnCount;

    private void Awake()
    {
        accountScript = FindObjectOfType<AccountScript>();
        placeHolderScript = FindObjectOfType<PlaceHolderScriptTwoPlayer>();
        playerScript = FindObjectOfType<PlayerScript>();
    }


    public void OnDrop(PointerEventData eventData)
    {
        if ((eventData.pointerDrag != null) && (eventData.pointerDrag.GetComponent<Image>().sprite != UIMask))
        {
            lastCard.sprite = eventData.pointerDrag.GetComponent<Image>().sprite;
            eventData.pointerDrag.GetComponent<Image>().sprite = UIMask;
            placeHolderScript.CalculatePoints(eventData.pointerDrag.name);


            if (placeHolderScript.ChecksIfAnyoneTakesAll(eventData.pointerDrag.name))
            {
                if (eventData.pointerDrag.tag.Equals("Player"))
                {
                    if (placeHolderScript.currentCardsAmount == 2)
                    {
                        playerScript.playerPoints += 10;
                    }

                    placeHolderScript.ClearTheTable();

                    playerScript.DistributePoints(placeHolderScript.currentCardsPoints, placeHolderScript.currentCardsAmount, 0);

                    placeHolderScript.currentCardsPoints = 0;
                    placeHolderScript.currentCardsAmount = 0;
                    placeHolderScript.lastWinner = 0;
                }

                else
                {
                    if (placeHolderScript.currentCardsAmount == 2)
                    {
                        playerScript.enemyPoints += 10;
                    }

                    placeHolderScript.ClearTheTable();

                    playerScript.DistributePoints(placeHolderScript.currentCardsPoints, placeHolderScript.currentCardsAmount, 1);

                    placeHolderScript.currentCardsPoints = 0;
                    placeHolderScript.currentCardsAmount = 0;
                    placeHolderScript.lastWinner = 1;
                }

            }

            placeHolderScript.lastCard = eventData.pointerDrag.name;

            turnCount++;

            if (turnCount == 48)
            {
                playerScript.DistributePoints(placeHolderScript.currentCardsPoints, placeHolderScript.currentCardsAmount, placeHolderScript.lastWinner);

                SceneManager.LoadScene("Lobby");
            }

            StartCoroutine("AddDelay");


        }
    }



    public IEnumerator AddDelay()
    {
        eventSystem.SetActive(false);
        yield return new WaitForSeconds(1f);


        if (turnCount == 48)
        {
            playerScript.DistributePoints(placeHolderScript.currentCardsPoints, placeHolderScript.currentCardsAmount, placeHolderScript.lastWinner);

            SceneManager.LoadScene("Lobby");
        }

        else if (turnCount % 8 == 0)
        {
            placeHolderScript.DealCards();
            yield return new WaitForSeconds(0.5f);
        }

        eventSystem.SetActive(true);
    }
}

using UnityEngine;
using UnityEngine.UI;

public class PlaceHolderScriptTwoPlayer : MonoBehaviour
{
    public CardObject[] tempArray;
    public Image[] placeHolder;
    public Sprite cardback;
    public Sprite UIMask;

    private int indicator;

    public int currentCardsAmount;
    public int currentCardsPoints;

    public string lastCard;


    public Sprite[] opponentCards;


    private PlayerScript playerScript;


    public int lastWinner;

    private AudioSource audioSource;

    public AudioSource audioSource2;




    public void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        playerScript = FindObjectOfType<PlayerScript>();
        opponentCards = new Sprite[4];
        ShuffleArray(tempArray);
        DealCardsToMiddle(placeHolder, tempArray);
        audioSource.Play();
        DealCards();
    }



    private void ShuffleArray(CardObject[] tempArray)
    {
        for (int i = 0; i < tempArray.Length * 3; i++)
        {
            SwapElements(tempArray, Random.Range(0, tempArray.Length), Random.Range(0, tempArray.Length));
        }
    }



    private void SwapElements(CardObject[] tempArray, int first, int second)
    {
        CardObject temp = tempArray[first];
        tempArray[first] = tempArray[second];
        tempArray[second] = temp;
    }



    public void DealCards()
    {
        for (int i = 0; i < 4; i++)
        {
            placeHolder[i].sprite = tempArray[indicator + i].sprite;
            placeHolder[i].name = tempArray[indicator + i].name;
        }

        indicator += 4;

        for (int i = 0; i < 4; i++)
        {
            placeHolder[i + 8].sprite = tempArray[indicator + i].sprite;
            placeHolder[i + 8].name = tempArray[indicator + i].name;
            opponentCards[i] = tempArray[indicator + i].sprite;
        }

        indicator += 4;

        audioSource.Play();
    }



    private void DealCardsToMiddle(Image[] placeHolder, CardObject[] tempArray)
    {
        for (int i = 0; i < 3; i++)
        {
            placeHolder[i + 4].sprite = cardback;
            placeHolder[i + 4].name = tempArray[i].name;
            CalculatePoints(tempArray[i].name);
            audioSource.Play();
        }

        placeHolder[7].sprite = tempArray[3].sprite;
        placeHolder[7].name = tempArray[3].name;

        CalculatePoints(tempArray[3].name);

        indicator = 4;

        lastCard = tempArray[3].name;
    }



    public void CalculatePoints(string str)
    {

        if (str.Length == 3)
        {
            currentCardsPoints += 3;
        }

        else if (str.Equals("2B"))
        {
            currentCardsPoints += 2;
        }

        else if ((str.Equals("11")) || (str.Equals("1")))
        {
            currentCardsPoints += 1;
        }

        currentCardsAmount++;
    }



    



    public bool ChecksIfAnyoneTakesAll(string current)
    {
        string temp = current;

        if (lastCard.Equals("2B"))
        {
            lastCard = "2";
        }

        else if (lastCard.Equals("10D"))
        {
            lastCard = "10";
        }

        if (temp.Equals("2B"))
        {
            temp = "2";
        }

        else if (temp.Equals("10D"))
        {
            temp = "10";
        }


        if ((current.Equals("11")) && (currentCardsAmount != 1))
        {
            return true;
        }


        else if (temp.Equals(lastCard))
        {
            return true;
        }

        return false;

    }



    public void ClearTheTable()
    {
        for (int i = 0; i < 4; i++)
        {
            placeHolder[i + 4].sprite = UIMask;
        }

        placeHolder[7].name = "-1";
        lastCard = "-1";
    }
}

using UnityEngine;

public class GameControllerScriptTwoPlayer : MonoBehaviour
{
    public GameObject[] platforms;
    public GameObject platformPrefab;
    public int amountOfPlatforms;
    public GameObject nextGameObject;

    private int counter;
    private float currentY;
    public float[] currentXs;

    public bool lastDirection;

    public GameObject firstBackground;
    public GameObject secondBackground;
    public GameObject thirdBackground;
    public GameObject fourthBackground;

    private GameObject currentBackground;



    private void Awake()
    {
        platforms = new GameObject[amountOfPlatforms];

        for (int i = 0; i < amountOfPlatforms; i++)
        {
            GameObject platform = Instantiate(platformPrefab);
            platform.SetActive(false);
            platforms[i] = platform;
        }

        currentY = platforms[0].transform.position.y;

        GeneratePlatform();
    }


    public void GeneratePlatform()
    {
        float random = currentXs[Random.Range(0, currentXs.Length)];
        nextGameObject = platforms[counter % amountOfPlatforms];
        nextGameObject.SetActive(true);
        nextGameObject.transform.position = new Vector3(random, currentY, 0f);
        currentY += 4.5f;
        counter++;
        lastDirection = LastDirection(random);


        if (counter == 5)
        {
            firstBackground.transform.position = new Vector3(firstBackground.transform.position.x, firstBackground.transform.position.y + 44.9f, 0f);
            currentBackground = secondBackground;
        }


        else if ((counter > 9) && ((counter % 3 == 0) || (counter % 11 == 0)))
        {
            if (currentBackground == firstBackground)
            {
                firstBackground.transform.position = new Vector3(firstBackground.transform.position.x, firstBackground.transform.position.y + 44.9f, 0f);
                currentBackground = secondBackground;
            }

            else if (currentBackground == secondBackground)
            {
                secondBackground.transform.position = new Vector3(secondBackground.transform.position.x, secondBackground.transform.position.y + 44.9f, 0f);
                currentBackground = thirdBackground;
            }

            else if (currentBackground == thirdBackground)
            {
                thirdBackground.transform.position = new Vector3(thirdBackground.transform.position.x, thirdBackground.transform.position.y + 44.9f, 0f);
                currentBackground = fourthBackground;
            }

            else
            {
                fourthBackground.transform.position = new Vector3(fourthBackground.transform.position.x, fourthBackground.transform.position.y + 44.9f, 0f);
                currentBackground = firstBackground;
            }
        }





    }


    private bool LastDirection(float number)
    {
        if (number == 0.47f)
        {
            return true;
        }

        return false;
    }

}

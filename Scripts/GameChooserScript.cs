using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameChooserScript : MonoBehaviour
{
    private string[] names;

    public Text foundText;
    public Text opponentNameText;
    public Text opponentWinsLosesText;

    public Text playerNameText;
    public Text playerWinsLosesText;

    private AudioSource audioSource;

    private bool isFound;

    private AccountScript accountScript;

    public Sprite[] sprites;
    public Image[] images;

    private Sprite[] gameSprites;

    private int[] array;


    private void Awake()
    {
        array = new int[3];
        gameSprites = new Sprite[3];

        accountScript = FindObjectOfType<AccountScript>();

        audioSource = GetComponent<AudioSource>();

        playerNameText.text = PlayerPrefs.GetString("Username");
        playerWinsLosesText.text = PlayerPrefs.GetInt("WinsTotal").ToString() + "/" + PlayerPrefs.GetInt("LosesTotal").ToString();

        names = new string[] {"Jacob","Burak","Mehmet","Mustafa","Ahmet","Fatma","Ayse","Hatice","Ali","Emine","Elif","Zeynep","Alp","Aras","Atalan","Alper","Aleyna","Bahar",
        "Banu","Basak","Aykut","Baran","Berkay","Berkehan","Birol","Bora","Ceyhun","Cetin","Cagatay","Ece","Deniz","Derin","Eren","Eda","Fulya","Funda","Ilkay","Irem","Ilayda","Kivanc",
        "Merve","Muge","Olcay","Pelin","Rusen","Sertap","Sibel","Utku","Umit","Yasemin","Abdullah","Baris","Cenk","Emrah","Fevzi","Furkan","Halil","Ismail","Muhammed","Ilker","Kutay","Kemal",
        "Mert","Necati","Okan","Onur","Ömer","Ozgu","Recep","Rifat","Samet","Salih","Tarik","Zeki","BestDuelPlayer","babapro","eniyisibenim","Michael","Noah","Mia","Liam","Emma","Gabriel",
        "Elena","Luca","Sofia","Leon","Lena","Elias","Emilia","David","Lara","Samuel","Ana","Louis","Laura","Julian","Mia","Matteo","Lina","Ben","Giulia","Leandro","Julia","Jonas","Sara",
        "Levin","Nora","Nico","Sophia","Leo","Leonie","Diego","Lea","Tim","Alina","Alessio","Nina","Daniel","Peter","Anna","Hans","Thomas","Ruth","Elisabeth","Martin","Andresas","Marco",
        "Patrick","Stefan","Bruno","Uno","Urs","Rene","Marcel","Werner","Monika","Sandra","Nicole","Barbara","Marianne","Karin","Erika","Margrit","Claudia","Hello"};

        int count = 0;

        while (count != 3)
        {
            int random = Random.Range(0, 5);

            if (sprites[random] != null)
            {
                array[count] = random;
                gameSprites[count] = sprites[random];
                sprites[random] = null;
                count++;
            }
        }

    }



    private void Update()
    {
        if (!isFound)
        {
            StartCoroutine("SpawnOpponent");
        }
    }



    private IEnumerator SpawnOpponent()
    {
        isFound = true;
        yield return new WaitForSeconds(Random.Range(1.5f, 3f));

        foundText.text = "Opponent is ready";

        audioSource.Play();

        int randomDice = Random.Range(0, 3);

        string name = names[Random.Range(0, names.Length)];

        if (randomDice == 0)
        {
            name += Random.Range(1, 82).ToString();
        }

        else if(randomDice == 1)
        {
            name = "Guest" + Random.Range(1000, 50000).ToString();
        }

        opponentNameText.text = name;
        opponentWinsLosesText.text = Random.Range(75, 450).ToString() + "/" + Random.Range(100, 600).ToString();

        yield return new WaitForSeconds(1.5f);

        foundText.text = "Generating maps...";

        images[0].sprite = gameSprites[0];

        yield return new WaitForSeconds(1.5f);

        images[1].sprite = gameSprites[1];

        yield return new WaitForSeconds(1.5f);

        images[2].sprite = gameSprites[2];

        foundText.text = "Game is loading...";

        yield return new WaitForSeconds(1f);

        accountScript.InitializeGames(array);
    }
}

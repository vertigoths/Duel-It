using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterScript : MonoBehaviour
{
    public Animator animator;

    public int score;
    public Text scoreText;

    public int opponentScore;
    public Text opponentText;

    private bool isRolled;


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }


    private void Update()
    {
        if (!isRolled)
        {
            StartCoroutine("RollScore");
        }
    }


    private IEnumerator RollScore()
    {
        isRolled = true;

        yield return new WaitForSeconds(Random.Range(0.85f, 1.27f));

        int random = Random.Range(0, 5);

        if (random == 0)
        {
            if (opponentScore > 0)
            {
                opponentScore--;
            }
        }

        else
        {
            opponentScore++;
        }

        opponentText.text = opponentScore.ToString();

        isRolled = false;
    }
}

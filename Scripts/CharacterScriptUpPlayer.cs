using UnityEngine;

using UnityEngine.UI;

public class CharacterScriptUpPlayer : MonoBehaviour
{
    public Animator animator;

    public int score;
    public Text scoreText;

    public int opponentScore;
    public Text opponentText;




    private void Awake()
    {
        animator = GetComponent<Animator>();
    }






}

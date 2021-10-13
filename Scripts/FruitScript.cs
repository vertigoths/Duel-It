using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitScript : MonoBehaviour
{
    private Rigidbody2D rigidBody;

    private FruitSpawnerScript fruitSpawnerScript;


    private void OnEnable()
    {
        fruitSpawnerScript = FindObjectOfType<FruitSpawnerScript>();
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.AddForce(transform.up * 10, ForceMode2D.Impulse);
        StartCoroutine("AddBackToPool");
    }


    private IEnumerator AddBackToPool()
    {
        yield return new WaitForSeconds(4f);
        gameObject.SetActive(false);
        fruitSpawnerScript.fruitPool.Enqueue(gameObject);
    }

}

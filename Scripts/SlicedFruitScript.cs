using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlicedFruitScript : MonoBehaviour
{

    private FruitSpawnerScript fruitSpawnerScript;

    private void OnEnable()
    {
        fruitSpawnerScript = FindObjectOfType<FruitSpawnerScript>();
        StartCoroutine("AddBackToPool");
    }

    private IEnumerator AddBackToPool()
    {
        yield return new WaitForSeconds(4f);

        if (gameObject.name.Equals("Apple-Part1(Clone)"))
        {
            gameObject.SetActive(false);
            fruitSpawnerScript.slicedApplePool.Enqueue(gameObject);
        }

        else if (gameObject.name.Equals("Apple-Part2(Clone)"))
        {
            gameObject.SetActive(false);
            fruitSpawnerScript.slicedApplePool.Enqueue(gameObject);
        }

        if (gameObject.name.Equals("Banana-Part1(Clone)"))
        {
            gameObject.SetActive(false);
            fruitSpawnerScript.slicedBananaPool.Enqueue(gameObject);
        }

        else if (gameObject.name.Equals("Banana-Part2(Clone)"))
        {
            gameObject.SetActive(false);
            fruitSpawnerScript.slicedBananaPool.Enqueue(gameObject);
        }

        if (gameObject.name.Equals("Watermelon-Part1(Clone)"))
        {
            gameObject.SetActive(false);
            fruitSpawnerScript.slicedWatermelonPool.Enqueue(gameObject);
        }

        else if (gameObject.name.Equals("Watermelon-Part2(Clone)"))
        {
            gameObject.SetActive(false);
            fruitSpawnerScript.slicedWatermelonPool.Enqueue(gameObject);
        }

    }
}

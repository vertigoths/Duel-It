using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawnerScript : MonoBehaviour
{
    public GameObject[] fruitPrefabs;
    public Transform[] positionsToSpawn;
    public GameObject[] slicedFruitPrefabs;


    public Queue<GameObject> fruitPool;

    public Queue<GameObject> slicedApplePool;
    public Queue<GameObject> slicedBananaPool;
    public Queue<GameObject> slicedWatermelonPool;


    private bool isSpawned;
    private GameObject currentObject;



    private void Awake()
    {
        fruitPool = new Queue<GameObject>();

        slicedApplePool = new Queue<GameObject>();
        slicedBananaPool = new Queue<GameObject>();
        slicedWatermelonPool = new Queue<GameObject>();

        for (int i = 0; i < 20; i++)
        {
            currentObject =  Instantiate(fruitPrefabs[Random.Range(0, fruitPrefabs.Length)]);
            currentObject.SetActive(false);
            fruitPool.Enqueue(currentObject);
        }

        for(int i = 0; i < 12; i++)
        {
            currentObject = Instantiate(slicedFruitPrefabs[i % 2]);
            currentObject.SetActive(false);
            slicedApplePool.Enqueue(currentObject);
        }

        for (int i = 0; i < 12; i++)
        {
            currentObject = Instantiate(slicedFruitPrefabs[(i % 2) + 2]);
            currentObject.SetActive(false);
            slicedBananaPool.Enqueue(currentObject);
        }

        for (int i = 0; i < 12; i++)
        {
            currentObject = Instantiate(slicedFruitPrefabs[(i % 2) + 4]);
            currentObject.SetActive(false);
            slicedWatermelonPool.Enqueue(currentObject);
        }
    }


    private void Update()
    {
        if ((!isSpawned) && (fruitPool.Count != 0))
        {
            StartCoroutine("SpawnFruits");
        }
    }


    private IEnumerator SpawnFruits()
    {
        isSpawned = true;
        int random = Random.Range(0, positionsToSpawn.Length);
        currentObject = fruitPool.Dequeue();

        currentObject.transform.position = positionsToSpawn[random].position;
        currentObject.transform.rotation = positionsToSpawn[random].rotation;

        currentObject.SetActive(true);
        yield return new WaitForSeconds(.5f);
        isSpawned = false;
    }


}

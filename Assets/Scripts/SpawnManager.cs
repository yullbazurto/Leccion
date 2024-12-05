using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour
{
  public GameObject[] itemPrefab;
  public float minTime=1f;
  public float maxTime=2f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnCoRutine(0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnCoRutine(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Instantiate(itemPrefab[Random.Range(0,itemPrefab.Length)],transform.position,Quaternion.identity);
        StartCoroutine(SpawnCoRutine(Random.Range(minTime,maxTime)));


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform homeSpawnPoint;
    public GameObject[] uniqueHomes;

    void Start()
    {
    }

    void Update()
    {
    }

    //New Home Manager
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Spawn new home if one enters the trigger (= gets destroyed)
        if (collision.tag == "Home")
        {
            int randomHomeIndex = Random.Range(0, uniqueHomes.Length);
            GameObject home = Instantiate(uniqueHomes[randomHomeIndex], homeSpawnPoint.position, Quaternion.identity, transform);
            home.SetActive(true);
        }
        //Destroy anything that touches the trigger (e.g. homes and presents)
        GameObject.Destroy(collision.gameObject);
    }
}

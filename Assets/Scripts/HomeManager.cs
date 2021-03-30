using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeManager : MonoBehaviour
{
    public float speed = 1f;
    public Transform homeSpawnPoint;
    public GameObject[] uniqueHomes;

    void Start()
    {
    }

    void Update()
    {

        foreach (Transform child in transform)
        {
            if (child.gameObject.tag == "Home")
            {
                child.Translate(Vector3.left * speed * Time.deltaTime);
            }
        }
    }

    void changeSpeed(float newSpeed)
    {

    }

    //New Home Manager
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Spawn new home
        int randomHomeIndex = Random.Range(0, uniqueHomes.Length);
        GameObject home = Instantiate(uniqueHomes[randomHomeIndex], homeSpawnPoint.position, Quaternion.identity, transform);
        home.SetActive(true);
        //Destroy anything that touches the trigger (e.g. homes and presents)
        GameObject.Destroy(collision.gameObject);
    }
}

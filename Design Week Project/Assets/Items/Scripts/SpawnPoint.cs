using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject spawn;
    public float spawnInterval;
    private float currentInterval;
    private GameObject currentSpawn;
    // Start is called before the first frame update
    void Start()
    {
        currentInterval = spawnInterval;
    }
    // Update is called once per frame
    void Update()
    {
        currentInterval += Time.deltaTime;
        if (currentInterval >= spawnInterval && currentSpawn == null)
        {
            currentSpawn = Instantiate(spawn, transform.position, transform.rotation);
            currentInterval = 0;
        }

        if ((currentSpawn.transform.position - transform.position).magnitude > 3)
        {
            currentSpawn = null;
        }
    }

}

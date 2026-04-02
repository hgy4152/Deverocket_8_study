using NUnit.Framework;
using UnityEngine;
using UnityEngine.AI;

public class ItemSpawner : MonoBehaviour
{
    public GameObject[] items;
    public GameObject player;

    private float spawnTime = 3f;
    private float lastTime = 0f;

    public float maxDistance = 10f;


    public void Update()
    {
        if(Time.time > spawnTime + lastTime)
        {
            lastTime = Time.time;
            CreateItem();

        }
    }

    public void CreateItem()
    {
        /*
        var pos = player.transform.position;
        pos.x += Random.Range(-6, 7);  
        pos.z += Random.Range(-6, 7);  
        */

        var randomPos = Random.insideUnitSphere * maxDistance;
        if (NavMesh.SamplePosition(randomPos, out NavMeshHit hit, maxDistance, NavMesh.AllAreas))
        {
            Vector3 spawnPosition = hit.position + Vector3.up * 0.5f;
            var item = Instantiate(items[Random.Range(0, items.Length)], spawnPosition, transform.rotation);
           
        } 


    }
    


}

using System;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public float zSpawn = 0;
    public float tileLength = 30;
    public int numberOfTiles = 8;
    private List<GameObject> activeTiles = new List<GameObject>();

    private Transform playerTransform;
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        for (int i = 0; i < numberOfTiles; i++)
        {   
            if(i==0)
                SpawnTile(0);
            else
                SpawnTile(UnityEngine.Random.Range(0, tilePrefabs.Length));
        }


    }

    private void Update()
    {
        if (playerTransform.position.z -35 > zSpawn - (numberOfTiles * tileLength))
        {
            SpawnTile(UnityEngine.Random.Range(0, tilePrefabs.Length));
            DeleteTile();
        }
        
    }

    public void SpawnTile(int titleIndex)
    {

        GameObject go = Instantiate(tilePrefabs[titleIndex], transform.forward * zSpawn, transform.rotation);
        activeTiles.Add(go);
        zSpawn += tileLength;
    }

    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }


}
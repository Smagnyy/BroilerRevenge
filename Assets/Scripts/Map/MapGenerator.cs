using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public Transform player;
    public Tile[] TilePrefabs;

    public Tile firstTile;

    List<Tile> createdChunks = new List<Tile>();

    public Transform tileParent;

    // Start is called before the first frame update
    void Start()
    {
        createdChunks.Add(firstTile);


    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.x > createdChunks[createdChunks.Count - 1].rightConnect.position.x - 5)
        {
            CreateChunk();
        }

    }


    void CreateChunk()
    {
        Tile newTile = Instantiate(TilePrefabs[0], tileParent);
        newTile.transform.position = createdChunks[createdChunks.Count - 1].rightConnect.position - newTile.leftConnect.localPosition;
        createdChunks.Add(newTile);

    }
}

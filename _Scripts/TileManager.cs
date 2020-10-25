using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TileManager : MonoBehaviour
{
    //Queue
    private Queue<GameObject> tile_Pool;

    public int MaxTiles;


    // Start is called before the first frame update
    void Awake()
    {
        // Initialize Tile Pool
        tile_Pool = new Queue<GameObject>();
        build_tile_pool();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void build_tile_pool()
    {
        for (var i = 0; i < MaxTiles; i++)
        {
            //enqueue new tile from factory


            var temporaryTile = TileFactory.Instance().CreateTile();
            temporaryTile.SetActive(false);
            tile_Pool.Enqueue(temporaryTile);
        }
    }

    /// <summary>
    /// Removes a GameObject Tile from the Pool
    /// </summary>
    /// <returns></returns>
    public GameObject GetTile()
    {
        var temporaryTile = tile_Pool.Dequeue();
        temporaryTile.SetActive(true);
        return temporaryTile;
    }

    /// <summary>
    /// Returns a GameObject Tile back into the Pool
    /// </summary>
    /// <param name="tile"></param>
    public void ReturnTile(GameObject tile)
    {
        tile.SetActive(false);
        tile_Pool.Enqueue(tile);
    }
}

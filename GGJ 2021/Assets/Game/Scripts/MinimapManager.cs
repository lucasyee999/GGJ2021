using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MinimapManager : MonoBehaviour
{
    public Tilemap[] MinimapTileMaps;
    public GameObject Minimap;

    public Transform player;
    public int radius;


    private void Start()
    {
        foreach(Tilemap map in MinimapTileMaps)
        {
            foreach (Vector3Int tilePosition in map.cellBounds.allPositionsWithin)
            {
                map.SetTileFlags(tilePosition, TileFlags.None);
                map.SetColor(tilePosition, Color.black);
            }
        }

    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(Minimap.activeInHierarchy)
            {
                Minimap.SetActive(false);
            }
            else
            {
                Minimap.SetActive(true);
            }
        }

        RevealRadius(player, radius);
    }

    public void RevealRadius(Transform transform, int radius)
    {
        foreach (Tilemap map in MinimapTileMaps)
        {
            Vector3 playerPos = map.WorldToCell(transform.position);

            for (int x = (int)playerPos.x - radius; x < playerPos.x + radius; x++)
            {
                for (int y = (int)playerPos.y - radius; y < playerPos.y + radius; y++)
                {
                    Vector3Int coords = new Vector3Int(x, y, 0);
                    map.SetTileFlags(coords, TileFlags.None);
                    map.SetColor(coords, Color.white);
                }
            }

        }
    }

}

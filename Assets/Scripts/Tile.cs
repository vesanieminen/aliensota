using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Tile : MonoBehaviour
{

    private Tilemap tilemap;

    void Start()
    {
        tilemap = GetComponent<Tilemap>();
    }

    public void Hit(Vector2 hitPoint)
    {
        tilemap.SetTile(tilemap.WorldToCell(hitPoint), null);
    }

}

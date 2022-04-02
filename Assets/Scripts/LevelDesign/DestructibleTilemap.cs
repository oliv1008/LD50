using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DestructibleTilemap : MonoBehaviour
{
    private Tilemap destructibleTilemap;
    private Vector3 mousePos;

    private void Start()
    {
        destructibleTilemap = GetComponent<Tilemap>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            destructibleTilemap.SetTile(destructibleTilemap.WorldToCell(mousePos), null);
        }
    }
}

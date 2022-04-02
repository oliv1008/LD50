using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    public bool canCreateWater = false;
    public bool canDig = false;

    private Tilemap destructibleTilemap;
    private Vector3 mousePos;

    [SerializeField]
    private GameObject waterParticule;

    private void Start()
    {
        destructibleTilemap = GameObject.FindGameObjectWithTag("Destructible").GetComponent<Tilemap>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;

            if (canDig)
            {
                destructibleTilemap.SetTile(destructibleTilemap.WorldToCell(mousePos), null);
            }

            if(canCreateWater)
            {
                bool isEmptySpace = true;

                if(destructibleTilemap.GetTile(destructibleTilemap.WorldToCell(mousePos)) == null)
                        Instantiate(waterParticule, mousePos, Quaternion.identity);
            }
        }
    }

    public void CanDigToggle()
    {
        canDig = !canDig;
    }

    public void CanCreateWaterToggle()
    {
        canCreateWater = !canCreateWater;
    }
}

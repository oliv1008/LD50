using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    public bool canCreateWater = false;
    public bool canDig = false;
    public bool canCreateRock = false;
    public bool canCreateWood = false;

    private Tilemap destructibleTilemap;
    private Vector3 mousePos;

    [SerializeField]
    private GameObject waterParticule;
    [SerializeField]
    private GameObject rockPrefab;
    [SerializeField]
    private GameObject woodPrefab;

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
                if(destructibleTilemap.GetTile(destructibleTilemap.WorldToCell(mousePos)) == null)
                        Instantiate(waterParticule, mousePos, Quaternion.identity);
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;

            if (canCreateRock)
            {
                if (destructibleTilemap.GetTile(destructibleTilemap.WorldToCell(mousePos)) == null)
                    Instantiate(rockPrefab, mousePos, Quaternion.identity);
            }

            if (canCreateWood)
            {
                if (destructibleTilemap.GetTile(destructibleTilemap.WorldToCell(mousePos)) == null)
                    Instantiate(woodPrefab, mousePos, Quaternion.identity);
            }
        }
    }

    public void CanDigToggle(bool isOn)
    {
        canDig = isOn;
    }

    public void CanCreateWaterToggle(bool isOn)
    {
        canCreateWater = isOn;
    }

    public void CanCreateRockToggle(bool isOn)
    {
        canCreateRock = isOn;
    }

    public void CanCreateWoodToggle(bool isOn)
    {
        canCreateWood = isOn;
    }
}

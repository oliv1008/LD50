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

    public bool createWaterPossible = false;
    public bool digPossible = false;
    public bool createRockPossible = false;
    public bool createWoodPossible = false;

    private Tilemap destructibleTilemap;
    private HUD hudScript;
    private Vector3 mousePos;

    [Header("Prefabs")]
    [SerializeField]
    private GameObject waterParticule;
    [SerializeField]
    private GameObject rockPrefab;
    [SerializeField]
    private GameObject rockHoverPrefab;
    private GameObject rockObject = null;
    [SerializeField]
    private GameObject woodPrefab;
    [SerializeField]
    private GameObject woodHoverPrefab;
    private GameObject woodObject = null;

    private Color greenHalfAlpha = new Color(0f, 1f, 0f, 127f / 255f);
    private Color redHalfAlpha = new Color(1f, 0f, 0f, 127f / 255f);
    private Color freedentWhite = new Color(1f, 1f, 1f, 1f);

    private void Start()
    {
        destructibleTilemap = GameObject.FindGameObjectWithTag("Destructible").GetComponent<Tilemap>();
        hudScript = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
    }

    private void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        if (rockObject != null)
        {
            rockObject.transform.position = mousePos;
            if (createRockPossible == false && rockObject.GetComponent<CollisionBetweenObstacleDetector>().countObstacles == 0)
            {
                createRockPossible = true;
                rockObject.GetComponent<SpriteRenderer>().color = greenHalfAlpha;
            }
            else if(rockObject.GetComponent<CollisionBetweenObstacleDetector>().countObstacles != 0 && createRockPossible == true)
            {
                createRockPossible = false;
                rockObject.GetComponent<SpriteRenderer>().color = redHalfAlpha;
            }
        }
        if (woodObject != null)
        {
            woodObject.transform.position = mousePos;
            if (createWoodPossible == false && woodObject.GetComponent<CollisionBetweenObstacleDetector>().countObstacles == 0)
            {
                createWoodPossible = true;
                woodObject.GetComponent<SpriteRenderer>().color = greenHalfAlpha;
            }
            else if (woodObject.GetComponent<CollisionBetweenObstacleDetector>().countObstacles != 0 && createWoodPossible == true)
            {
                createWoodPossible = false;
                woodObject.GetComponent<SpriteRenderer>().color = redHalfAlpha;
            }
        }

        if (Input.GetMouseButton(0))
        {
            if (canDig)
            {
                if (destructibleTilemap.GetTile(destructibleTilemap.WorldToCell(mousePos)) != null)
                {
                    destructibleTilemap.SetTile(destructibleTilemap.WorldToCell(mousePos), null);
                    hudScript.GetDigRessourceButton().SetFillingBarValue(hudScript.GetDigRessourceButton().GetCurrentFilligBar() - 1);
                }
            }

            if(canCreateWater)
            {
                if(destructibleTilemap.GetTile(destructibleTilemap.WorldToCell(mousePos)) == null)
                {
                    Instantiate(waterParticule, mousePos, Quaternion.identity);
                    hudScript.GetWaterRessourceButton().SetFillingBarValue(hudScript.GetWaterRessourceButton().GetCurrentFilligBar() - 1);
                }
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (createRockPossible)
            {
                Instantiate(rockPrefab, mousePos, Quaternion.identity);
                hudScript.GetStoneRessourceButton().SetCompteurValue(hudScript.GetStoneRessourceButton().GetCurrentCompteur() - 1);
            }
            else if (createWoodPossible)
            {
                Instantiate(woodPrefab, mousePos, Quaternion.identity);
                hudScript.GetWoodRessourceButton().SetCompteurValue(hudScript.GetWoodRessourceButton().GetCurrentCompteur() - 1);
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
        if(canCreateRock != isOn)
        {
            canCreateRock = isOn;
            if (canCreateRock)
            {
                rockObject = Instantiate(rockHoverPrefab, mousePos, Quaternion.identity);
            }
            else
            {
                Destroy(rockObject);
                rockObject = null;
                createRockPossible = false;
            }
        }
    }

    public void CanCreateWoodToggle(bool isOn)
    {
        if(canCreateWood != isOn)
        {
            canCreateWood = isOn;
            if (canCreateWood)
            {
                woodObject = Instantiate(woodHoverPrefab, mousePos, Quaternion.identity);
            }
            else
            {
                Destroy(woodObject);
                woodObject = null;
                createWoodPossible = false;
            }
        }
    }
}

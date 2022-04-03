using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    private bool canCreateWater = false;
    private bool canDig = false;
    private bool canCreateRock = false;
    private bool canCreateWood = false;

    private bool createWaterPossible = false;
    private bool digPossible = false;
    private bool createRockPossible = false;
    private bool createWoodPossible = false;

    private Tilemap destructibleTilemap;
    private HUD hudScript;
    private Vector3 mousePos;

    [Header("Prefabs")]
    [SerializeField]
    private GameObject waterParticule;
    [SerializeField]
    private AudioSource waterSound;
    [SerializeField]
    private AudioSource digSound;
    [SerializeField]
    private GameObject digParticleEffect;
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
        else if (woodObject != null)
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
        else if (canDig)
        {
            if (destructibleTilemap.GetTile(destructibleTilemap.WorldToCell(mousePos)) != null && !digPossible)
            {
                digPossible = true;
                hudScript.GetDigRessourceButton().SetShovelCursor();
            }
            else if (destructibleTilemap.GetTile(destructibleTilemap.WorldToCell(mousePos)) == null && digPossible)
            {
                digPossible = false;
                hudScript.GetDigRessourceButton().SetRedShovelCursor();
            }
        }
        else if (canCreateWater)
        {
            if (destructibleTilemap.GetTile(destructibleTilemap.WorldToCell(mousePos)) == null && !createWaterPossible)
            {
                createWaterPossible = true;
                hudScript.GetWaterRessourceButton().SetWateringCanCursor();
            }
            else if (destructibleTilemap.GetTile(destructibleTilemap.WorldToCell(mousePos)) != null && createWaterPossible)
            {
                createWaterPossible = false;
                hudScript.GetWaterRessourceButton().SetRedWateringCanCursor();
            }
        }

        if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            if (digPossible)
            {
                if(!digSound.isPlaying)
                    digSound.Play();
                Instantiate(digParticleEffect, mousePos, Quaternion.identity);
                destructibleTilemap.SetTile(destructibleTilemap.WorldToCell(mousePos), null);
                hudScript.GetDigRessourceButton().SetFillingBarValue(hudScript.GetDigRessourceButton().GetCurrentFilligBar() - 1);
            }
            else if(createWaterPossible)
            {
                if(!waterSound.isPlaying)
                    waterSound.Play();
                Instantiate(waterParticule, mousePos, Quaternion.identity);
                hudScript.GetWaterRessourceButton().SetFillingBarValue(hudScript.GetWaterRessourceButton().GetCurrentFilligBar() - 1);
            }
        }
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            if (createRockPossible)
            {
                Instantiate(rockPrefab, mousePos, Quaternion.identity);
                hudScript.GetStoneRessourceButton().SetCompteurValue(hudScript.GetStoneRessourceButton().GetCurrentCompteur() - 1);
            }
            else if (createWoodPossible)
            {
                Instantiate(woodPrefab, mousePos, woodObject.transform.rotation);
                hudScript.GetWoodRessourceButton().SetCompteurValue(hudScript.GetWoodRessourceButton().GetCurrentCompteur() - 1);
            }
        }
        if(Input.GetMouseButtonDown(1) && !EventSystem.current.IsPointerOverGameObject())
        {
            if(canCreateWood)
            {
                woodObject.transform.Rotate(0f, 0f, 30f);
            }
        }
    }

    public void CanDigToggle(bool isOn)
    {
        if(canDig != isOn)
        {
            canDig = isOn;
            if(!canDig)
            {
                digPossible = false;
            }
            else
            {
                if (destructibleTilemap.GetTile(destructibleTilemap.WorldToCell(mousePos)) != null)
                {
                    digPossible = true;
                    hudScript.GetDigRessourceButton().SetShovelCursor();
                }
                else if (destructibleTilemap.GetTile(destructibleTilemap.WorldToCell(mousePos)) == null)
                {
                    digPossible = false;
                    hudScript.GetDigRessourceButton().SetRedShovelCursor();
                }
            }
        }
    }

    public void CanCreateWaterToggle(bool isOn)
    {
        if (canCreateWater != isOn)
        {
            canCreateWater = isOn;
            if (!canCreateWater)
            {
                createWaterPossible = false;
            }
            else
            {
                if (destructibleTilemap.GetTile(destructibleTilemap.WorldToCell(mousePos)) == null)
                {
                    createWaterPossible = true;
                    hudScript.GetWaterRessourceButton().SetWateringCanCursor();
                }
                else if (destructibleTilemap.GetTile(destructibleTilemap.WorldToCell(mousePos)) != null)
                {
                    createWaterPossible = false;
                    hudScript.GetWaterRessourceButton().SetRedWateringCanCursor();
                }
            }
        }
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

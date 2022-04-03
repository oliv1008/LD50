using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BackgroundFiller : MonoBehaviour
{

    public List<TileBase> tileBaseList;

    private GameObject TopLeftElement;
    private GameObject BottomRightElement;
    private Grid gridComponent;
    private Tilemap tilemapComponent;
    // Start is called before the first frame update
    void Start()
    {
        gridComponent = GetComponent<Grid>();
        tilemapComponent = GameObject.FindGameObjectWithTag("Background").GetComponent<Tilemap>();

        TopLeftElement = GameObject.FindGameObjectWithTag("TopLeft");
        BottomRightElement = GameObject.FindGameObjectWithTag("BottomRight");

        Debug.Log("TopLeftElement.transform.position : " + TopLeftElement.transform.position);
        Debug.Log("BottomRightElement.transform.position : " + BottomRightElement.transform.position);

        Debug.Log("gridComponent.WorldToCell(TopLeftElement.transform.position) : " + gridComponent.WorldToCell(TopLeftElement.transform.position));
        Debug.Log("gridComponent.WorldToCell(BottomRightElement.transform.position) : " + gridComponent.WorldToCell(BottomRightElement.transform.position));

        for (int x = gridComponent.WorldToCell(TopLeftElement.transform.position).x; x <= gridComponent.WorldToCell(BottomRightElement.transform.position).x; x++)
        {
            for (int y = gridComponent.WorldToCell(BottomRightElement.transform.position).y; y <= gridComponent.WorldToCell(TopLeftElement.transform.position).y; y++)
            {
                int randomIndex = Random.Range(0, 7);

                tilemapComponent.SetTile(new Vector3Int(x, y, 0), tileBaseList[randomIndex]);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

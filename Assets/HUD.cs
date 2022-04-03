using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    [SerializeField] GameObject WoodButton;
    [SerializeField] GameObject StoneButton;
    [SerializeField] GameObject WaterButton;
    [SerializeField] GameObject DigButton;

    private LevelOptionsHandler levelOptions;

    // Start is called before the first frame update
    void Start()
    {
        levelOptions = GameObject.FindGameObjectWithTag("LevelOptions").GetComponent<LevelOptionsHandler>();

        if(levelOptions != null)
        {
            WoodButton.SetActive(levelOptions.levelOptions.isUsingWood);
            StoneButton.SetActive(levelOptions.levelOptions.isUsingStone);
            WaterButton.SetActive(levelOptions.levelOptions.isUsingWater);
            DigButton.SetActive(levelOptions.levelOptions.isUsingDig);

            WoodButton.GetComponent<RessourceButton>()?.SetMaxCompteur(levelOptions.levelOptions.maxWood);
            StoneButton.GetComponent<RessourceButton>()?.SetMaxCompteur(levelOptions.levelOptions.maxStone);
            WaterButton.GetComponent<RessourceButton>()?.SetMaxFillingBar(levelOptions.levelOptions.maxWater);
            DigButton.GetComponent<RessourceButton>()?.SetMaxFillingBar(levelOptions.levelOptions.maxDig);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

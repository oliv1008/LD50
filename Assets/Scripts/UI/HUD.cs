using UnityEngine;

public class HUD : MonoBehaviour
{
    [SerializeField] GameObject WoodButton;
    [SerializeField] GameObject StoneButton;
    [SerializeField] GameObject WaterButton;
    [SerializeField] GameObject DigButton;

    [SerializeField] StartLevelButton StartButton;

    private LevelOptionsHandler levelOptions;

    private int maxTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        levelOptions = GameObject.FindGameObjectWithTag("LevelOptions").GetComponent<LevelOptionsHandler>();

        StartButton.start.AddListener(EnableButtons);

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

            maxTime = levelOptions.levelOptions.levelTime;
        }

        WoodButton.GetComponent<RessourceButton>()?.Disable();
        StoneButton.GetComponent<RessourceButton>()?.Disable();
        WaterButton.GetComponent<RessourceButton>()?.Disable();
        DigButton.GetComponent<RessourceButton>()?.Disable();
    }

    private void EnableButtons()
    {
        WoodButton.GetComponent<RessourceButton>()?.Enable();
        StoneButton.GetComponent<RessourceButton>()?.Enable();
        WaterButton.GetComponent<RessourceButton>()?.Enable();
        DigButton.GetComponent<RessourceButton>()?.Enable();
    }

    public RessourceButton GetWoodRessourceButton()
    {
        return WoodButton.GetComponent<RessourceButton>();
    }
    public RessourceButton GetStoneRessourceButton()
    {
        return StoneButton.GetComponent<RessourceButton>();
    }
    public RessourceButton GetWaterRessourceButton()
    {
        return WaterButton.GetComponent<RessourceButton>();
    }
    public RessourceButton GetDigRessourceButton()
    {
        return DigButton.GetComponent<RessourceButton>();
    }
}

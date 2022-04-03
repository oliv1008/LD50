using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum RessourceType
{
    Wood,
    Stone,
    Water,
    Dig
}
public class RessourceButton : MonoBehaviour
{
    [SerializeField] public RessourceType Type;

    [SerializeField] private TextMeshProUGUI Title;
    [SerializeField] private TextMeshProUGUI Compteur;
    [SerializeField] private Image RessourceImage;
    [SerializeField] private GameObject RessourceProgressBar;
    [SerializeField] private Image RessourceProgressBarColor;
    [SerializeField] private Toggle ToggleItem;
    [SerializeField] private PlayerController Player;

    [SerializeField] private Sprite WoodSprite;
    [SerializeField] private Sprite StoneSprite;
    [SerializeField] private Sprite WaterSprite;
    [SerializeField] private Sprite DigSprite;

    // Start is called before the first frame update
    void Start()
    {
        switch(Type)
        {
            case RessourceType.Wood:
                Title.text = "Wood";
                RessourceImage.sprite = WoodSprite;
                RessourceProgressBar.SetActive(false);
                break;
            case RessourceType.Stone:
                Title.text = "Stone";
                RessourceImage.sprite = StoneSprite;
                RessourceProgressBar.SetActive(false);
                break;
            case RessourceType.Water:
                Title.text = "Water";
                RessourceImage.sprite = WaterSprite;
                RessourceProgressBarColor.color = new Color(18f / 255f, 78f / 255f, 137f / 255f);
                Compteur.enabled = false;
                break;
            case RessourceType.Dig:
                Title.text = "Dig";
                RessourceImage.sprite = DigSprite;
                RessourceProgressBarColor.color = new Color(115f / 255f, 62f / 255f, 57f / 255f);
                Compteur.enabled = false;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Click()
    {
        ToggleItem.isOn = true;

        switch (Type)
        {
            case RessourceType.Wood:
                
                break;
            case RessourceType.Stone:
                
                break;
            case RessourceType.Water:
                Player.CanCreateWaterToggle(ToggleItem.isOn);
                break;
            case RessourceType.Dig:
                Player.CanDigToggle(ToggleItem.isOn);
                break;
        }
    }

    public void ToggleChanged()
    {
        switch (Type)
        {
            case RessourceType.Wood:

                break;
            case RessourceType.Stone:

                break;
            case RessourceType.Water:
                Player.CanCreateWaterToggle(ToggleItem.isOn);
                break;
            case RessourceType.Dig:
                Player.CanDigToggle(ToggleItem.isOn);
                break;
        }
    }
}

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
    [SerializeField] private Image ToggleBg;
    [SerializeField] private Button thisButton;
    private PlayerController Player;

    [SerializeField] private Sprite WoodSprite;
    [SerializeField] private Sprite StoneSprite;
    [SerializeField] private Sprite WaterSprite;
    [SerializeField] private Sprite DigSprite;

    private int maxCompteur = 0;
    private int maxFillingBar = 0;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        switch (Type)
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

    public void Click()
    {
        ToggleItem.isOn = true;

        switch (Type)
        {
            case RessourceType.Wood:
                Player.CanCreateWoodToggle(ToggleItem.isOn);
                break;
            case RessourceType.Stone:
                Player.CanCreateRockToggle(ToggleItem.isOn);
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
                Player.CanCreateWoodToggle(ToggleItem.isOn);
                break;
            case RessourceType.Stone:
                Player.CanCreateRockToggle(ToggleItem.isOn);
                break;
            case RessourceType.Water:
                Player.CanCreateWaterToggle(ToggleItem.isOn);
                break;
            case RessourceType.Dig:
                Player.CanDigToggle(ToggleItem.isOn);
                break;
        }
    }

    public void SetMaxCompteur(int max)
    {
        maxCompteur = max;
        SetCompteurValue(max);
    }

    public void SetCompteurValue(int value)
    {
        Compteur.text = value + "/" + maxCompteur;

        if(value == 0)
        {
            Disable();
        }
    }

    public void SetMaxFillingBar(int max)
    {
        maxFillingBar = max;
        SetFillingBarValue(max);
    }

    public void SetFillingBarValue(int value)
    {
        RessourceProgressBarColor.fillAmount = (float)value / (float)maxFillingBar;

        if (value == 0)
        {
            Disable();
        }
    }

    public void Disable()
    {
        ToggleItem.isOn = false;
        thisButton.interactable = false;
        Title.color = new Color(200f / 255f, 200f / 255f, 200f / 255f, 128f / 255f);
        RessourceImage.color = new Color(200f / 255f, 200f / 255f, 200f / 255f, 128f / 255f);
        Compteur.color = new Color(200f / 255f, 200f / 255f, 200f / 255f, 128f / 255f);
        RessourceProgressBar.GetComponent<Image>().color = new Color(200f / 255f, 200f / 255f, 200f / 255f, 128f / 255f);
        ToggleBg.color = new Color(200f / 255f, 200f / 255f, 200f / 255f, 128f / 255f);
    }

    public void Enable()
    {
        thisButton.interactable = true;
        Title.color = new Color(1, 1, 1, 1);
        RessourceImage.color = new Color(1, 1, 1, 1);
        Compteur.color = new Color(1, 1, 1, 1);
        RessourceProgressBar.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        ToggleBg.color = new Color(1, 1, 1, 1);
    }
}

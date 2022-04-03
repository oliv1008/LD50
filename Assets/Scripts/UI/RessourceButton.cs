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
    [Header("Informations")]
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

    [Header("Sprites")]
    [SerializeField] private Sprite WoodSprite;
    [SerializeField] private Sprite StoneSprite;
    [SerializeField] private Sprite WaterSprite;
    [SerializeField] private Sprite DigSprite;

    private int maxCompteur = 0;
    private int currentCompteur;
    private int maxFillingBar = 0;
    private int currentFillingBar;

    [Header("Cursors")]
    [SerializeField]
    private Texture2D shovelCursor;
    [SerializeField]
    private Texture2D redShovelCursor;
    private Vector2 shovelOffset = Vector2.zero;
    [SerializeField]
    private Texture2D wateringCanCursor;
    [SerializeField]
    private Texture2D redWateringCanCursor;
    private Vector2 wateringCanOffset;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        wateringCanOffset = new Vector2(0, wateringCanCursor.height);
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
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
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
        currentCompteur = max;
        SetCompteurValue(max);
    }

    public void SetCompteurValue(int value)
    {
        Compteur.text = value + "/" + maxCompteur;
        currentCompteur = value;

        if(value == 0)
        {
            Disable();
        }
    }

    public void SetMaxFillingBar(int max)
    {
        maxFillingBar = max;
        currentFillingBar = max;
        SetFillingBarValue(max);
    }

    public void SetFillingBarValue(int value)
    {
        RessourceProgressBarColor.fillAmount = (float)value / (float)maxFillingBar;
        currentFillingBar = value;

        if (value == 0)
        {
            Disable();
        }
    }

    public void Disable()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
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

    public int GetCurrentFilligBar()
    {
        return currentFillingBar;
    }
    public int GetCurrentCompteur()
    {
        return currentCompteur;
    }

    public void SetRedShovelCursor()
    {
        Cursor.SetCursor(redShovelCursor, shovelOffset, CursorMode.Auto);
    }
    public void SetShovelCursor()
    {
        Cursor.SetCursor(shovelCursor, shovelOffset, CursorMode.Auto);
    }
    public void SetRedWateringCanCursor()
    {
        Cursor.SetCursor(redWateringCanCursor, wateringCanOffset, CursorMode.Auto);
    }
    public void SetWateringCanCursor()
    {
        Cursor.SetCursor(wateringCanCursor, wateringCanOffset, CursorMode.Auto);
    }
    public bool GetToggleOn()
    {
        return ToggleItem.isOn;
    }

    public void UnToggle()
    {
        ToggleItem.isOn = false;
    }
}

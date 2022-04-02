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
    [SerializeField] private Image RessourceProgressBar;

    [SerializeField] private Sprite WoodSprite;
    [SerializeField] private Sprite StoneSprite;
    [SerializeField] private Sprite WaterSprite;
    [SerializeField] private Sprite DigSprite;

    [SerializeField] private Sprite WaterProgressBarSprite;
    [SerializeField] private Sprite DigProgressBarSprite;

    // Start is called before the first frame update
    void Start()
    {
        switch(Type)
        {
            case RessourceType.Wood:
                Title.text = "Wood";
                RessourceImage.sprite = WoodSprite;                
                RessourceProgressBar.enabled = false;
                break;
            case RessourceType.Stone:
                Title.text = "Stone";
                RessourceImage.sprite = StoneSprite;               
                RessourceProgressBar.enabled = false;
                break;
            case RessourceType.Water:
                Title.text = "Water";
                RessourceImage.sprite = WaterSprite;
                //RessourceProgressBar.sprite = WaterProgressBarSprite;
                Compteur.enabled = false;
                break;
            case RessourceType.Dig:
                Title.text = "Dig";
                RessourceImage.sprite = DigSprite;
                //RessourceProgressBar.sprite = DigProgressBarSprite;
                Compteur.enabled = false;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

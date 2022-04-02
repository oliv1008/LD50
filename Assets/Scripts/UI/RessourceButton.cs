using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum RessourceType
{
    Bois,
    Cailloux,
    Eau,
    Pelles
}
public class RessourceButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Title;
    [SerializeField] private TextMeshProUGUI Compteur;
    [SerializeField] private Image RessourceImage;
    [SerializeField] private Image RessourceProgressBar;

    [SerializeField] public RessourceType Type;

    // Start is called before the first frame update
    void Start()
    {
        switch(Type)
        {
            case RessourceType.Bois:
                Title.text = "Wood";
                //RessourceImage.sprite = ;                
                RessourceProgressBar.enabled = false;
                break;
            case RessourceType.Cailloux:
                Title.text = "Stone";
                //RessourceImage.sprite = ;               
                RessourceProgressBar.enabled = false;
                break;
            case RessourceType.Eau:
                Title.text = "Water";
                //RessourceImage.sprite = ;
                Compteur.enabled = false;
                break;
            case RessourceType.Pelles:
                Title.text = "Dig";
                //RessourceImage.sprite = ;
                Compteur.enabled = false;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

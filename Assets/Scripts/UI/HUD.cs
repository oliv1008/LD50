using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField] GameObject WoodButton;
    [SerializeField] GameObject StoneButton;
    [SerializeField] GameObject WaterButton;
    [SerializeField] GameObject DigButton;
    [SerializeField] GameObject WinFields;
    [SerializeField] GameObject GameOverFields;
    [SerializeField] GameObject PauseMenu;
    [SerializeField] Slider ProgressBar;
    [SerializeField] private bool showEscapeTutorial = false;
    [SerializeField] private GameObject tooltipObjectEscape;

    [SerializeField] StartLevelButton StartButton;

    private LevelOptionsHandler levelOptions;

    private float maxTime = 0;
    private float timeLeft = 0;

    private bool startedGame = false;
    private bool canBePaused = true;

    public static bool GameIsPaused = false;

    private List<RessourceButton> ressourceButtons = new List<RessourceButton>();

    // Start is called before the first frame update
    void Start()
    {
        if(showEscapeTutorial)
        {
            tooltipObjectEscape.SetActive(true);
        }
        levelOptions = GameObject.FindGameObjectWithTag("LevelOptions").GetComponent<LevelOptionsHandler>();

        StartButton.start.AddListener(StartGame);
        DeathZoneScript.dieEvent.AddListener(Loose);

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

            maxTime = (float)levelOptions.levelOptions.levelTime;
            timeLeft = maxTime;
        }

        ressourceButtons.Add(WoodButton.GetComponent<RessourceButton>());
        ressourceButtons.Add(StoneButton.GetComponent<RessourceButton>());
        ressourceButtons.Add(WaterButton.GetComponent<RessourceButton>());
        ressourceButtons.Add(DigButton.GetComponent<RessourceButton>());

        WinFields.SetActive(false);
        GameOverFields.SetActive(false);
        PauseMenu.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            bool isRessourceToggled = false;
            foreach(RessourceButton r in ressourceButtons)
            {
                if(r.GetToggleOn() == true)
                {
                    isRessourceToggled = true;
                }
            }

            if(isRessourceToggled == true)
            {
                foreach (RessourceButton r in ressourceButtons)
                {
                    if (r.GetToggleOn() == true)
                    {
                        r.UnToggle();
                    }
                }
            }
            else
            {
                if (GameIsPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }           
        }

        if (startedGame == true)
        {
            timeLeft -= Time.deltaTime;
            if(timeLeft>=0)
            {
                ProgressBar.value = timeLeft / maxTime;
            }
            else
            {
                Win();
            }
        }
    }

    private void EnableButtons()
    {
        foreach(RessourceButton r in ressourceButtons)
        {
            r.Enable();
        }
    }

    private void DisableButtons()
    {
        foreach (RessourceButton r in ressourceButtons)
        {
            r.Disable();
        }
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

    public void ContinueButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        MainMenuController.isComingFromLevel = true;
    }

    public void LevelSelectionButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
        MainMenuController.isComingFromLevel = true;
    }

    private void StartGame()
    {
        EnableButtons();
        startedGame = true;
    }

    private void Win()
    {
        startedGame = false;
        canBePaused = false;
        Time.timeScale = 0f;
        WinFields.SetActive(true);
        WoodButton.SetActive(false);
        StoneButton.SetActive(false);
        DigButton.SetActive(false);
        WaterButton.SetActive(false);
        StartButton.gameObject.SetActive(false);
        ProgressBar.gameObject.SetActive(false);
        DisableButtons();
    }

    private void Loose()
    {
        startedGame = false;
        canBePaused = false;
        GameOverFields.SetActive(true);
        Time.timeScale = 0f;
        WoodButton.SetActive(false);
        StoneButton.SetActive(false);
        DigButton.SetActive(false);
        WaterButton.SetActive(false);
        StartButton.gameObject.SetActive(false);
        ProgressBar.gameObject.SetActive(false);
        DisableButtons();
    }

    public void Resume()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        if(canBePaused)
        {
            PauseMenu.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;
        }
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

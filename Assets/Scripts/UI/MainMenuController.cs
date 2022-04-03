using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject Title;
    public GameObject ButtonsContainer;
    public GameObject OptionsMenu;
    public GameObject ExitButton;

    public Animator musicAnim;
    public Animator canvasAnim;

    public float WaitTime;

    private void Start()
    {
        OptionsMenu.SetActive(false);
    }
    public void OptionClick()
    {
        OptionsMenu.SetActive(true);

        Title.SetActive(false);
        ButtonsContainer.SetActive(false);
        ExitButton.SetActive(false);
    }

    public void ClickBackOption()
    {
        OptionsMenu.SetActive(false);

        Title.SetActive(true);
        ButtonsContainer.SetActive(true);
        ExitButton.SetActive(true);
    }

    public void ClickExit()
    {
        Application.Quit();
    }

    public void StartNewGame()
    {
        StartCoroutine(ChangeSceneMusic());
    }

    public void ClickLevelSelection()
    {

    }

    IEnumerator ChangeSceneMusic()
    {
        musicAnim.SetTrigger("FadeOut");
        canvasAnim.SetTrigger("MainMenuFadeOut");
        yield return new WaitForSeconds(WaitTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerMusic : MonoBehaviour
{
    public Animator MusicAnim;

    public float WaitTime;

    public void ChangeScene()
    {
        StartCoroutine(ChangeSceneMusic());
    }

    IEnumerator ChangeSceneMusic()
    {
        MusicAnim.SetTrigger("fadeOut");
        yield return new WaitForSeconds(WaitTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

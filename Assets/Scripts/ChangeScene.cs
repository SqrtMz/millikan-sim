using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public String sceneName;
    public Animator transition;
    public float timeTransition = 0.5f;
    
    public void SceneChange()
    {
        StartCoroutine(LoadTransition(sceneName));
    }

    public void QuitProgram()
    {
        Application.Quit();
    }

    IEnumerator LoadTransition(string name)
    {
        transition.SetTrigger("Change");

        yield return new WaitForSeconds(timeTransition);

        SceneManager.LoadScene(name);
    }
}
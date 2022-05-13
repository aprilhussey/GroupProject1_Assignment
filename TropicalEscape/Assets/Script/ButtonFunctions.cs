using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using System.Collection;

public class ButtonFunctions : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void OpenMainOptions()
    {
        SceneManager.LoadScene("Options");
    }

    public void OpenPauseOptions()
    {
        SceneManager.LoadScene("OptionsPause");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OpenPauseMenu()
    {
        SceneManager.LoadScene("PauseMenu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void BackToGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void LeaveMainOptions()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LeavePauseOptions()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void SkipIntro()
    {
        SceneManager.LoadScene("MainMenu");
    }

}

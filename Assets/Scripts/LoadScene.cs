using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void ChangeToTitleScene()
    {
        SceneManager.LoadScene("TitleScene");
    }
    public void ChangeToWaitingScene()
    {
        SceneManager.LoadScene("WaitingScene");
    }
    public void ChangeToTeamScene()
    {
        SceneManager.LoadScene("TeamScene");
    }
    public void ChangeToMapScene()
    {
        SceneManager.LoadScene("MapScene");
    }
    public void ChangeToInstructionsScene()
    {
        SceneManager.LoadScene("InstructionsScene");
    }
    public void ChangeToGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}

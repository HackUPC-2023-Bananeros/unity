using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    /*
    public void changeScene()
    {
        SceneManagement.LoadScene(0);
    }
    */
    [SerializeField] private HUD hud;
    [SerializeField] private Canvas titleScreen_canvas;
    [SerializeField] private Button start_button;
    [SerializeField] private Button settings_button;
    [SerializeField] private Button exit_button;
    [SerializeField] private Canvas settings_canvas;
    [SerializeField] private Canvas waitScreen_canvas;
    [SerializeField] private Canvas teamScreen_canvas;
    [SerializeField] private Canvas instructions_canvas;
    [SerializeField] private Canvas levelCompleted_canvas;
    [SerializeField] private Button nextLevel_button;

    // private bool gameStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        hud.gameObject.SetActive(false);
        titleScreen_canvas.gameObject.SetActive(true);
        settings_canvas.gameObject.SetActive(false);
        waitScreen_canvas.gameObject.SetActive(false);
        teamScreen_canvas.gameObject.SetActive(false);
        instructions_canvas.gameObject.SetActive(false);
        levelCompleted_canvas.gameObject.SetActive(false);
    }

    public void WaitScreen()
    {
        hud.gameObject.SetActive(false);
        titleScreen_canvas.gameObject.SetActive(false);
        settings_canvas.gameObject.SetActive(false);
        waitScreen_canvas.gameObject.SetActive(true);
        teamScreen_canvas.gameObject.SetActive(false);
        instructions_canvas.gameObject.SetActive(false);
        levelCompleted_canvas.gameObject.SetActive(false);
    }

    public void Team()
    {
        hud.gameObject.SetActive(false);
        titleScreen_canvas.gameObject.SetActive(false);
        settings_canvas.gameObject.SetActive(false);
        waitScreen_canvas.gameObject.SetActive(false);
        teamScreen_canvas.gameObject.SetActive(true);
        instructions_canvas.gameObject.SetActive(false);
        levelCompleted_canvas.gameObject.SetActive(false);
    }

    public void EnterGame()
    {
        hud.gameObject.SetActive(false);
        titleScreen_canvas.gameObject.SetActive(false);
        settings_canvas.gameObject.SetActive(false);
        waitScreen_canvas.gameObject.SetActive(false);
        teamScreen_canvas.gameObject.SetActive(false);
        instructions_canvas.gameObject.SetActive(true);
        levelCompleted_canvas.gameObject.SetActive(false);
    }

    public void StartGame()
    {
        hud.gameObject.SetActive(true);
        titleScreen_canvas.gameObject.SetActive(false);
        settings_canvas.gameObject.SetActive(false);
        waitScreen_canvas.gameObject.SetActive(false);
        teamScreen_canvas.gameObject.SetActive(false);
        instructions_canvas.gameObject.SetActive(false);
        levelCompleted_canvas.gameObject.SetActive(false);
    }

    public void Settings()
    {
        hud.gameObject.SetActive(false);
        titleScreen_canvas.gameObject.SetActive(false);
        settings_canvas.gameObject.SetActive(true);
        waitScreen_canvas.gameObject.SetActive(false);
        teamScreen_canvas.gameObject.SetActive(false);
        instructions_canvas.gameObject.SetActive(false);
        levelCompleted_canvas.gameObject.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(gameStarted)
        {
            start_button.onClick.WaitScreen();
            IEnumerator WaitInstructions()
            {
                yield return new WaitForSeconds(15);
                Team();
            }
        } else {
            start_button.onClick.Team();
            IEnumerator WaitInstructions()
            {
                yield return new WaitForSeconds(15);
                StartGame();
            }
        }
        IEnumerator WaitInstructions()
        {
            yield return new WaitForSeconds(15);
            StartGame();
        }
        settings_button.onClick.Settings();
        exit_button.onClick.Exit();
        */
    }

}

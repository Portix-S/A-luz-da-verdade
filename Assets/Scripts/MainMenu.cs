using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private static readonly int OpenCloseCurtain = Animator.StringToHash("Open/Close");
    [SerializeField] private Animator curtainAnimator;
    private GameObject _currentMenu;
    
    [SerializeField] private GameObject gameMenu;
    [SerializeField] private GameObject creditsMenu;
    [SerializeField] private GameObject endMenu;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject tutorialDialog;

    private void Start()
    {
        _currentMenu = mainMenu;
        gameMenu.SetActive(false);
        endMenu.SetActive(false);
        creditsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void OpenCurtain()
    {
        if(curtainAnimator.enabled)
            curtainAnimator.SetTrigger(OpenCloseCurtain);
        curtainAnimator.enabled = true;
        Invoke(nameof(StartGame), 0.5f);
    }

    public void ShowTutorialDialog()
    {
        mainMenu.SetActive(false);
        tutorialDialog.SetActive(true);
    }
    
    private void StartGame()
    {
        tutorialDialog.SetActive(false);
        _currentMenu.SetActive(false);
        _currentMenu = gameMenu;
        _currentMenu.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ShowCredits()
    {
        _currentMenu.SetActive(false);
        creditsMenu.SetActive(true);
        _currentMenu = creditsMenu;
    }

    public void CloseCurtain()
    {
        curtainAnimator.SetTrigger(OpenCloseCurtain);
        Invoke(nameof(ShowEndScreen), 0.5f);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void ShowEndScreen()
    {
        _currentMenu.SetActive(false);
        endMenu.SetActive(true);
        _currentMenu = endMenu;
    }

    public void ShowMainMenu()
    {
        _currentMenu.SetActive(false);
        mainMenu.SetActive(true);
        _currentMenu = mainMenu;
    }
    
    
    
}

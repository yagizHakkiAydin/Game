using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScreenManager : MonoBehaviour
{
    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject Preferences;
    [SerializeField] private GameObject GameModesMenu;
    [SerializeField] private GameObject FriendAddMenu;
    [SerializeField] private GameObject QuestionAddMenu;
    [SerializeField] private GameObject LoginScreen;
    [SerializeField] private GameObject SignupScreen;
    [SerializeField] private GameObject SettingsMenu;


    [SerializeField] private GameObject ClassicalQuestionScreen;
    [SerializeField] private GameObject NumericalQuestionScreen;
    [SerializeField] private GameObject BottomButtonsKeeper;

    [SerializeField] private GameObject LoadScreen;
    [SerializeField] private GameObject ProfileScreen;
    [SerializeField] private GameObject LeagueScreen;



    [SerializeField] private Button LeagueButton;
    [SerializeField] private Button MainScreenButton;
    [SerializeField] private Button ProfileButton;


    [SerializeField] CanvasGroup canvasGroup;



    [SerializeField] float ScreenFadingSpeed;



    void Start()
    {
        this.AddListenersToBottomButtons();
        this.SwitchToLoginScreen();
    }






    public void AddListenersToBottomButtons()
    {
        this.LeagueButton.onClick.AddListener( SwitchToLeagueScreen );
        this.MainScreenButton.onClick.AddListener( SwitchToMainMenu );
        this.ProfileButton.onClick.AddListener( SwitchToProfileScreen ); 
    }





    public void CloseAllScreens()
    {
        this.MainMenu.SetActive(false);
        this.Preferences.SetActive(false);
        this.GameModesMenu.SetActive(false);
        this.FriendAddMenu.SetActive(false);
        this.QuestionAddMenu.SetActive(false);
        this.LoginScreen.SetActive(false);
        this.SignupScreen.SetActive(false);
        this.SettingsMenu.SetActive(false);
        this.ClassicalQuestionScreen.SetActive(false);
        this.NumericalQuestionScreen.SetActive(false);
        this.BottomButtonsKeeper.SetActive(false);
        this.LoadScreen.SetActive(false);
        this.ProfileScreen.SetActive(false);
        this.LeagueScreen.SetActive(false);
    } 


    public void SwitchToMainMenu()
    {
        this.CloseAllScreens();
        this.MainMenu.SetActive(true);
        this.BottomButtonsKeeper.SetActive(true);
    }


    public void SwitchToPreferences()
    {
        this.CloseAllScreens();
        this.Preferences.SetActive(true);
    }


    public void SwitchToGameModesMenu()
    {
        this.CloseAllScreens();
        this.GameModesMenu.SetActive(true);     
    }


    public void SwitchToFriendAddMenu()
    {
        this.CloseAllScreens();
        this.FriendAddMenu.SetActive(true);
    }


    public void SwitchToQuestionAddMenu()
    {
        this.CloseAllScreens();
        this.QuestionAddMenu.SetActive(true);
    }

    public void SwitchToLoginScreen()
    {
        this.CloseAllScreens();
        this.LoginScreen.SetActive(true);
    }


    public void SwitchToSignupScreen()
    {
        this.CloseAllScreens();
        this.SignupScreen.SetActive(true);
    }



    public void OpenSettingsMenu()
    {
        this.SettingsMenu.SetActive(true);
    }

    public void CloseSettingsMenu()
    {
        this.SettingsMenu.SetActive(false);
    }

    public bool IsSettingsMenuOpen()
    {
        return this.SettingsMenu.active;
    }






    public void SwitchToClassicalQuestionScreen()
    {
        this.CloseAllScreens();
        this.ClassicalQuestionScreen.SetActive(true);
    }



    public void SwitchToNumericalQuestionScreen()
    {
        this.CloseAllScreens();
        this.NumericalQuestionScreen.SetActive(true);
    }









    public void SwitchToLeagueScreen()
    {
        this.CloseAllScreens();
        this.LeagueScreen.SetActive(true);
        this.BottomButtonsKeeper.SetActive(true);
        
    }





    public void SwitchToProfileScreen()
    {
        this.CloseAllScreens();
        this.ProfileScreen.SetActive(true);
        this.BottomButtonsKeeper.SetActive(true);
    }




    public void SwitchToLoadScreen()
    {
        this.CloseAllScreens();
        this.LoadScreen.SetActive(true);  
    }






    public void FadeScreenForOneUpdate()
    {

        canvasGroup.alpha -= 0.01f*ScreenFadingSpeed;



    }


    public void FixFadedColors()
    {
        canvasGroup.alpha = 1.0f;
    }


    public bool IsCompletelyFaded()
    {
        return (canvasGroup.alpha <= 0.00001f);
    }
}

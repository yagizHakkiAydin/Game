using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LogInScreen : FullScreenMenu
{
    [SerializeField] private GameObject emailInputField;

    [SerializeField] private GameObject passwordInputField;

    [SerializeField] private Button loginButton;

    [SerializeField] private Button forgotPasswordButton;

    [SerializeField] private Button signUpButton;

    [SerializeField] private Button otoLoginCheckBox;

    [SerializeField] private TMP_Text loginErrorMessage;


    void Start()
    {
        this.AddListenersToMainMenuButtons();

        this.loginErrorMessage.text = "";
    }


    private void AddListenersToMainMenuButtons()
    {
        loginButton.onClick.AddListener( loginButtonAddListener );
        //forgotPasswordButton.onClick.AddListener( OpenSettings );
        signUpButton.onClick.AddListener( signUpButtonListener ); 
        otoLoginCheckBox.onClick.AddListener( otoLoginCheckBoxAddListener ); 
    }


    private void signUpButtonListener()
    {
        var screenManager =  GameObject.Find("ScreenManager").GetComponent<ScreenManager>();
        screenManager.SwitchToSignupScreen();
    }




    private void loginButtonAddListener()
    {

        var screenManager =  GameObject.Find("ScreenManager").GetComponent<ScreenManager>();
        var userInfoManager = GameObject.Find("UserInfoManager").GetComponent<UserInfoManager>();


        string email = emailInputField.GetComponent<TMP_InputField>().text;
        string password = passwordInputField.GetComponent<TMP_InputField>().text;


        if( ! userInfoManager.IsValidEmail(email) )
        {
            loginErrorMessage.text = "Lütfen geçerli bir e-mail adresi girin.";
        }
        else if( ! userInfoManager.IsPasswordLegal(password).Item2 )
        {
            loginErrorMessage.text = "Lütfen geçerli bir parola girin.";
        }
        else
        {
            screenManager.SwitchToMainMenu();
        }

    }



    private void otoLoginCheckBoxAddListener()
    {
        Image buttonImage = otoLoginCheckBox.GetComponent<Image>();

        if( buttonImage.color == Color.blue )
        {
            buttonImage.color = Color.white;
        }
        else
        {
            buttonImage.color = Color.blue;
        }


    }



}

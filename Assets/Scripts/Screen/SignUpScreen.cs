using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SignUpScreen : MonoBehaviour
{
    [SerializeField] private GameObject usernameInputField;

    [SerializeField] private GameObject emailInputField;

    [SerializeField] private GameObject passwordInputField;

    [SerializeField] private Button signUpButton;

    [SerializeField] private Button switchToLoginButton;


    [SerializeField] private TMP_Text signUpErrorMessage;



    void Start()
    {
        this.AddListenersToMainMenuButtons();

        this.signUpErrorMessage.text = "";
    }


    private void AddListenersToMainMenuButtons()
    {
        switchToLoginButton.onClick.AddListener( loginButtonAddListener );
        signUpButton.onClick.AddListener(  signUpButtonAddListener );
    }


    private void loginButtonAddListener()
    {
        var screenManager =  GameObject.Find("ScreenManager").GetComponent<ScreenManager>();
        screenManager.SwitchToLoginScreen();
    }


    
    private void signUpButtonAddListener()
    {
        var screenManager =  GameObject.Find("ScreenManager").GetComponent<ScreenManager>();
        var userInfoManager = GameObject.Find("UserInfoManager").GetComponent<UserInfoManager>();

        string username = usernameInputField.GetComponent<TMP_InputField>().text;
        string email = emailInputField.GetComponent<TMP_InputField>().text;
        string password = passwordInputField.GetComponent<TMP_InputField>().text;


        this.signUpErrorMessage.text = userInfoManager.IsPasswordLegal( password ).Item1;

        if(!userInfoManager.IsValidEmail(email))
        {
            this.signUpErrorMessage.text = "Lütfen geçerli bir e-mail adresi girin.";
        }

        if( ! userInfoManager.CanThisUsernameBeRegisteredToServer( username ).Item2 )
        {
            this.signUpErrorMessage.text = userInfoManager.CanThisUsernameBeRegisteredToServer( username ).Item1;
        }


    }






}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : FullScreenMenu
{

    [SerializeField] private Button NewGameButton;
    [SerializeField] private Button SettingsButton;
    [SerializeField] private Transform SpaceShip;


    [SerializeField] private Transform damageViewer;
    [SerializeField] private Transform coinsViewer;
    [SerializeField] private Button settingsButton;
    


    [SerializeField] private float SpaceShipAnimationUpDownInterval;     //
    [SerializeField] private float SpaceShipAnimationUpDownFrequency;   //Allows user to change animation settings
    [SerializeField] private float SpaceShipMoveLeftSpeed;             //




    private float spaceShipInitialLocalYPosition;
    private float spaceShipInitialLocalXPosition;




    private float UpdatedDegreeValueForPeriodicMove; //used in only SetVerticalPositionOfShipForOneUpdate() for calling Mathf.Sin() function




    private bool HasUserClickedNewGameButton;


    void Start()
    {
        SpaceShip.SetAsLastSibling();
        this.SaveSpaceShipInitialPositionValues();
        this.AddListenersToMainMenuButtons();
        this.setUIElementPositions();
    }



    private void setUIElementPositions()
    {
        damageViewer.localPosition = new Vector3(  170 ,  damageViewer.localPosition.y ,  damageViewer.localPosition.z );
        Debug.Log(damageViewer.localPosition.x);

    }




    private void AddListenersToMainMenuButtons()
    {
        NewGameButton.onClick.AddListener( DeclareNewGameProgressHasStarted );
        SettingsButton.onClick.AddListener( OpenSettings );  
    }




    void FixedUpdate()
    {
        this.SetVerticalPositionOfShipForOneUpdate();

        if(HasUserClickedNewGameButton)
        {
            this.UpdateEffectsOfSwitchingNewGame();
        }
    }






    private void UpdateEffectsOfSwitchingNewGame()
    {

        var screenManager =  GameObject.Find("ScreenManager").GetComponent<ScreenManager>();

        this.MoveSpaceShipToRightForOneUpdate();

        //Checks if spaceship went to right after that starts to fade screens
        if( SpaceShip.position.x >=  ( Screen.width * 1.5f)  )
        {
            screenManager.FadeScreenForOneUpdate();
        }

        //If screen gone dark completely,normalizes effects of the progress and completes the progress
        if(screenManager.IsCompletelyFaded())
        {
            this.NormalizeAffectsOfSwitchingNewGameProgress();
        }

    }





    private void ReinitializeSpaceShipPosition()
    {
        float initX = this.spaceShipInitialLocalXPosition;

        float initY = this.spaceShipInitialLocalYPosition;

        this.SpaceShip.localPosition = new Vector3(initX , initY , 0f);
    }


    







    //Saves initial position of the spaceship
    //Because after spaceship goes to the right and user wants to go back to the main menu,
    //spaceship has to be it's initial position
    private void SaveSpaceShipInitialPositionValues()
    {
        this.UpdatedDegreeValueForPeriodicMove = 0.0f;
        spaceShipInitialLocalYPosition = SpaceShip.localPosition.y;
        spaceShipInitialLocalXPosition = SpaceShip.localPosition.x;
    }



    //When user hits new game button,this function gets called and FixedUpdate executes effects for new game
    private void DeclareNewGameProgressHasStarted()
    {
        this.HasUserClickedNewGameButton = true;
    }



    //Opens settings menu when user clicks settings button
    private void OpenSettings()
    {
        var sc = GameObject.Find("ScreenManager").GetComponent<ScreenManager>();
        if( ! sc.IsSettingsMenuOpen() )
        {
            sc.OpenSettingsMenu();
        }
        else
        {
            sc.CloseSettingsMenu();
        }
    }



    //Spaceship goes up and down periodicly
    //
    //This periodic move is handled by using "Sin()" function,at every call of this function,
    //new updated parameter is given to sin function and this parameter is "UpdatedDegreeValueForPeriodicMove"
    //
    //User can change the interval of vertical position that the spaceship moves on from theinspector screen
    //
    //User can change the frequency of the spaceship's periodic move from the inspector screen
    //
    public void SetVerticalPositionOfShipForOneUpdate()
    {
        float newX = SpaceShip.localPosition.x;

        float newY = SpaceShip.localPosition.y;

        float newZ = SpaceShip.localPosition.z;

        newY += Mathf.Sin( Mathf.Deg2Rad * UpdatedDegreeValueForPeriodicMove ) * SpaceShipAnimationUpDownInterval;


        this.UpdatedDegreeValueForPeriodicMove += 2.0f * this.SpaceShipAnimationUpDownFrequency;


        this.SpaceShip.localPosition = new Vector3( newX , newY , newZ );

    }








    //For every call,spaceship goes right
    //Should be called when user starts new game button
    private void MoveSpaceShipToRightForOneUpdate()
    {

        float spaceShipX = this.SpaceShip.localPosition.x;
        float spaceShipY = this.SpaceShip.localPosition.y;
        float spaceShipZ = this.SpaceShip.localPosition.z;

        this.SpaceShip.localPosition = new Vector3( (1.0f*SpaceShipMoveLeftSpeed + spaceShipX) , spaceShipY , spaceShipZ );
    }




    //After spaceship moves left and screen gets completely darker,this function gets called
    //
    //This function fixes all the members of this class back because if user goes back to the main menu
    //because some members keeps information for starting the animations and those needs to be fixed back
    //and also because of the animations,spaceship goes right and it's position needs to be fixed too
    //
    private void NormalizeAffectsOfSwitchingNewGameProgress()
    {

        var screenManager =  GameObject.Find("ScreenManager").GetComponent<ScreenManager>();

        this.HasUserClickedNewGameButton = false;

        this.ReinitializeSpaceShipPosition();

        screenManager.FixFadedColors();

        screenManager.SwitchToGameModesMenu();
    }

}

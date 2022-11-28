using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameModesMenu : MonoBehaviour
{


    [SerializeField] private Button BackToMainMenuButton;
    [SerializeField] private Button BattleRoyaleButton;
    [SerializeField] private Button OneVsOneButton;


    void Start()
    {
        this.AddListenersToGameModesMenuButtons();
    }



    private void AddListenersToGameModesMenuButtons()
    {
        BackToMainMenuButton.onClick.AddListener( BackToMainMenu );
        BattleRoyaleButton.onClick.AddListener( StartBattleRoyale );
        OneVsOneButton.onClick.AddListener( StartOneVsOne );
    }


    private void BackToMainMenu()
    {
        GameObject.Find("ScreenManager").GetComponent<ScreenManager>().SwitchToMainMenu();
    }
    


    private void StartBattleRoyale()
    {
        GameObject.Find("ScreenManager").GetComponent<ScreenManager>().SwitchToLoadScreen();
    }

    private void StartOneVsOne()
    {
        GameObject.Find("ScreenManager").GetComponent<ScreenManager>().SwitchToLoadScreen();
    }






}

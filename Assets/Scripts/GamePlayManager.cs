using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager : MonoBehaviour
{
    ScreenManager _screenManager;
    ClassicalQuestionScreen _classicalQuestionScreen;
    NumericalQuestionScreen _numericalQuestionScreen;

    private bool hasServerStartedGame;

    void Awake()
    {
        _classicalQuestionScreen = FindObjectOfType<ClassicalQuestionScreen>();
        _numericalQuestionScreen = FindObjectOfType<NumericalQuestionScreen>();
    }


    void Start()
    {
        _screenManager = ScreenManager.Instance;
    }



    void Update()
    {
        if (this.DoesServerWantToUpdateQuestion())
        {
            this.UpdateQuestion(this.GetQuestionType());
        }

        if (this.DoesServerWantToShowCorrectAnswer())
        {
            this.ShowCorrectAnswer();
        }

        if (this.DoesServerWantToGetUserAnswer())
        {
            this.SendUserAnswerToServer();
        }

        if (this.HasServerStartedGame())
        {
            this.StartTheGame(this.GetGameMode());
        }
    }






    private string GetUserAnswer()
    {
        if( this.GetQuestionType() == "classical" )
        {
            return _classicalQuestionScreen.GetUserChoice();
        }
        else
        {
            return _numericalQuestionScreen.GetUserAnswer();
        }
    }


    



    private void ShowCorrectAnswer()
    {
        if( this.GetQuestionType() == "classical" )
        {
            _classicalQuestionScreen.ShowCorrectAnswer();
        }
        else if( this.GetQuestionType() == "numerical" )
        {
            _numericalQuestionScreen.ShowCorrectAnswer();
        }
    }





    public void UpdateQuestion( string questionType )
    {
        if( questionType == "classical" )
        {
            this.SetClassicalQuestion();
        }
        else if( questionType == "numerical" )
        {
            this.SetNumericalQuestion();
        }
    }
    private void SetNumericalQuestion()
    {
        this._numericalQuestionScreen.UpdateQuestion();
    }
    private void SetClassicalQuestion()
    {
        this._classicalQuestionScreen.UpdateQuestion();
    }














    public void StartTheGame( string gameMode )
    {
        if( gameMode == "Battle Royale" )
        {
            this.StartBattleRoyaleGame();
        }
        else if( gameMode == "1 vs 1" )
        {
            this.StartOneVsOneGame();
        }
    }







    private string GetGameMode()
    {
        return "Battle Royale";
    }

    private string GetQuestionType()
    {
        return "classical";
    }

    public string GetNumericalQuestionText()
    {
        return "Deneme numeric soru metni";
    }

    public string GetClassicalQuestionText()
    {
        return "Deneme klasik soru metni";
    }

    public string GetClassicalQuestionChoiceA()
    {
        return "cevap a";
    }

    public string GetClassicalQuestionChoiceB()
    {
        return "cevap b";
    }

    public string GetClassicalQuestionChoiceC()
    {
        return "cevap c";
    }

    public string GetClassicalQuestionChoiceD()
    {
        return "cevap d";
    }

    public string GetCorrectAnswerForClassicalQuestion()
    {
        return "A";
    }

    public string GetCorrectAnswerForNumericalQuestion()
    {
        return "150";
    }

    public bool DoesServerWantToUpdateQuestion()
    {
        return true;
    }

    
    public bool DoesServerWantToShowCorrectAnswer()
    {
        return false;
    }

    public bool DoesServerWantToGetUserAnswer()
    {
        return true;
    }





    //Will be filled,called from StartTheGame()
    private void StartBattleRoyaleGame()
    {
        _screenManager.SwitchToClassicalQuestionScreen();  //Will be deleted
    }



    //Will be filled,called from StartTheGame()
    private void StartOneVsOneGame()
    {
        _screenManager.SwitchToNumericalQuestionScreen();  //Will be deleted
    }



    public void SendUserAnswerToServer()
    {
        string answer = this.GetUserAnswer();


        //string answer , server'a gönderilecek
    }


    public bool HasServerStartedGame()
    {
        return false;
    }


}

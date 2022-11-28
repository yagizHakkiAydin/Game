using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumericalQuestionScreen : MonoBehaviour
{


    [SerializeField] private Text questionText;


    //Text that user can see his/her answer,updated when user presses another digit button or deletes one digit
    [SerializeField] private Text userAnswerText;



    //List that keeps digit buttons from 0 to 9
    [SerializeField] private List<Button> numericalButtons;


    //Button that allows user to delete one digit from his answer
    [SerializeField] private Button eraseButton;


    [SerializeField] private Button sendAnswerButton;



    //Used to keep correct answerButtons
    [SerializeField] private GameObject correctAnswerBlock;
    [SerializeField] private Text correctAnswerText;




    //When user enters answer,it is in form of string to update text on UI but that string
    //gets converted to long to compare users answer with correct answer
    private long userAnswer = 0;


    //This string keeps user answer
    private string userAnswerString;


    private long correctAnswer = 0;




    private bool updateQuestion;




    private GamePlayManager _gamePlayManager;

    private ScreenManager _screenManager;



    void Start()
    {
        updateQuestion = false;
        _gamePlayManager = GameObject.Find("GamePlayManager").GetComponent<GamePlayManager>();
        _screenManager = GameObject.Find("ScreenManager").GetComponent<ScreenManager>();
        this.correctAnswerBlock.SetActive(false);
        this.AllListenersToNumericalQuestionScreenButtons();
        this.AllListenersToNonNumericalQuestionScreenButtons();
    }


    private void AllListenersToNumericalQuestionScreenButtons()
    {
        numericalButtons[0].onClick.AddListener( press0 );
        numericalButtons[1].onClick.AddListener( press1 );
        numericalButtons[2].onClick.AddListener( press2 );
        numericalButtons[3].onClick.AddListener( press3 );
        numericalButtons[4].onClick.AddListener( press4 );
        numericalButtons[5].onClick.AddListener( press5 );
        numericalButtons[6].onClick.AddListener( press6 );
        numericalButtons[7].onClick.AddListener( press7 );
        numericalButtons[8].onClick.AddListener( press8 );
        numericalButtons[9].onClick.AddListener( press9 );
    }


    private void AllListenersToNonNumericalQuestionScreenButtons()
    {
        eraseButton.onClick.AddListener( eraseOneDigit );
        sendAnswerButton.onClick.AddListener( UserSendsAnswer );
    }



    //______________This block updates answer according to pressed buttons by user______________________

    private void press0()
    {
        this.updateUserAnswerByAddingDigitAtTheEnd(0); 
    }
    private void press1()
    {
        this.updateUserAnswerByAddingDigitAtTheEnd(1); 
    }
    private void press2()
    {
        this.updateUserAnswerByAddingDigitAtTheEnd(2); 
    }
    private void press3()
    {
        this.updateUserAnswerByAddingDigitAtTheEnd(3); 
    }
    private void press4()
    {
        this.updateUserAnswerByAddingDigitAtTheEnd(4); 
    }
    private void press5()
    {
        this.updateUserAnswerByAddingDigitAtTheEnd(5); 
    }
    private void press6()
    {
        this.updateUserAnswerByAddingDigitAtTheEnd(6); 
    }
    private void press7()
    {
        this.updateUserAnswerByAddingDigitAtTheEnd(7);
    }
    private void press8()
    {
        this.updateUserAnswerByAddingDigitAtTheEnd(8);
    }
    private void press9()
    {
        this.updateUserAnswerByAddingDigitAtTheEnd(9);
    }

    private void updateUserAnswerByAddingDigitAtTheEnd( int addedDigitAtTheEnd )
    {
        userAnswer *= 10;
        userAnswer += addedDigitAtTheEnd;
        userAnswerString = userAnswer.ToString();
        userAnswerText.text = userAnswerString;   
    }



    private void eraseOneDigit()
    {

        try
        {
            userAnswerString = userAnswerString.Remove(userAnswerString.Length - 1);

            if( userAnswer>10 )
            {
                userAnswer /= 10;
            }
            else
            {
                userAnswer = 0;
            }
            userAnswerText.text = userAnswerString;
            Debug.Log(userAnswer);
        }
        catch( Exception e )
        {
            //Intentionally Empty
        }

    }

    //____________________________________________________________________________________________________________




    private void LockAllButtonsAfterPlayerSendsAnswer()
    {
        this.SetInteractableStatusOfAllButtons(false);
    }

    private void UnlockAllButtons()
    {
        this.SetInteractableStatusOfAllButtons(true);
    }




    private void SetInteractableStatusOfAllButtons( bool status )
    {
        for( int i=0;i<numericalButtons.Count ; i++ )
        {
            numericalButtons[i].interactable = status;
        }
        eraseButton.interactable = status;
        sendAnswerButton.interactable = status;
    }



    private void UserSendsAnswer()
    {
        this.LockAllButtonsAfterPlayerSendsAnswer();
        this.UpdateCorrectAnswerBlockText();
    } 





    public string GetUserAnswer()
    {
        return this.userAnswerString;
    }





    private void UpdateCorrectAnswerBlockText()
    {
        string newCorrectAnswerBlockText = "Cevap: " + this.correctAnswer.ToString();

        this.correctAnswerText.text = newCorrectAnswerBlockText;
    }





    public void UpdateQuestion()
    {
        this.correctAnswerBlock.SetActive(false);
        this.SetQuestionText( _gamePlayManager.GetNumericalQuestionText());
        this.SetCorrectAnswer( _gamePlayManager.GetCorrectAnswerForNumericalQuestion() );
        this.UnlockAllButtons();
    }



    private void SetQuestionText( string text )
    {
        this.questionText.text = text;
    }


    private void SetCorrectAnswer( string text )
    {
        try
        {
            this.correctAnswer = long.Parse( text );
        }
        catch( Exception e )
        {
            this.correctAnswer = -1;
        }
    }


    public void ShowCorrectAnswer()
    {
        this.correctAnswerBlock.SetActive(true);
    }


}

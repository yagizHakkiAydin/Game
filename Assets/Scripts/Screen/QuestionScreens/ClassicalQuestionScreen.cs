using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClassicalQuestionScreen : PlayScreen
{
    [SerializeField] private GameObject questionBlock;

    [SerializeField] private Button choiceAButton;
    [SerializeField] private Button choiceBButton;
    [SerializeField] private Button choiceCButton;
    [SerializeField] private Button choiceDButton;

    private string userChoice;

    private string correctAnswer;

    private Color defaultButtonColor;

    GamePlayManager _gamePlayManager;

    ScreenManager _screenManager;

    void Start()
    {
        _gamePlayManager = FindObjectOfType<GamePlayManager>(true);
        _screenManager = ScreenManager.Instance;
        userChoice = "";
        this.defaultButtonColor = choiceAButton.GetComponent<Image>().color;
        AddListenersToClassicalQuestionScreenButtons();
    }

    private void AddListenersToClassicalQuestionScreenButtons()
    {
        choiceAButton.onClick.AddListener( ChooseA );
        choiceBButton.onClick.AddListener( ChooseB );
        choiceCButton.onClick.AddListener( ChooseC );
        choiceDButton.onClick.AddListener( ChooseD );
    }

    public string GetUserChoice()
    {
        return this.userChoice;
    }

    public void UpdateQuestion()
    {
        this.UnlockAllButtons();
        questionBlock.gameObject.transform.GetChild(0).GetComponent<Text>().text = _gamePlayManager.GetClassicalQuestionText();
        choiceAButton.gameObject.transform.GetChild(0).GetComponent<Text>().text = _gamePlayManager.GetClassicalQuestionChoiceA();
        choiceBButton.gameObject.transform.GetChild(0).GetComponent<Text>().text = _gamePlayManager.GetClassicalQuestionChoiceB();
        choiceCButton.gameObject.transform.GetChild(0).GetComponent<Text>().text = _gamePlayManager.GetClassicalQuestionChoiceC();
        choiceDButton.gameObject.transform.GetChild(0).GetComponent<Text>().text = _gamePlayManager.GetClassicalQuestionChoiceD();
        this.correctAnswer = _gamePlayManager.GetCorrectAnswerForClassicalQuestion();
    }

    public void ChooseA()
    {
        this.MarkChoiceAsChoosen("A");
    }
    public void ChooseB()
    {
        this.MarkChoiceAsChoosen("B");
    }
    public void ChooseC()
    {
        this.MarkChoiceAsChoosen("C");
    }
    public void ChooseD()
    {
        this.MarkChoiceAsChoosen("D");
    }

    public void MarkChoiceAsChoosen( string choice )
    {
        this.LockAllButtonsAfterPlayerSendsAnswer();
        if( choice == "A")
        {
            choiceAButton.GetComponent<Image>().color = new Color( 0 , 0 , 255 , 255 );
            this.userChoice = "A";
        }
        else if( choice == "B")
        {
            choiceBButton.GetComponent<Image>().color = new Color( 0 , 0 , 255 , 255 );
            this.userChoice = "B";
        }
        else if( choice == "C")
        {
            choiceCButton.GetComponent<Image>().color = new Color( 0 , 0 , 255 , 255 );
            this.userChoice = "C";
        }
        else if( choice == "D")
        {
            choiceDButton.GetComponent<Image>().color = new Color( 0 , 0 , 255 , 255 );
            this.userChoice = "D";
        }
    }



    public void ShowCorrectAnswer()
    {
        this.LockAllButtonsAfterPlayerSendsAnswer();
        if( this.correctAnswer == "A" )
        {
            choiceAButton.GetComponent<Image>().color = new Color( 40 , 255 , 0 , 255 );
        }
        else if( this.correctAnswer == "B" )
        {
            choiceBButton.GetComponent<Image>().color = new Color( 40 , 255 , 0 , 255 );
        }
        else if( this.correctAnswer == "C" )
        {
            choiceCButton.GetComponent<Image>().color = new Color( 40 , 255 , 0 , 255 );
        }
        else if( this.correctAnswer == "D" )
        {
            choiceDButton.GetComponent<Image>().color = new Color( 40 , 255 , 0 , 255 );
        }
    }

    public void SetAllChoiceColorsToDefault()
    {
        choiceAButton.GetComponent<Image>().color = defaultButtonColor;
        choiceBButton.GetComponent<Image>().color = defaultButtonColor;
        choiceCButton.GetComponent<Image>().color = defaultButtonColor;
        choiceDButton.GetComponent<Image>().color = defaultButtonColor;
    }

    public void SetCorrectAnswer( string text )
    {
        this.correctAnswer = text;
    }

    public void LockAllButtonsAfterPlayerSendsAnswer()
    {
        this.SetInteractableStatusOfAllButtons(false);
    }

    public void UnlockAllButtons()
    {
        this.SetInteractableStatusOfAllButtons(true);
    }

    private void SetInteractableStatusOfAllButtons(bool status)
    {
        choiceAButton.interactable = status;
        choiceBButton.interactable = status;
        choiceCButton.interactable = status;
        choiceDButton.interactable = status;  
    }
}

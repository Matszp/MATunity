using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Xml.Serialization;

public class MathProblems : MonoBehaviour
{
    [SerializeField] private TMP_Text questionText;
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private Button submitButton;
    [SerializeField] private TMP_Text scoreText;


    private int correctAnswer; //przechowanie odpowiedzi
    private int score = 0; // wynik
    private string currentOperator; // symbol operacji matematycznej

    private enum Operation {Addition , Subtraction , Mutliplication , Division }

    void Start()
    {
        GenerateNewQuestion();
        submitButton.onClick.AddListener(CheckAnswer);
    }

    
    void GenerateNewQuestion()
    {
        int num1 = Random.Range(0, 20);
        int num2 = Random.Range(0, 20);
        Operation chosenOperation = (Operation)Random.Range(0, 4);

        switch (chosenOperation)
        {
            case Operation.Addition :
                correctAnswer = num1 + num2;
                currentOperator = "+";
                break;
            case Operation.Subtraction :
                correctAnswer = num1 - num2;
                currentOperator = "-";
                break;
            case Operation.Mutliplication:
                correctAnswer = num1 * num2;
                currentOperator = "*";
                break;
            case Operation.Division :
                //unikanie dzielenia przez zero
                num1 = num2 * Random.Range(1,10);
                correctAnswer = num1 / num2;
                currentOperator = "/";
                break;

                
        }
        
        questionText.text = $"{num1} {currentOperator} {num2} = ?";
        inputField.text = ""; // czyúcimy pole inputa
        inputField.ActivateInputField(); // ustawiamy focus na input
    }

    void CheckAnswer()

    {
        if(int.TryParse(inputField.text, out int userAnswer)) 
        {
            if (userAnswer == correctAnswer)
            {
                score++; //zwiÍkszamy licznik poprawnych odpowiedzi
                scoreText.text = "Punkty" + score;
                GenerateNewQuestion();

            }
            else
            {
                questionText.text = "èle! SprÛbuj ponownie";
                inputField.text = "";  // czyúcimy pole inputa
                inputField.ActivateInputField();
            }
        }
    }
}

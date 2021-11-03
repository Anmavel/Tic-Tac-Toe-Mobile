using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    private int player = 1;
    private int turn;
    public int buttonIndex = 0;
    [SerializeField] private Button[] arrayButtons;
    [SerializeField] private Text infoText;
    [SerializeField] private InputField inputField1;
    [SerializeField] private InputField inputField2;
    [SerializeField] private AudioManager refAudioManager;
    private int[] field = new int[9];
    private int points;
    private String namePlayer1;
    private String namePlayer2;
    private bool gameIsOver;


    public void Name_edit()
    {
        if (gameIsOver) return;
        SetTextinfoToCurrentPlayer();

    }

    private void SetTextinfoToCurrentPlayer()
    {
        if (player == 1)
        {
            namePlayer1 = inputField1.text;
            if (String.IsNullOrEmpty(namePlayer1))
            {
                namePlayer1 = 1.ToString();
            }
            infoText.text = "Player: " + namePlayer1;
        }

        else
        {
            namePlayer2 = inputField2.text;
            if (String.IsNullOrEmpty(namePlayer2))
            {
                namePlayer2 = 2.ToString();
            }

            infoText.text = "Player: " + namePlayer2;
        }

    }


    public void ClickedOnButton(int buttonIndex)
    {
        refAudioManager.PlayClickSound();
        arrayButtons[buttonIndex].interactable = false;
        turn++;
        field[buttonIndex] = player;

        if (player == 1)
        {

            arrayButtons[buttonIndex].GetComponentInChildren<Text>().text = "X";


        }

        else
        {

            arrayButtons[buttonIndex].GetComponentInChildren<Text>().text = "O";

        }

        // arrayButtons[buttonIndex].GetComponentInChildren<Text>().text = player == 1 ? "X" : "O";



        if (Checkwin())
        {
            Win();
            return;
        }


        player = player == 1 ? 2 : 1;
        SetTextinfoToCurrentPlayer();

        if (turn == 9)
        {
            infoText.text = "Game Over";
            gameIsOver = true;
            refAudioManager.PlayLoseSound();
        }

    }

    private bool Checkwin()
    {
        for (int i = 0; i < 9; i += 3) // Uberprüfung der Reihen 
        {
            for (int j = i; j < i + 3; j++)
            {
                if (field[j] == player)
                {
                    points++;
                }
            }

            if (points == 3)
            {  //Spieler hat gewonnen

                for (int j = i; j < i + 3; j++)
                {
                    arrayButtons[j].GetComponentInChildren<Text>().color = Color.red;
                }

                return true;
            }
            points = 0;
        }

        for (int i = 0; i < 3; i++) // Uberprüfung der Spalten 
        {
            for (int j = i; j < 9; j += 3)
            {
                if (field[j] == player)
                {
                    points++;
                }
            }

            if (points == 3)
            {  //Spieler hat gewonnen

                for (int j = i; j < 9; j += 3)
                {
                    arrayButtons[j].GetComponentInChildren<Text>().color = Color.red;
                }
                return true;
            }
            points = 0;
        }
        for (int i = 0; i < 9; i += 4) // Uberprüfung Diagonal 1
        {
            if (field[i] == player)
            {
                points++;
            }
        }

        if (points == 3)
        {  //Spieler hat gewonnen

            for (int i = 0; i < 9; i += 4)
            {
                arrayButtons[i].GetComponentInChildren<Text>().color = Color.red;
            }

            return true;
        }
        points = 0;

        for (int i = 2; i < 7; i += 2)//Uberprüfung Diagonal 2
        {
            if (field[i] == player)
            {
                points++;
            }
        }

        if (points == 3)
        {  //Spieler hat gewonnen

            for (int i = 2; i < 7; i += 2)
            {
                arrayButtons[i].GetComponentInChildren<Text>().color = Color.red;
            }

            return true;
        }


        points = 0;
        return false;
    }

    private void Win()
    {

        infoText.text = player == 1 ? "Winner: " + namePlayer1 : "Winner: " + namePlayer2;
        refAudioManager.PlayWinSound();
        for (int i = 0; i < arrayButtons.Length; i++)
        {
            arrayButtons[i].interactable = false;
        }
        gameIsOver = true;

    }

    public void Reset()
    {
        refAudioManager.PlayClickSound();
        SceneManager.LoadScene(0);
    }





}

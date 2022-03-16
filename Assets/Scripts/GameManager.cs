using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject gameScreen, endScreen;

    public Ball ball;
    
    public Text player1ScoreText, player2ScoreText;
    public Text winnerTextLabel;
    
    public Paddle paddle1, paddle2;
    
    private State _gameState = State.Game;
    private string _winnerText;
    private int _player1Score, _player2Score;

    private void Awake()
    {
        Instance = this;
        SetComputerPlaying();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            ShowMenu();
        }
    }

    public void Player1Scores()
    {
        _player1Score++;
        player1ScoreText.text = _player1Score.ToString();
        if (_player1Score == 10)
        {
            _winnerText = "Player 1 wins!";
            SwitchState(State.EndScreen);
            return;

        } 
        StartBall();
        ResetPaddles();
    }

    public void Player2Scores()
    { 
        _player2Score++;
        player2ScoreText.text = _player2Score.ToString();
        if (_player2Score == 10)
        {
            _winnerText = "Player 2 wins";
            SwitchState(State.EndScreen);
            return;
        } 
        StartBall();
        ResetPaddles();
    }
    

    private void StartBall()
    {
        this.ball.ResetPosition();
        this.ball.AddStartingForce();
    }

    private void ResetPaddles()
    {
        this.paddle1.ResetPosition();
        this.paddle2.ResetPosition();
    }

    private void ResetScores()
    {
        _player1Score = 0;
        _player2Score = 0;
        player1ScoreText.text = "0";
        player2ScoreText.text = "0";
    }

    private static void EnableComputer(Paddle paddle,int level)
    {
        paddle.GetComponent<PlayerPaddle>().enabled = false;
        paddle.GetComponent<ComputerPaddle>().enabled = true;
        paddle.GetComponent<ComputerPaddle>().SetLevel(level);
    }

    private static void DisableComputer(Paddle paddle)
    {
        paddle.GetComponent<ComputerPaddle>().enabled = false;
        paddle.GetComponent<PlayerPaddle>().enabled = true;
    }
    

    private void SetComputerPlaying()
    {
        if (GameSettings.ComputerPlayOnLeft)
        {
            int level = GameSettings.ComputerLeftDifficulty;
            EnableComputer(paddle1, level);
        }
        else
        {
            DisableComputer(paddle1);
        }

        if (GameSettings.ComputerPlayOnRight)
        {
            int level = GameSettings.ComputerRightDifficulty;
            EnableComputer(paddle2, level);
        }
        else
        {
            DisableComputer(paddle2);
        }
    }

    private void SwitchState(State newState)
    {
        _gameState = newState;
        switch (_gameState)
        {
            case State.Game:
                RestartGame();
                break;
            case State.EndScreen:
                ShowEndScreen();
                break;
        }
    }
    private void ShowEndScreen()
    {
        ball.ResetPosition();
        ResetPaddles();
        winnerTextLabel.text = _winnerText;
        endScreen.SetActive(true);
    }

    public void RestartGame()
    {
        endScreen.SetActive(false);
        ResetScores();
        ResetPaddles();
        StartBall();

    }

    public void ShowMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void OnResetButtonPressed()
    {
        SwitchState(State.Game);
    }
}
public enum State
{
    Game,
    EndScreen
}

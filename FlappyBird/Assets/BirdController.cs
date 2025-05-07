using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdController : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public float jumpForce;

    private float originalGravityScale;
    public static bool hasStarted;
    public static bool gameOver;

    public GameObject gameOverPanel;
    public TextMeshProUGUI pointsField;
    
    public TextMeshProUGUI gameOverPanelPointsField;
    public TextMeshProUGUI gameOverPanelHighscoreField;
    
    private int points;

    private bool isPaused;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originalGravityScale = rb2D.gravityScale;
        rb2D.gravityScale = 0;

        hasStarted = false;
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver == true)
        {
            return;
        }
        
        if (Input.GetButtonDown("Jump"))
        {
            if (hasStarted == false)
            {
                rb2D.gravityScale = originalGravityScale;
                hasStarted = true;
            }
            
            rb2D.linearVelocityY = 0;
            rb2D.AddForceY(jumpForce, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        gameOver = true;
        gameOverPanel.SetActive(true);
        
        gameOverPanelPointsField.text = points.ToString();

        var highscore = PlayerPrefs.GetInt("Highscore");

        if (points > highscore)
        {
            highscore = points;
            PlayerPrefs.SetInt("Highscore", highscore);
        }
        
        gameOverPanelHighscoreField.text = highscore.ToString();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Points"))
        {
            points++;
            pointsField.text = points.ToString();
        }
    }

    public void PauseGame()
    {
        if (isPaused)
        {
            isPaused = false;
            Time.timeScale = 1;
        }
        else
        {
            isPaused = true;
            Time.timeScale = 0;
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("FlappyBird");
    }
}

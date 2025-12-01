using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scoretafel : MonoBehaviour
{
    [SerializeField] private TMP_Text score;
    [SerializeField] private TMP_Text hitQuote;
    private float scoreAmount = 0;
    private float totalBalls = 0;
    public void OnBackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void IncreaseScore()
    {
        scoreAmount++;
        UpdateText();
    }

    public void IncreaseBalls()
    {
        totalBalls++;
        UpdateText();
    }

    public void UpdateText()
    {
        score.text = scoreAmount + " / " + totalBalls;
        hitQuote.text = "Hit quote: " + (scoreAmount / totalBalls) * 100 + " %";
    }
}

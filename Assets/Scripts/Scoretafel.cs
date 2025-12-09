using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scoretafel : MonoBehaviour
{
    [SerializeField] private TMP_Text score;
    [SerializeField] private TMP_Text hitQuote;
    [SerializeField] private GameObject tutorial;
    private float scoreAmount = 0;
    private float totalBalls = 0;

    private void Start()
    {
    }
    public void OnBackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void IncreaseScore()
    {
        scoreAmount++;
        tutorial.SetActive(false);
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

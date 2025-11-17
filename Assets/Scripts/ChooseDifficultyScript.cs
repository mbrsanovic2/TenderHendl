using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseDifficultyScript : MonoBehaviour
{
    public static int difficulty;

    public void SetDifficulty(int difficulty)
    {
        ChooseDifficultyScript.difficulty = difficulty;
        SceneManager.LoadScene(2);
    }
}

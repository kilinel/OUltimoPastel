using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFacade : MonoBehaviour
{
    [SerializeField] private TMP_Text statusText;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text remainingText;
    [SerializeField] private TMP_Text collectedText;
    private int score;
    private int remaining;
    private int total;

    private void Awake()
    {
        GameServices.Game = this;
    }

    private void Start()
    {
        remaining = FindObjectsByType<Pastel>(FindObjectsSortMode.None).Length;
        total = remaining;
        UpdateDisplay();
    }

    public void Collect(int points)
    {
        score += points;
        remaining = Mathf.Max(0, remaining - 1);
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        if (scoreText != null)
            scoreText.text = "Pontos: " + score.ToString("D5");
        if (remainingText != null)
            remainingText.text = "Faltam: " + remaining;
        if (collectedText != null)
            collectedText.text = "Pastéis: " + (total - remaining) + "/" + total + " coletados";
        if (statusText != null)
            statusText.text = remaining == 0
                ? "Voce coletou todos!\nR para reiniciar."
                : "WASD para mover.\nColete todos os pastéis!";
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) || (remaining == 0 && Input.touchCount >= 2))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnDestroy()
    {
        if (GameServices.Game == this)
            GameServices.Game = null;
    }
}

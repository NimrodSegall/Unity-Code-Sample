using UnityEngine;
using TMPro;
using GameRules;

namespace GameUI
{
    public class ScoreUI : MonoBehaviour
    {
        [SerializeField]
        private string baseText = "Score: ";
        private int score = 0;
        private TextMeshProUGUI scoreTextMesh;

        private void Start()
        {
            scoreTextMesh = GetComponent<TextMeshProUGUI>();
            GameEvents.singleton.onPlayerMunch += Munch;
            GameEvents.singleton.onResetGame += ResetGame;
            AddScore(0); // Initialize score text to 0
        }

        private void UpdateText()
        {
            if (scoreTextMesh != null)
            {
                scoreTextMesh.text = baseText + score.ToString();
            }
        }

        private void AddScore(int addedScore)
        {
            score += addedScore;
            UpdateText();
        }

        private void Munch()
        {
            AddScore(GameParameters.singleton.CupcakeScoreValue);
        }

        private void ResetGame()
        {
            score = 0;
            UpdateText();
        }
    }
}

using UnityEngine;
using TMPro;

public class ScoreIndicator : MonoBehaviour {
    public ScoreManager scoreManager;

    public TextMeshProUGUI distanceText;
    public TextMeshProUGUI highScoreText;

    void Update() {
        distanceText.text = scoreManager.score.ToString();
        if(scoreManager.newBest) {
            highScoreText.GetComponent<Animator>().SetBool("NewBest", true);
        }
        highScoreText.text = "Best: " + scoreManager.highScore.ToString();
    }
}

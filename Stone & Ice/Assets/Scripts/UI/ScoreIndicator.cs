using UnityEngine;
using TMPro;

public class ScoreIndicator : MonoBehaviour {
    public ScoreManager scoreManager;
    public TextMeshProUGUI distanceText;

    private Animator animator;

    void Start() {
        animator = GetComponent<Animator>();
    }

    void Update() {
        distanceText.text = scoreManager.score.ToString();
        if(scoreManager.newBest) {
            animator.SetBool("NewBest", true);
        }
    }
}

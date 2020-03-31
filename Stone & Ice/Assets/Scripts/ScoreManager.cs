using UnityEngine;

public class ScoreManager : MonoBehaviour {
    public Transform character;

    [HideInInspector] public int score = 0;
    [HideInInspector] public int highScore;

    [HideInInspector] public bool newBest = false;

    void Start() {
        highScore = PlayerPrefs.GetInt("highScore", 0);
    }

    void Update() {
        score = (int) character.position.z;
        if(score > highScore) {
            highScore = score;
            PlayerPrefs.SetInt("highScore", highScore);
            newBest = true;
        }
    }
}

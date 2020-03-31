using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProgressIndicator : MonoBehaviour {
    public Transform character;
    public LevelData levelData;

    private Slider progressSlider;
    private TextMeshProUGUI percentageText;

    private float progress = 0;

    void Start() {
        progressSlider = GetComponentInChildren<Slider>();
        percentageText = GetComponentInChildren<TextMeshProUGUI>();
    }

    void Update() {
        UpdateProgress();
        progressSlider.value = progress;
        percentageText.text = (progress * 100).ToString("0") + "%";
    }

    private void UpdateProgress() {
        progress = Mathf.Clamp01(character.position.z / levelData.endPoint);
        if(progress >= 1) {
            FindObjectOfType<GameManager>().ReturnToMenu();
        }
    }
}

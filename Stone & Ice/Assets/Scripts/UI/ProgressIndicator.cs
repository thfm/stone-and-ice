using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProgressIndicator : MonoBehaviour {
    public LevelManager levelManager;

    private Slider progressSlider;
    private TextMeshProUGUI percentageText;

    void Start() {
        progressSlider = GetComponentInChildren<Slider>();
        percentageText = GetComponentInChildren<TextMeshProUGUI>();
    }

    void Update() {
        progressSlider.value = levelManager.progress;
        percentageText.text = (levelManager.progress * 100).ToString("0") + "%";
    }
}

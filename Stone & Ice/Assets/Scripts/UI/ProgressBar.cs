using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour {
    public LevelManager levelManager;

    private Slider progressSlider;

    void Start() {
        progressSlider = GetComponent<Slider>();
    }

    void Update() {
        progressSlider.value = levelManager.progress;
    }
}

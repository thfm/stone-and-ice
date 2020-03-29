using UnityEngine;
using TMPro;

public class ProgressIndicator : MonoBehaviour {
    public Transform character;

    private TextMeshProUGUI progressText;

    void Start() {
        progressText = GetComponent<TextMeshProUGUI>();
    }

    void Update() {
        progressText.text = character.position.z.ToString("0");
    }
}

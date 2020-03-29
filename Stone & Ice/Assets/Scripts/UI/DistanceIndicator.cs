using UnityEngine;
using TMPro;

public class DistanceIndicator : MonoBehaviour {
    public Transform character;

    private TextMeshProUGUI distanceText;

    void Start() {
        distanceText = GetComponent<TextMeshProUGUI>();
    }

    void Update() {
        distanceText.text = character.position.z.ToString("0");
    }
}

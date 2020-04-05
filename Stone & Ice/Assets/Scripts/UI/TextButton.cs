using UnityEngine;
using TMPro;

public class TextButton : MonoBehaviour {
    public Color hoverColour;

    private TextMeshProUGUI text;
    private Color normalColour;

    void Start() {
        text = GetComponentInChildren<TextMeshProUGUI>();
        normalColour = text.color;
    }

    public void MouseEnter() {
        text.color = hoverColour;
    }

    public void MouseExit() {
        text.color = normalColour;
    }
}

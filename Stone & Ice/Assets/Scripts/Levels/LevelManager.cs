using UnityEngine;

public class LevelManager : MonoBehaviour {
    public Transform character;

    [HideInInspector] public float progress;

    private LevelData levelData;

    void Start() {
        levelData = GetComponent<LevelData>();
    }

    void Update() {
        progress = Mathf.Clamp01(character.position.z / levelData.endPoint);
        if(progress >= 1) {
            FindObjectOfType<GameManager>().ReturnToMenu();
        }
    }
}

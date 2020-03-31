using UnityEngine;

public class GameManager : MonoBehaviour {
    public GameObject character;

    public SceneLoader sceneLoader;
    [Range(0.5f, 3)] public float restartDelay;
    [Range(0.5f, 5)] public float menuReturnDelay;

    [Range(0.1f, 1)] public float musicFadeDuration;

    private LevelManager levelManager;
    private bool levelOver = false;

    void Start() {
        levelManager = FindObjectOfType<LevelManager>();
    }

    void Update() {
        if(character.transform.position.y < -1) {
            character.GetComponent<CharacterData>().isDead = true;
        }

        if(character.GetComponent<CharacterData>().isDead && !levelOver) {
            character.GetComponent<CharacterMovement>().enabled = false;
            sceneLoader.Invoke("ReloadCurrentScene", restartDelay);
            if(levelManager != null) {
                StartCoroutine(levelManager.FadeMusic(musicFadeDuration));
            }
            levelOver = true;
        }
    }

    public void ReturnToMenu() {
        if(!levelOver) {
            if(levelManager != null) {
                StartCoroutine(levelManager.FadeMusic(musicFadeDuration));
            }
            Invoke("LoadMenuScene", menuReturnDelay);
            levelOver = true;
        }
    }

    private void LoadMenuScene() {
        sceneLoader.LoadScene("Menu");
    }
}

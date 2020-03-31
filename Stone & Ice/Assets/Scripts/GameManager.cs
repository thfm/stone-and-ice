using UnityEngine;

public class GameManager : MonoBehaviour {
    public GameObject character;

    public SceneLoader sceneLoader;
    [Range(0.5f, 3)] public float restartDelay;
    [Range(0.5f, 5)] public float menuReturnDelay;

    [Range(0.1f, 1)] public float musicFadeDuration;

    public GameObject pauseMenu;
    public KeyCode pauseKey;

    private LevelManager levelManager;
    private bool gameOver = false;
    private bool gamePaused = false;

    void Start() {
        levelManager = FindObjectOfType<LevelManager>();
    }

    void Update() {
        if(character.transform.position.y < -1) {
            character.GetComponent<CharacterData>().isDead = true;
        }

        if(character.GetComponent<CharacterData>().isDead && !gameOver) {
            character.GetComponent<CharacterMovement>().enabled = false;
            StartCoroutine(levelManager.FadeMusic(musicFadeDuration));
            sceneLoader.Invoke("ReloadCurrentScene", restartDelay);
            gameOver = true;
        }

        if(Input.GetKeyDown(pauseKey)) {
            if(gamePaused) {
                ResumeGame();
            } else {
                PauseGame();
            }
        }
    }

    public void PauseGame() {
        Time.timeScale = 0;
        levelManager.StopMusic();
        pauseMenu.SetActive(true);
        gamePaused = true;
    }

    public void ResumeGame() {
        pauseMenu.SetActive(false);
        levelManager.ResumeMusic();
        Time.timeScale = 1;
        gamePaused = false;
    }

    public void ReturnToMenu() {
        if(!gameOver) {
            if(gamePaused) { ResumeGame(); }
            StartCoroutine(levelManager.FadeMusic(musicFadeDuration));
            Invoke("LoadMenuScene", menuReturnDelay);
            gameOver = true;
        }
    }

    private void LoadMenuScene() {
        sceneLoader.LoadScene("Menu");
    }
}

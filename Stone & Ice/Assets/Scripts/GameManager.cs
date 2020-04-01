using UnityEngine;

public class GameManager : MonoBehaviour {
    public GameObject character;

    public SceneLoader sceneLoader;
    [Range(0.5f, 3)] public float restartDelay;

    [Range(0.1f, 1)] public float musicFadeDuration;

    public KeyCode returnToMenuKey;

    private bool gameOver = false;

    void Update() {
        if(character.transform.position.y < -1) {
            character.GetComponent<CharacterData>().isDead = true;
        }

        if(character.GetComponent<CharacterData>().isDead && !gameOver) {
            character.GetComponent<CharacterMovement>().enabled = false;
            sceneLoader.Invoke("ReloadCurrentScene", restartDelay);
            gameOver = true;
        }

        if(Input.GetKeyDown(returnToMenuKey)) {
            ReturnToMenu();
        }
    }

    public void ReturnToMenu() {
        if(!gameOver) {
            StartCoroutine(sceneLoader.FadeToScene("Menu"));
            gameOver = true;
        }
    }
}

using UnityEngine;

public class GameManager : MonoBehaviour {
    public GameObject character;

    public SceneLoader sceneLoader;
    public float restartDelay;
    public float menuReturnDelay;

    private bool levelOver = false;

    void Update() {
        if(character.transform.position.y < -1) {
            character.GetComponent<CharacterData>().isDead = true;
        }

        if(character.GetComponent<CharacterData>().isDead && !levelOver) {
            character.GetComponent<CharacterMovement>().enabled = false;
            sceneLoader.Invoke("ReloadCurrentScene", restartDelay);
            levelOver = true;
        }
    }

    public void ReturnToMenu() {
        if(!levelOver) {
            Invoke("LoadMenuScene", menuReturnDelay);
            levelOver = true;
        }
    }

    private void LoadMenuScene() {
        sceneLoader.LoadScene("Menu");
    }
}

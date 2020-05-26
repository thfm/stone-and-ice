﻿using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject character;

    public SceneLoader sceneLoader;
    [Range(0.5f, 3)] public float restartDelay;

    public KeyCode returnToMenuKey;

    private bool gameOver = false;

    void Update()
    {
        if (character.transform.position.y < -1)
        {
            character.GetComponent<CharacterData>().isDead = true;
        }

        if (character.GetComponent<CharacterData>().isDead && !gameOver)
        {
            character.GetComponent<CharacterMovement>().enabled = false;
            sceneLoader.Invoke("ReloadCurrentScene", restartDelay);
            gameOver = true;
        }

        if (Input.GetKeyDown(returnToMenuKey))
        {
            ReturnToMenu();
        }
    }

    public void ReturnToMenu()
    {
        if (!gameOver)
        {
            sceneLoader.LoadScene("Menu");
            gameOver = true;
        }
    }
}

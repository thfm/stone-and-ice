using UnityEngine;

public class CharacterCollision : MonoBehaviour {
    private CharacterMovement movement;

    void Start() {
        movement = GetComponent<CharacterMovement>();
    }

    void OnCollisionEnter(Collision other) {
        movement.sliding = (other.gameObject.tag == "IceFloor");
    }
}

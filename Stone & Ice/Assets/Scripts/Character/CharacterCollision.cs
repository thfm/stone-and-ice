using UnityEngine;

public class CharacterCollision : MonoBehaviour {
    private CharacterMovement movement;

    void Start() {
        movement = GetComponent<CharacterMovement>();
    }

    void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Obstacle") {
            GetComponent<CharacterData>().isDead = true;
        } else {
            movement.sliding = (other.gameObject.tag == "IceFloor");
        }
    }
}

using UnityEngine;

public class ObstacleCollision : MonoBehaviour {
    public Material hitMaterial;

    void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Character") {
            GetComponent<Renderer>().material = hitMaterial;
            ObstacleMovement movement = GetComponent<ObstacleMovement>();
            if(movement != null) {
                movement.enabled = false;
            }
        }
    }
}

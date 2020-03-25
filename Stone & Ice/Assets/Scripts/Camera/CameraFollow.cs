using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public Transform character;
    public Vector3 followOffset;

    void Update() {
        transform.position = character.position + followOffset;
    }
}

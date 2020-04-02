using UnityEngine;

public class CameraMovement : MonoBehaviour {
    [Range(1, 10)] public float speed;

    private Vector3 targetPosition;

    void Start() {
        MoveTo(new Vector3(0, 2, 0));
    }

    void Update() {
        transform.position = Vector3.Lerp(
            transform.position,
            targetPosition,
            Time.deltaTime * speed
        );
    }

    public void MoveTo(Vector3 targetPosition) {
        this.targetPosition = targetPosition;
    }
}

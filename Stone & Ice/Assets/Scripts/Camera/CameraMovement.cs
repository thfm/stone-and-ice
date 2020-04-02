using UnityEngine;

public class CameraMovement : MonoBehaviour {
    private Vector3 targetPosition;

    void Start() {
        MoveTo(new Vector3(0, 2, 0));
    }

    void Update() {
        transform.position = Vector3.Lerp(
            transform.position,
            targetPosition,
            Time.deltaTime * 5
        );
    }

    public void MoveTo(Vector3 targetPosition) {
        this.targetPosition = targetPosition;
    }
}

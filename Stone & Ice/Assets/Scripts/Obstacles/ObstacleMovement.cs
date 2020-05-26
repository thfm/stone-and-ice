using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public Vector3 motionOffset;
    public float speed;

    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    void FixedUpdate()
    {
        transform.position = Vector3.Slerp(
            initialPosition,
            initialPosition + motionOffset,
            Mathf.PingPong(Time.timeSinceLevelLoad * speed, 1)
        );
    }
}

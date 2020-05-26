using UnityEngine;

public class CharacterCollision : MonoBehaviour
{
    [HideInInspector] public bool dieOnObstacleCollision = true;

    private CharacterMovement movement;

    void Start()
    {
        movement = GetComponent<CharacterMovement>();
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Obstacle" && dieOnObstacleCollision)
        {
            GetComponent<CharacterData>().isDead = true;
        }
        else
        {
            movement.sliding = (other.gameObject.tag == "IceFloor");
        }
    }
}

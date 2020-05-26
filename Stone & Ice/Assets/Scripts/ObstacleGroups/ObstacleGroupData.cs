using UnityEngine;

public class ObstacleGroupData : MonoBehaviour
{
    public float CalculateLength()
    {
        Bounds bounds = new Bounds(transform.position, Vector3.zero);
        foreach (Renderer renderer in GetComponentsInChildren<Renderer>())
        {
            bounds.Encapsulate(renderer.bounds);
        }
        return bounds.size.z;
    }
}

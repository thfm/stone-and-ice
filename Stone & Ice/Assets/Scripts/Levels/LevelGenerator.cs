using UnityEngine;

public class LevelGenerator : MonoBehaviour {
    public Transform character;

    [Range(10, 100)] public float viewDistance;
    [Range(0, 25)] public float obstacleGap;

    private GameObject[] obstacleGroupPrefabs;
    private GameObject[] floorPrefabs;

    private float pointer;

    void Start() {
        obstacleGroupPrefabs = Resources.LoadAll<GameObject>
            ("Prefabs/ObstacleGroups");
        floorPrefabs = Resources.LoadAll<GameObject>("Prefabs/Floors");
        pointer = viewDistance;
        SpawnRandomFloor((viewDistance / 2), viewDistance);
    }

    void Update() {
        if(character.position.z + viewDistance > pointer) {
            GameObject spawnedObstacleGroup = SpawnRandomObstacleGroup(pointer);
            GameObject spawnedFloor = SpawnBoundingFloor(spawnedObstacleGroup);
            pointer += spawnedFloor.transform.localScale.z;
        }
    }

    private GameObject SpawnRandomObstacleGroup(float zPosition) {
        return Instantiate(
            SelectRandomPrefab(obstacleGroupPrefabs),
            new Vector3(0, 0, zPosition),
            Quaternion.identity,
            gameObject.transform
        );
    }

    private GameObject SpawnBoundingFloor(GameObject obstacleGroup) {
        float length = obstacleGroup.GetComponent<ObstacleGroupData>().
            CalculateLength() + obstacleGap;
        float zPosition = obstacleGroup.transform.position.z + (length / 2);
        return SpawnRandomFloor(zPosition, length);
    }

    private GameObject SpawnRandomFloor(float zPosition, float length) {
        GameObject spawnedFloor = Instantiate(
            SelectRandomPrefab(floorPrefabs),
            new Vector3(0, -1, zPosition),
            Quaternion.identity,
            gameObject.transform
        );

        Vector3 floorScale = spawnedFloor.transform.localScale;
        floorScale.z = length;
        spawnedFloor.transform.localScale = floorScale;

        return spawnedFloor;
    }

    private GameObject SelectRandomPrefab(GameObject[] prefabs) {
        return prefabs[Random.Range(0, prefabs.Length)];
    }
}

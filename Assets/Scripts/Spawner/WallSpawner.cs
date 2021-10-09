using UnityEngine;

public class WallSpawner : Spawner
{
    [Header("Wall")]
    [SerializeField] private int _wallSpawnChance;
    [SerializeField] private Wall _wallTamplate;

    private WallSpawnPoint[] _wallSpawnPoints;

    private void Start()
    {
        _wallSpawnPoints = GetComponentsInChildren<WallSpawnPoint>();
        
        FindContainer();
        ResetSpawner();

        for (int i = 0; i <= RepeatCount; i++)
        {
            GenerateRandomElements(_wallSpawnPoints, _wallTamplate.gameObject, _wallSpawnChance, _distanceBetweenFullLine, _distanceBetweenFullLine);
            MoveSpawner(_distanceBetweenFullLine);

            GenerateRandomElements(_wallSpawnPoints, _wallTamplate.gameObject, _wallSpawnChance, _distanceBetweenFullLine, _distanceBetweenFullLine);
            MoveSpawner(_distanceBetweenFullLine);

            ResetSpawner(i);
        }
    }
}

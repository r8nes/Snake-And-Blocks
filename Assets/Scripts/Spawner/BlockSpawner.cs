using UnityEngine;

public class BlockSpawner : Spawner
{
    [Header("Block")]
    [SerializeField] private int _blockSpawnChance;
    [SerializeField] private Block _blockTamplate;

    private BlockSpawnPoint[] _blockSpawnPoints;

    private void Start()
    {
        FindContainer();
        _blockSpawnPoints = GetComponentsInChildren<BlockSpawnPoint>();

        for (int i = 0; i < RepeatCount; i++)
        {
            GenerateFullLine(_blockSpawnPoints, _blockTamplate.gameObject);
            MoveSpawner(_distanceBetweenFullLine);

            GenerateRandomElements(_blockSpawnPoints, _blockTamplate.gameObject, _blockSpawnChance);
            MoveSpawner(_distanceBetweenRandomLine);

            ResetSpawner(i);
        }
    }
}
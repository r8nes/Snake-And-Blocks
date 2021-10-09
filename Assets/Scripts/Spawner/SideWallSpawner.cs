using UnityEngine;

public class SideWallSpawner : Spawner
{
    [Header("SideWall")]
    [SerializeField] private int _sideWallSpawnChance;
    [SerializeField] private Wall _sideWallTamplate;

     private SideWallPoint[] _sideWallSpawnPoints;

    private void Start()
    {
        FindContainer();
      _sideWallSpawnPoints = GetComponentsInChildren<SideWallPoint>();

        for (int i = 0; i < RepeatCount; i++)
        {
            GenerateFullLine(_sideWallSpawnPoints, _sideWallTamplate.gameObject);
            MoveSpawner(_distanceBetweenFullLine);

            ResetSpawner(i);
        }
    }
}

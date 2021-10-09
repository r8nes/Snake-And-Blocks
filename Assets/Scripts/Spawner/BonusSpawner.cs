using UnityEngine;

public class BonusSpawner : Spawner
{
    [Header("Bonus")]
    [SerializeField] private int _bonusSpawnChance;
    [SerializeField] private Bonus _bonusTamplate;

    private BonusSpawnPoint[] _bonusSpawnPoints;

    private void Start()
    {
        FindContainer();
        _bonusSpawnPoints = GetComponentsInChildren<BonusSpawnPoint>();
        for (int i = 0; i < RepeatCount; i++)
        {
            GenerateRandomElements(_bonusSpawnPoints, _bonusTamplate.gameObject, _bonusSpawnChance, _bonusTamplate.gameObject.transform.localScale.y);
            MoveSpawner(_distanceBetweenRandomLine); 
            
            GenerateRandomElements(_bonusSpawnPoints, _bonusTamplate.gameObject, _bonusSpawnChance, _bonusTamplate.gameObject.transform.localScale.y);
            MoveSpawner(_distanceBetweenRandomLine);

            ResetSpawner(i);
        }
    }
}

using UnityEngine;

public class Spawner : MonoBehaviour
{

    [Header("General")]
    private Transform _container;

    [SerializeField] private protected int _distanceBetweenFullLine;
    [SerializeField] private protected int _distanceBetweenRandomLine;
    [SerializeField] private int repeatCount = 5;

    [SerializeField] protected int RepeatCount 
    { 
        get => repeatCount; 
        set => repeatCount = value;
    }

    private protected void GenerateFullLine(SpawnPoint[] spawnPoint, GameObject generatedElement)
    {
        for (int i = 0; i < spawnPoint.Length; i++)
        {
            GenerateElement(spawnPoint[i].transform.position, generatedElement);
        }
    }

    private protected void GenerateRandomElements(SpawnPoint[] spawnPoints, GameObject generatedElement, int spawnChance, float scaleY = 1f, float offsetY = 0)
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (Random.Range(0, 100) < spawnChance)
            {
                GameObject element = GenerateElement(spawnPoints[i].transform.position, generatedElement, offsetY);
                element.transform.localScale = new Vector3(element.transform.localScale.x, scaleY, element.transform.localScale.z);
            }
        }
    }

    private GameObject GenerateElement(Vector3 spawnPoint, GameObject generatedElement, float offsetY = 0)
    {
        spawnPoint.y -= offsetY;
        return Instantiate(generatedElement, spawnPoint, Quaternion.identity, _container.transform);
    }

    private protected void MoveSpawner(int distanceY)
    {
        _container.position = new Vector3(_container.position.x, _container.position.y + distanceY, _container.position.z);
    }

    private protected void ResetSpawner(int currentRepeatCount)
    {
        if (currentRepeatCount == RepeatCount)
        {
            _container.position = Vector3.zero;
        }
    }
    private protected void ResetSpawner()
    {
        _container.position = Vector3.zero;
    }

    private protected void FindContainer()
    {
        if (_container == null)
        {
            _container = GameObject.FindGameObjectWithTag("Box").transform;
        }
    }
}
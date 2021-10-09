using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(TailGenerator))]
[RequireComponent(typeof(SnakeInput))]
public class Snake : MonoBehaviour
{
    private List<Segment> _tail;
    private TailGenerator _tailGenerator;
    private SnakeInput _input;

    [SerializeField] private float _speed;
    [SerializeField] private float _tailSpringness;
    [SerializeField] private int _tailSize;

    [SerializeField] private SnakeHead _head;

    public event UnityAction<int> SizeUpdated;
    public event UnityAction OnEnded;

    private void Awake()
    {
        _tailGenerator = GetComponent<TailGenerator>();
        _input = GetComponent<SnakeInput>();
        _tail = _tailGenerator.Generate(_tailSize);
    }

    private void Start()
    {
        SizeUpdated?.Invoke(_tail.Count);
    }
    private void FixedUpdate()
    {
        Move(_head.transform.position + _head.transform.up * _speed*Time.fixedDeltaTime);
        _head.transform.up = _input.GetDirectionToClick(_head.transform.position);
    }

    private void Move(Vector3 nextPosition) 
    {
        Vector3 previousPoint = _head.transform.position;

        foreach (var segment in _tail)
        {
            Vector3 tempPosition = segment.transform.position;
            segment.transform.position = Vector2.Lerp(segment.transform.position, previousPoint, _tailSpringness * Time.deltaTime);
            previousPoint = tempPosition;
        }
        _head.Move(nextPosition);
    }
      
    private void OnEnable()
    {
        _head.BlockCollided += OnBlockCollided;
        _head.BonusCollected += OnBonusCollected;

    }
    private void OnDisable()
    {
        _head.BlockCollided -= OnBlockCollided;
        _head.BonusCollected -= OnBonusCollected;
    }

    private void OnBlockCollided()
    {

        Segment deletedSegment = _tail[_tail.Count - 1];
        _tail.Remove(deletedSegment);
        Destroy(deletedSegment.gameObject);

        if (_tail.Count == 0)
        {          
            OnEnded?.Invoke();
            GameOver.ReloadScene();
        }

        SizeUpdated?.Invoke(_tail.Count);
    }

    private void OnBonusCollected(int bonusSize)
    {
      _tail.AddRange( _tailGenerator.Generate(bonusSize));
        SizeUpdated?.Invoke(_tail.Count);
    }
}

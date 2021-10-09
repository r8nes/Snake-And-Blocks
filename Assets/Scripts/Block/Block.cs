using UnityEngine;
using UnityEngine.Events;

public class Block : MonoBehaviour
{
    private int _destroyPrice;
    private int _filling;
    private SpriteRenderer _spriteRenderer;

    [SerializeField] private Vector2Int _destroyPriceRange;
    [SerializeField] private Color[] _colors;

    public int LeftToFill => _destroyPrice - _filling;

    public event UnityAction<int> FillingUpdated;
    
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        SetColor(_colors[Random.Range(0, _colors.Length)]);

        _destroyPrice = Random.Range(_destroyPriceRange.x, _destroyPriceRange.y);
        FillingUpdated?.Invoke(LeftToFill);
    }

    public void Fill() 
    {
        _filling++;
        FillingUpdated?.Invoke(LeftToFill);
        if (_filling == _destroyPrice)
        {
            Destroy(gameObject);
        }
    }

    private void SetColor(Color color) 
    {
        _spriteRenderer.color = color;
    }
}

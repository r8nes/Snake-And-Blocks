using UnityEngine;

public class SnakeTracker : MonoBehaviour
{
    [SerializeField] private SnakeHead _snake;
    [SerializeField] private float _snakeSpeed;
    [SerializeField] private float _offsetY;

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, GetTargetPosition(), _snakeSpeed * Time.fixedDeltaTime);
    }

    private Vector3 GetTargetPosition() {
        return new Vector3(transform.position.x, _snake.transform.position.y + _offsetY, transform.position.z);
    }
}

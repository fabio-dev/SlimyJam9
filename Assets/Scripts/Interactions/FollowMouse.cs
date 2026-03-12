using UnityEngine;
using UnityEngine.InputSystem;

public class FollowMouse : MonoBehaviour
{
    [SerializeField] private float _xLimit;
    [SerializeField] private float _yLimit;

    public float followSpeed = 10f;

    void Update()
    {
        Vector2 mouseScreenPosition = Mouse.current.position.ReadValue();
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
        mouseWorldPosition.x = Mathf.Clamp(mouseWorldPosition.x, -_xLimit, _xLimit);
        mouseWorldPosition.y = Mathf.Clamp(mouseWorldPosition.y, -_yLimit, _yLimit);
        mouseWorldPosition.z = 0;

        transform.position = Vector3.Lerp(
            transform.position,
            mouseWorldPosition,
            followSpeed * Time.deltaTime
        );
    }
}
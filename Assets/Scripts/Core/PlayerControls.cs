using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] private GameObject m_ObjectWhichWillBeMoved;
    [SerializeField] private GameObject m_ObjectWhichWillBeRotated;
    [SerializeField] private float m_MovingSpeed = 1;
    [SerializeField] private float m_RotationSpeed = 1;

    private void Move(Vector3 direction, float speed)
    {
        m_ObjectWhichWillBeMoved.transform.Translate(direction * speed * Time.deltaTime);
    }
    private void MoveRight(float speed) => Move(Vector3.right, speed);
    private void MoveLeft(float speed) => Move(Vector3.left, speed);

    private void RotateRight(float rotationSpeed)
    {
        m_ObjectWhichWillBeRotated.transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
    private void RotateLeft(float rotationSpeed) => RotateRight(-rotationSpeed);

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch FirstTouch = Input.GetTouch(0);
            float ScreenWidth = Screen.width;
            float ScreenHeight = Screen.height;
            if (FirstTouch.position.y < ScreenHeight / 2)
            {
                if (FirstTouch.position.x < ScreenWidth / 2)
                {
                    MoveLeft(m_MovingSpeed);
                }
                else
                {
                    MoveRight(m_MovingSpeed);
                }
            }
            else
            {
                if (FirstTouch.position.x < ScreenWidth / 2)
                {
                    RotateLeft(m_RotationSpeed);
                }
                else
                {
                    RotateRight(m_RotationSpeed);
                }
            }
        }
    }
}
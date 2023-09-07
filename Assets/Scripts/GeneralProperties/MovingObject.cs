using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovingObject : MonoBehaviour
{
    [SerializeField] private float m_Speed = 10;
    [SerializeField] private float m_Acceleration = 1;

    private Rigidbody m_ThisRigidbody;
    private Vector3 m_Velocity;
    private float m_AccelerationPerFixedDeltaTime;

    private void Awake()
    {
        m_ThisRigidbody = GetComponent<Rigidbody>();
        m_AccelerationPerFixedDeltaTime = m_Acceleration * Time.fixedDeltaTime;
    }

    private void RecalculateAndSetVelocity()
    {
        m_Velocity = Vector3.forward * m_Speed;
        m_ThisRigidbody.velocity = m_Velocity;
    }

    private void Update()
    {
        RecalculateAndSetVelocity();
    }

    private void FixedUpdate()
    {
        m_Speed += m_AccelerationPerFixedDeltaTime;
    }
}
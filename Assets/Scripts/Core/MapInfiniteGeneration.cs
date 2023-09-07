using UnityEngine;
using System.Collections.Generic;

public class MapInfiniteGeneration : MonoBehaviour
{
    [SerializeField] private GameObject m_MovingObject;
    [SerializeField] private Axis m_AxisOfMovement;
    [SerializeField] private float m_IntervalBetweenObstacles = 100;
    [SerializeField] private GameObject m_Obstacle;
    [SerializeField] private List<Material> m_MaterialsForObstacles = new();
    [SerializeField] private GameObject m_FirstBorders;
    [SerializeField] private float m_BordersWidth;
    [SerializeField] private GameObject m_BordersParentObject;
    [SerializeField] private GameObject m_ObstaclesParentObject;
    [SerializeField] private float m_NeededDistanceFromTheMovingObjectForDeleting = 5;

    private float m_LastObstaclePosition;
    private float m_LastBordersPosition;
    private Vector3 m_StartingPosition;
    private int m_CurrentMaterialIndex = 0;
    private List<GameObject> m_SpawnedObjects = new();

    private void Awake()
    {
        m_StartingPosition = m_MovingObject.transform.position;
        m_LastBordersPosition = m_FirstBorders.transform.position.z;
        m_LastObstaclePosition = m_MovingObject.transform.position.z;
        AddNewObstacle();
    }

    private void FixedUpdate()
    {
        float CurrentPositionOfMovingObjectAlongAxisOfMovement = m_MovingObject.transform.position[(int)m_AxisOfMovement];
        if (CurrentPositionOfMovingObjectAlongAxisOfMovement - m_LastObstaclePosition > m_IntervalBetweenObstacles / 4f)
        {
            AddNewObstacle();
        }
        for(int i = m_SpawnedObjects.Count - 1; i >= 0; i--)
        {
            if(CurrentPositionOfMovingObjectAlongAxisOfMovement - m_NeededDistanceFromTheMovingObjectForDeleting > m_SpawnedObjects[i].transform.position[(int)m_AxisOfMovement])
            {
                Destroy(m_SpawnedObjects[i]);
                m_SpawnedObjects.RemoveAt(i);
            }
        }
    }

    private void AddNewObstacle()
    {
        m_LastObstaclePosition += m_IntervalBetweenObstacles;
        GameObject NewObstacle = InstantiateAndSetParentAndPosition(m_Obstacle, new Vector3(m_StartingPosition.x, m_StartingPosition.y, m_LastObstaclePosition), m_ObstaclesParentObject.transform);
        m_SpawnedObjects.Add(NewObstacle);
        foreach (Transform child in NewObstacle.transform)
        {
            child.GetComponent<Renderer>().material = m_MaterialsForObstacles[m_CurrentMaterialIndex];
        }
        m_CurrentMaterialIndex++;
        if(m_CurrentMaterialIndex >= m_MaterialsForObstacles.Count)
        {
            m_CurrentMaterialIndex = 0;
        }
        for(int i = 0; i < m_IntervalBetweenObstacles / m_BordersWidth; i++)
        {
            m_LastBordersPosition += m_BordersWidth;
            m_SpawnedObjects.Add(InstantiateAndSetParentAndPosition(m_FirstBorders, new Vector3(m_FirstBorders.transform.position.x, m_FirstBorders.transform.position.y, m_LastBordersPosition), m_BordersParentObject.transform));
        }
    }

    private GameObject InstantiateAndSetParentAndPosition(GameObject sample, Vector3 position, Transform parent)
    {
        GameObject NewGameObject = Instantiate(sample);
        NewGameObject.transform.position = position;
        NewGameObject.transform.parent = parent;
        return NewGameObject;
    }
}
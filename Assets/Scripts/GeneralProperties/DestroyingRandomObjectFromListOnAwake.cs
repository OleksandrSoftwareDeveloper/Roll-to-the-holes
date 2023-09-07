using System.Collections.Generic;
using UnityEngine;

public class DestroyingRandomObjectFromListOnAwake : MonoBehaviour
{
    [SerializeField] private List<GameObject> m_ListWithOneObjectToBeDestroyed = new();
    [SerializeField] private GameObject m_GameObjectForReplacingDestroyed;

    private void Awake()
    {
        DestroyAndRepaceRandomObjectFromTheList();
    }

    private void DestroyAndRepaceRandomObjectFromTheList()
    {
        int IndexOfTheObjectToBeDestroyed = new System.Random().Next(0, m_ListWithOneObjectToBeDestroyed.Count);
        Transform ParentOfDestroyedObject = m_ListWithOneObjectToBeDestroyed[IndexOfTheObjectToBeDestroyed].transform.parent;
        Vector3 PositionOfDestroyedObject = m_ListWithOneObjectToBeDestroyed[IndexOfTheObjectToBeDestroyed].transform.position;
        Destroy(m_ListWithOneObjectToBeDestroyed[IndexOfTheObjectToBeDestroyed]);

        if (m_GameObjectForReplacingDestroyed != null)
        {
            GameObject GameObjectWhichReplacesDestroyed = Instantiate(m_GameObjectForReplacingDestroyed);
            GameObjectWhichReplacesDestroyed.transform.parent = ParentOfDestroyedObject;
            GameObjectWhichReplacesDestroyed.transform.position = PositionOfDestroyedObject;
        }
    }
}
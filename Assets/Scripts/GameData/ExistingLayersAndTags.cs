using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ExistingLayersAndTags", menuName = "ScriptableObjects/GameData/ExistingLayersAndTags")]
public class ExistingLayersAndTags : ScriptableObject
{
    [SerializeField] private int m_PlayerLayer;
    public int PlayerLayer { get => m_PlayerLayer; }

    [SerializeField] private List<int> m_LayersWithObjectsDangerousForPlayer = new();
    public List<int> LayersWithObjectsDangerousForPlayer { get => m_LayersWithObjectsDangerousForPlayer; }
}
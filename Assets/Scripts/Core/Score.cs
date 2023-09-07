using System.Collections.Generic;
using UnityEngine;

public enum Axis
{
    X = 0,
    Y = 1,
    Z = 2
}

public class Score : MonoBehaviour
{
    [SerializeField] private GameObject m_GameObjectWhichOvercomeDistanceMeansScore;
    [SerializeField] private List<Axis> m_AxisOnWhichDistanceIsCounted = new();

    private Vector3 m_StartingPositionOfGameObjectWhichOvercomeDistanceMeansScore;

    public int CurrentScore { get; private set; } = 0;

    private List<T> DeleteRepeats<T>(List<T> inputList)
    {
        List<T> UniqueList = new();
        HashSet<T> SeenElements = new();
        foreach (T oneItem in inputList)
        {
            if (!SeenElements.Contains(oneItem))
            {
                SeenElements.Add(oneItem);
                UniqueList.Add(oneItem);
            }
        }
        return UniqueList;
    }

    private void Awake()
    {
        m_AxisOnWhichDistanceIsCounted = DeleteRepeats(m_AxisOnWhichDistanceIsCounted);
        m_StartingPositionOfGameObjectWhichOvercomeDistanceMeansScore = m_GameObjectWhichOvercomeDistanceMeansScore.transform.position;
    }

    private void RecalculateScore()
    {
        Vector3 DeltaPositionOfGameObjectWhichOvercomeDistanceMeansScore = m_GameObjectWhichOvercomeDistanceMeansScore.transform.position - m_StartingPositionOfGameObjectWhichOvercomeDistanceMeansScore;
        float RecalculatedScore = 0;
        foreach(Axis oneAxis in m_AxisOnWhichDistanceIsCounted)
        {
            RecalculatedScore += Mathf.Pow(DeltaPositionOfGameObjectWhichOvercomeDistanceMeansScore[(int)oneAxis], 2);
        }
        RecalculatedScore = Mathf.Sqrt(RecalculatedScore);
        CurrentScore = Mathf.RoundToInt(RecalculatedScore);
    }

    private void FixedUpdate()
    {
        RecalculateScore();
    }
}
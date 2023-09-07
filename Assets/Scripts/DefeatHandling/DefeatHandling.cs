using System.Collections.Generic;
using UnityEngine;

public class DefeatHandling : MonoBehaviour
{
    [SerializeField] private List<GameObject> m_GameObjectsWhichShouldBeEnabledOnDefeat = new();
    [SerializeField] private List<GameObject> m_GameObjectsWhichShouldBeDisabledOnDefeat = new();

    private void Awake()
    {
        Time.timeScale = 1;
    }

    private void StopGame()
    {
        Time.timeScale = 0;
    }

    private void Lose()
    {
        StopGame();
        m_GameObjectsWhichShouldBeEnabledOnDefeat.ForEach(gameObject => gameObject.SetActive(true));
        m_GameObjectsWhichShouldBeDisabledOnDefeat.ForEach(gameObject => gameObject.SetActive(false));
    }

    private void OnEnable()
    {
        GameEvents.OnLose += Lose;
    }

    private void OnDestroy()
    {
        GameEvents.OnLose -= Lose;
    }
}
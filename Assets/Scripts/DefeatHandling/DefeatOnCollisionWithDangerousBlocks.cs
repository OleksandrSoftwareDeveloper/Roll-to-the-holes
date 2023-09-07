using UnityEngine;

[RequireComponent(typeof(Collider))]
public class DefeatOnCollisionWithDangerousBlocks : MonoBehaviour
{
    [SerializeField] private ExistingLayersAndTags m_ExistingLayersAndTags;

    private void OnCollisionEnter(Collision collision)
    {
        if(m_ExistingLayersAndTags.LayersWithObjectsDangerousForPlayer.Contains(collision.collider.gameObject.layer))
        {
            GameEvents.OnLose?.Invoke();
        }
    }
}
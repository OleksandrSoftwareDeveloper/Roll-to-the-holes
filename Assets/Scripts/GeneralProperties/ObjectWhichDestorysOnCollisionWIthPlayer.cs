using UnityEngine;

public class ObjectWhichDestorysOnCollisionWIthPlayer : MonoBehaviour
{
    [SerializeField] private ExistingLayersAndTags m_ExistingLayersAndTags;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.layer == m_ExistingLayersAndTags.PlayerLayer)
        {
            Destroy(gameObject);
        }
    }
}
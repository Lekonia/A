using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    
    public void AttachToPlayer()
    {
        transform.parent = playerTransform;
    }

    public void DettachToPlayer()
    {
        transform.parent = null;
    }
}

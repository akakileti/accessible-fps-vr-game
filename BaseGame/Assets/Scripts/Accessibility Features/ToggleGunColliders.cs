using UnityEngine;

public class ToggleGunColliders : MonoBehaviour
{
    public BoxCollider[] boxColliders;

    public void ToggleCollidersEnabled()
    {
        foreach(BoxCollider boxCollider in boxColliders)
        {
            boxCollider.enabled = !boxCollider.enabled;
        }
    }
}

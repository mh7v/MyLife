using UnityEngine;
using System.Collections;

public class AffectChildCollidersTrigger : MonoBehaviour
{
    [SerializeField]
    private float timeToAffect;

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent != null)
        {
            if (other.transform.parent.tag == "Player")
                DeactivateChildren(other.transform.parent);
        }
    }

    void DeactivateChildren(Transform parent)
    {
        SphereCollider[] childColliders = parent.GetComponentsInChildren<SphereCollider>();
        for (int i = 0; i < childColliders.Length; i++)
        {
            childColliders[i].enabled = false;
        }
        StartCoroutine(ActivateChildrenAfterTime(timeToAffect, childColliders));
    }

    private IEnumerator ActivateChildrenAfterTime(float time, SphereCollider[] childColliders)
    {
        yield return new WaitForSeconds(time);
        for (int i = 0; i < childColliders.Length; i++)
        {
            childColliders[i].enabled = true;
        }
    }
}
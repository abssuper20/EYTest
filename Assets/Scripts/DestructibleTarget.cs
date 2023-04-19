using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleTarget : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        transform.GetComponentInParent<Target>().DisableTarget();
        ScoreManager.instance.IncrementScore();
    }
}

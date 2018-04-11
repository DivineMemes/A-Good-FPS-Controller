using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointToNearestTransform : MonoBehaviour
{
    public Transform[] targets;


    void Update()
    {
        try
        {
            GetHeadingForNearestTarget(targets);
        }
        catch (System.ArgumentNullException e)
        {
            Debug.LogError("failed to find new heading");
        }
    }


    Vector3 GetHeadingForNearestTarget(Transform[] potentialTargets)
    {
        if (potentialTargets == null) { throw new System.ArgumentNullException("PotentialTargets"); }
        if (potentialTargets.Length == 0) { throw new System.ArgumentException("Need at least one target first"); }
        Transform nearestTransform = potentialTargets[0];
        float distance = Vector3.Distance(transform.position, potentialTargets[0].transform.position);

        for (int i = 0; i < potentialTargets.Length; ++i)
        {
            float tempDist = Vector3.Distance(transform.position, potentialTargets[i].transform.position);
            if (tempDist < distance)
            {
                distance = tempDist;
                nearestTransform = potentialTargets[i];
            }
        }
        return (nearestTransform.position - transform.position).normalized;
    }
}
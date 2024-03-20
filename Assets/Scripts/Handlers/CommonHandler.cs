using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CommonHandler 
{
    public static T Find<T>(List<T> targets, Transform owner, float radius)
        where T: MonoBehaviour
    {
        float minDistance = float.PositiveInfinity;
        T target = null;

        targets.ForEach(enemy =>
        {
            float distance = Vector3.Distance(owner.position, enemy.transform.position);

            if (distance <= radius)
            {
                if (distance < minDistance)
                {
                    target = enemy;
                    minDistance = distance;
                }
            }
        });
        return target;
    }
}

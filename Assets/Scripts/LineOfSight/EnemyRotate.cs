using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotate : MonoBehaviour {

    public float rotateSpeed = 0.1f;

    PathableObject pathable;

    private void Start()
    {
        pathable = GetComponentInParent<PathableObject>();
    }

    public void RotateTowards(Vector2 pos)
    {
        //either look at a provided location or your next target

        Vector3 diff = pos - new Vector2(transform.position.x, transform.position.y);
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        StartCoroutine(RotateTowardsCoroutine(Quaternion.Euler(0f, 0f, rot_z - 90)));
    }

    IEnumerator RotateTowardsCoroutine(Quaternion target)
    {

        while (Quaternion.Angle(transform.rotation, target) > 0.1f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, target, rotateSpeed);

            yield return null;
        }
    }
}

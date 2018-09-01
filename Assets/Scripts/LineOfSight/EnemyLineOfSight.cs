using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class EnemyLineOfSight : MonoBehaviour {

    public float range = 1f;
    [Range(0f, 90f)]
    public float angle = 45f;
    public float samplesPerDegree = 1f;

    private LineRenderer lineRenderer;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {

        DrawLineOfSight();
    }

    void DrawLineOfSight()
    {
        List<Vector2> lineOfSightPoints = LOSPoints();
        lineRenderer.positionCount = lineOfSightPoints.Count + 1;

        lineRenderer.SetPosition(0, transform.position);

        for (int i = 0; i < lineOfSightPoints.Count; i++)
        {
            lineRenderer.SetPosition(i + 1, lineOfSightPoints[i]);
        }
    }

    List<Vector2> LOSPoints()
    {
        List<Vector2> points = new List<Vector2>();

        Vector2 center = transform.position;

        float totalSamples = samplesPerDegree * angle;
        for (int i = 0; i < totalSamples; i++)
        {
            float rad = Mathf.Deg2Rad * (i / totalSamples) * angle - Mathf.Deg2Rad * angle / 2;

            RaycastHit2D hitInfo = Physics2D.Raycast(center, (transform.right * Mathf.Sin(rad) * range) + (transform.up * Mathf.Cos(rad) * range), range);

            if(hitInfo.collider != null)
            {
                points.Add(hitInfo.point);

                if(hitInfo.collider.GetComponent<Player>() != null)
                {
                    Debug.Log("I can see the player!!!");
                    //hitInfo.collider.GetComponent<Player>()
                }

            } else {
                points.Add(transform.position + (transform.right * Mathf.Sin(rad) * range) + (transform.up * Mathf.Cos(rad) * range));
            }
        }

        return points;
    }
}

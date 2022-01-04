using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private float maxDistance = 8;
    [SerializeField] private int maxReflections = 8;
    [SerializeField] private LineRenderer beam;
    [SerializeField] private LayerMask mirrors;

    private Ray2D ray;
    private RaycastHit2D hit;

    // Update is called once per frame
    void Update()
    {
        ray = new Ray2D(transform.position, transform.right);

        beam.positionCount = 1;
        beam.SetPosition(0, transform.position);

        float remainingDistance = maxDistance;

        for (int i = 0; i < maxReflections; i++)
        {
            hit = Physics2D.Raycast(ray.origin, ray.direction, remainingDistance, mirrors.value);
            beam.positionCount++;

            if (hit)
            {
                beam.SetPosition(beam.positionCount - 1, hit.point);
                remainingDistance -= Vector2.Distance(ray.origin, hit.point);
                ray = new Ray2D(hit.point - (Vector2)ray.direction * 0.01f, Vector2.Reflect(ray.direction, hit.normal));
            }
            else
            {
                beam.SetPosition(beam.positionCount - 1, ray.origin + ray.direction * remainingDistance);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class MultipleTargetCamera : MonoBehaviour
{
    public List<Transform> targets;

    public Vector3 offset;
    public float smoothTime = .4f;
    public float closestZoom;
    public float furthestZoom;
    public float zoomFactor;

    private Vector3 velocity;
    private Camera cam;
    private BoxCollider2D col;

    private void Start()
    {
        cam = GetComponent<Camera>();
        col = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (targets[1] == null || targets[0] == null)
            gameObject.GetComponent<MultipleTargetCamera>().enabled = false;
    }

    private void LateUpdate()
    {
        if (targets[1] == null || targets[0] == null)
            return;
        else
        {
            Move();
            Zoom();
        }
    }

    void Move()
    {
        Vector3 centerPoint = GetCenterPoint();

        Vector3 newPosition = centerPoint + offset;

        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
    }

    void Zoom()
    {
        cam.orthographicSize = Mathf.Lerp(closestZoom, furthestZoom, GetGreatestDistance() / zoomFactor);
    }

    Vector3 GetCenterPoint()
    {
        if (targets.Count <= 1)
            return targets[0].position;
        else
        {
            var bounds = new Bounds(targets[0].position, Vector3.zero);
            for (int i = 0; i < targets.Count; i++)
                bounds.Encapsulate(targets[i].position);
            return bounds.center;
        }

    }

    float GetGreatestDistance()
    {
        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
            bounds.Encapsulate(targets[i].position);

        return Mathf.Max(bounds.size.x, bounds.size.y);
    }
}

﻿using UnityEngine;

public class CameraRayCaster : MonoBehaviour
{
    public float distance = 2f;
    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, distance))
        {
            hit.collider.GetComponent<IWatcher>()?.OnWatch();
            if (Input.GetMouseButtonDown(0))
            {
                hit.collider.GetComponent<IHitter>()?.OnHit(hit);
            }
        }
        
    }
}

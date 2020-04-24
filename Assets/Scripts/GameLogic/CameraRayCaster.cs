﻿using Interfaces;
 using UnityEngine;

 namespace GameLogic
 {
     public class CameraRayCaster : MonoBehaviour
     {
         public float distance = 2f;
         private Camera _cam;

         private void Start()
         {
             _cam = GetComponent<Camera>();
         }

         private void Update()
         {
             var ray = _cam.ScreenPointToRay(Input.mousePosition);
             if (Physics.Raycast(ray, out var hit, distance))
             {
                 hit.collider.GetComponent<IWatcher>()?.OnWatch();
                 if (Input.GetMouseButtonDown(0))
                 {
                     hit.collider.GetComponent<IHitter>()?.OnHit(hit);
                 }
             }
        
         }
     }
 }

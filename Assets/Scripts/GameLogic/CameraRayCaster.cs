 using UnityEngine;

 namespace GameLogic
 {
     public class CameraRayCaster : MonoBehaviour
     {
         public float distance = 2f;
         private Camera _cam;

         [SerializeField] private GameManager manager;
         
         private void Start()
         {
             _cam = GetComponent<Camera>();
         }

         private void Update()
         {
             
             var ray = _cam.ScreenPointToRay(Input.mousePosition);
             
             if (Physics.Raycast(ray, out var hit, distance))
             {
                 if(!manager.SceneObjects.ContainsKey(hit.collider.gameObject))
                     return;
                 
                 manager.SceneObjects[hit.collider.gameObject].OnViewed();
                 
                 if (Input.GetMouseButtonDown(0))
                     manager.SceneObjects[hit.collider.gameObject].OnClicked(hit);
             }
        
         }
     }
 }

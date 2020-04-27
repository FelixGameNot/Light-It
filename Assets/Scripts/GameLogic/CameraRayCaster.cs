 using Info;
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
                 if(!manager.sceneObjects.ContainsKey(hit.collider.gameObject))
                     return;
                 
                 var hitObj = manager.sceneObjects[hit.collider.gameObject];
                 
                 hitObj.OnViewed();
                 
                 if (Input.GetMouseButtonDown(0))
                     hitObj.OnStartHandling(hit);
                 if (Input.GetMouseButton(0))
                     hitObj.OnHandling(hit);
                 if (Input.GetMouseButtonUp(0)) 
                 {
                     hitObj.OnEndHandling(hit);
                     hitObj.OnClicked(hit);
                 }

                 if (Input.GetKeyDown(KeyCode.D))
                     manager.sceneObjects[hit.collider.gameObject].Remove();

                 if (Input.GetKey(KeyCode.C))
                 {
                     if (Input.GetKeyDown(KeyCode.L))
                         manager.SpawnObject(hit, Type.LAMP);
                     if (Input.GetKeyDown(KeyCode.B))
                         manager.SpawnObject(hit, Type.BOX);
                     if (Input.GetKeyDown(KeyCode.T))
                         manager.SpawnObject(hit, Type.TANK);
                 }

             }
        
         }
     }
 }

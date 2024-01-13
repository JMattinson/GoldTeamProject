using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraFollowBehavior : MonoBehaviour
{
   public List<Transform> targets;

   public Vector3 offset;
   private Vector3 centerPoint;
   private Vector3 velocity;

   private Camera cam;
   
   public float smoothTime = 0.5f;
   

   public float minZoom = 40f;
   public float maxZoom = 10f;
   public float zoomLimit = 50f;


   private void Start()
   {
      cam = GetComponent<Camera>();
   }

   private void LateUpdate()
   {
      if (targets.Count == 0)
         return;
      CameraAdjust();
      CameraZoom();
   }

   void CameraAdjust()
   {
      centerPoint = GetCenterPoint();

      Vector3 newPosition = centerPoint + offset;

      transform.position = Vector3.SmoothDamp(transform.position,newPosition,ref velocity, smoothTime);
   }

   void CameraZoom()
   {
      float newZoom = Mathf.Lerp(maxZoom, minZoom, GetGreatestDistance() / zoomLimit);
      cam.fieldOfView = Mathf.Lerp(cam.fieldOfView,newZoom,Time.deltaTime);
   }


   float GetGreatestDistance()
   {
      var bounds = new Bounds(targets[0].position, Vector3.zero);
      
      for (int i = 0; i < targets.Count; i++)
      {
         bounds.Encapsulate(targets[i].position);
      }

      return bounds.size.x;
   }
   
   Vector3 GetCenterPoint()
   {
      if (targets.Count == 1)
      {
         return targets[0].position;
      }

      var bounds = new Bounds(targets[0].position, Vector3.zero);
      for (int i = 0; i < targets.Count; i++)
      {
         bounds.Encapsulate(targets[i].position);
      }

      return bounds.center;
   }
}

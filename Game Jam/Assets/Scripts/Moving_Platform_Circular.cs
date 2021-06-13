using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_Platform_Circular : MonoBehaviour
{
     public float speed = 2f;
     public Transform target;
     
     private Vector3 zAxis = new Vector3(0, 0, 1);
 
     void FixedUpdate () {
         transform.RotateAround(target.position, zAxis, speed); 
     }
}

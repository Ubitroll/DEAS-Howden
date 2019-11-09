using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CameraMovement
{
    public static void Rotate(Camera camera, Transform target, float speed)
    {
        camera.transform.RotateAround(target.position, new Vector3(0.0f, 1.0f, 0.0f), 20 * Time.deltaTime * speed);
    }

    

    
   

}

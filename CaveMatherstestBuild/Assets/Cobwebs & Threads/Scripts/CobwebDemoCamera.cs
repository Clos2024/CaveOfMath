using UnityEngine;
using System.Collections;

public class CobwebDemoCamera : MonoBehaviour
{
    public Transform target = null;
	public bool autoRotate = true;
    public float targetHeight = 0f;
    public float distance = 3f;
    public float maxDistance = 10f;
    public float minDistance = 0.5f;
    public float xSpeed = 125f;
    public float ySpeed = 125f;
    //public float yMinLimit = -40f;
    //public float yMaxLimit = 80f;
    public float zoomRate = 20f;
    public float rotationDampening = 3.0f;
	float x = 0.0f;
    float y = 0.0f;
	
	void Start ()
	{
		Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;
    }
     
    void LateUpdate ()
	{
		if(!target) return;
        
		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");
		
		if( (inputX<0 || inputX>0) || (inputY<0 || inputY>0) )
		{
			x += inputX * xSpeed * 0.02f;
			y -= inputY * ySpeed * 0.02f;
			
			autoRotate = false;
		}
		
		distance -= (Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime) * zoomRate * Mathf.Abs(distance);
		distance = Mathf.Clamp(distance, minDistance, maxDistance);
       
		//y = ClampAngle(y, yMinLimit, yMaxLimit);
       
		// ROTATE CAMERA:
		if(autoRotate)
		{
			x += 0.5f;
			//y += 0.3f;
		}

		Quaternion rotation = Quaternion.Euler(y, x, 0);		
		transform.rotation = rotation;
       
		// POSITION CAMERA:
		Vector3 position = target.position - (rotation * Vector3.forward * distance + new Vector3(0, -targetHeight, 0));
		transform.position = position;
    }
     
    float ClampAngle(float angle, float min, float max)
	{
		if (angle < -360)
			angle += 360;

		if (angle > 360)
			angle -= 360;
		
		return Mathf.Clamp (angle, min, max);
    }
}

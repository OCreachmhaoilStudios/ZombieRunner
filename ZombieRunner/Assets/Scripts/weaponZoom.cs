using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponZoom : MonoBehaviour
{
	[SerializeField] Camera fpsCamera;
	[SerializeField] float zoomedOutFOV = 60f;
	[SerializeField] float zoomedInFOV = 20f;
	
	bool isZoomed = false;
	
    // Update is called once per frame
    private void Update()
    {
		if(Input.GetMouseButtonDown(1))
		{
			isZoomed = !isZoomed;
			if(isZoomed == true)
			{
				fpsCamera.fieldOfView = zoomedInFOV;
			}
			else
			{
				fpsCamera.fieldOfView = zoomedOutFOV;
			}
		}
    }
}

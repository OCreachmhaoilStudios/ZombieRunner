using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
	[SerializeField] Camera fpsCamera;
	[SerializeField] float zoomedOutFOV = 60f;
	[SerializeField] float zoomedOutSensitivity = 2f;
	[SerializeField] float zoomedInFOV = 20f;
	[SerializeField] float zoomedInSensitivity = 1f;
		
	RigidbodyFirstPersonController fpsController;
	
	bool isZoomed = false;
	private void Start()
	{
		fpsController = GetComponentInParent<RigidbodyFirstPersonController>();
	}
	
    // Update is called once per frame
    private void Update()
    {
		if(Input.GetMouseButtonDown(1))
		{
			isZoomed = !isZoomed;
			if(isZoomed == true)
			{
				fpsCamera.fieldOfView = zoomedInFOV;
				fpsController.mouseLook.XSensitivity = zoomedInSensitivity;
				fpsController.mouseLook.YSensitivity = zoomedInSensitivity;
			}
			else
			{
				fpsCamera.fieldOfView = zoomedOutFOV;
				fpsController.mouseLook.XSensitivity = zoomedOutSensitivity;
				fpsController.mouseLook.YSensitivity = zoomedOutSensitivity;
			}
		}
    }
}

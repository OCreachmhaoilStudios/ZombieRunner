using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	
	[SerializeField] Camera FPCamera;
	[SerializeField] float range = 100f;
	[SerializeField] float damage = 20f;
	[SerializeField] ParticleSystem muzzleFlash;
	[SerializeField] GameObject hitEffect;
	[SerializeField] Ammo ammoSlot;
	[SerializeField] float timeBetweenShots = 0.5f;
	
	bool canShoot = true;
	
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && canShoot == true)
        {
		   StartCoroutine(Shoot());
	   }
    }
    
    IEnumerator Shoot()
    {
	    canShoot = false;
	    if(ammoSlot.GetAmmoCount() >= 1)
	    {
		    ammoSlot.ReduceCurrentAmmo();
		    PlayMuzzleFlash();
		    ProcessRaycast();		    
	    }
	    
	    yield return new WaitForSeconds(timeBetweenShots);
	    canShoot = true;
    }
    
    private void ProcessRaycast()
    {
	    RaycastHit hit;
	    if(Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
	    {
		    CreateHitImpact(hit);
		    EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
		    if(target == null) { return; }
		    target.TakeDamage(damage);
	    }
	    else
	    {
		    return;
	    }
    }
    
    private void PlayMuzzleFlash()
    {
	    muzzleFlash.Play();
    }
    
    private void CreateHitImpact(RaycastHit hit)
    {
	    GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
		Destroy(impact, .1f);
    }
}

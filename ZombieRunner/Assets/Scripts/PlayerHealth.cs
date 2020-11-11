using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
	[SerializeField] float maxHealth = 100f;
	
	public void TakeDamage(float damage)
	{
		/*
		this.maxHealth -= damage;
		if(this.maxHealth <= 0)
		{
			Debug.Log("Player has died.");
		}
		*/
		if(this.maxHealth <= 0) { GetComponent<DeathHandler>().HandleDeath(); }
		this.maxHealth = (this.maxHealth -= damage) >= 0 ? this.maxHealth - damage : 0;

		return;
	}
	
    // Start is called before the first frame update
    void Start()
    {
        
    }
}

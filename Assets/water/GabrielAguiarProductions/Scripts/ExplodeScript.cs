using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeScript : MonoBehaviour {
    
	public float minForce;
	public float maxForce;
	public float radius;
	public float rescaleDelay;
	public float rescaleAmount;
	public float rescaleMultiplier;

	private WaitForSeconds _smallDelay = new WaitForSeconds (0.01f);

	public void Explode () {
		foreach (Transform t in transform){
			var rb = t.GetComponent<Rigidbody> ();

			if (rb != null)
            {
				rb.AddExplosionForce (Random.Range(minForce, maxForce), transform.position, radius);
			}
		}
	}
}

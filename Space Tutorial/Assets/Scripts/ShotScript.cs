using UnityEngine;
using System.Collections;

public class ShotScript : MonoBehaviour {

	public int damage = 1;

	public bool isEnemyShot = false;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, 20);
	}

	//void OnTriggerEnter2D(Collider2D otherCollider)
	void OnTriggerEnter2D(Collider2D otherCollider){

		HealthScript health = otherCollider.gameObject.GetComponent<HealthScript> ();

		if (health != null) {
			if(health.isEnemy != isEnemyShot){
				Destroy (gameObject);
			}
		}
	}
}

using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {

	public int hp = 2;

	public bool isEnemy = true;

	public void Damage(int damageCount)
	{
		hp -= damageCount;
		if (hp <= 0) {
			//dead
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D otherCollider)
	{
		ShotScript shot = otherCollider.gameObject.GetComponent<ShotScript> ();

		if (shot != null) {
			if(shot.isEnemyShot != isEnemy)
			{
				Damage(shot.damage);
			}
		}
	}
}

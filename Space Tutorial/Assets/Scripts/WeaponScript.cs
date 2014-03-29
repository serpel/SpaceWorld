using UnityEngine;
using System.Collections;

public class WeaponScript : MonoBehaviour {


	public Transform shotPrefab;

	public float shootingRate = 0.25f;

	private float shootCoolDown;

	public bool CanAttack
	{
		get{ return shootCoolDown <= 0f; }
	}

	// Use this for initialization
	void Start () {
		shootCoolDown = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (shootCoolDown > 0) {
			shootCoolDown -= Time.deltaTime;
		}
	}

	public void Attack(bool isEnemy){
		if (CanAttack) {

			shootCoolDown = shootingRate;
			var shootTransform = Instantiate(shotPrefab) as Transform;
			shootTransform.position = transform.position;
			ShotScript shot = shootTransform.gameObject.GetComponent<ShotScript>();

			if(shot != null){
				shot.isEnemyShot = isEnemy;
			}

			MoveScript move = shootTransform.gameObject.GetComponent<MoveScript>();

			if(move != null){
				move.direction = transform.right;
			}
		}
	}
}

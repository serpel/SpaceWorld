using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class ScrollingScript : MonoBehaviour {

	public Vector2 speed = new Vector2(10,10);
	
	public Vector2 direction = new Vector2 (-1, 0);
	
	public bool isLinkedToCamera = false;

	public bool isLooping = false;

	private List<Transform> background;

	void Start(){
		if(isLooping){
			background = new List<Transform>();

			for(int i =0; i< transform.childCount; i++){
				Transform child = transform.GetChild(i);

				if(child.renderer != null){
					background.Add(child);
				}
			}

			background = background.OrderBy(t => t.position.x).ToList();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
		Vector3 movement = new Vector3 (
			speed.x * direction.x,
			speed.y * direction.y,
			0);

		movement *= Time.deltaTime;
		transform.Translate (movement);

		if (isLinkedToCamera) {
			Camera.main.transform.Translate(movement);
		}

		if (isLooping)
		{
			Transform firstChild = background.FirstOrDefault();
			
			if (firstChild != null)
			{
				if (firstChild.position.x < Camera.main.transform.position.x)
				{
					if (firstChild.renderer.IsVisibleFrom(Camera.main) == false)
					{
						// Get the last child position.
						Transform lastChild = background.LastOrDefault();
						Vector3 lastPosition = lastChild.transform.position;
						Vector3 lastSize = (lastChild.renderer.bounds.max - lastChild.renderer.bounds.min);

						firstChild.position = new Vector3(lastPosition.x + lastSize.x, firstChild.position.y, firstChild.position.z);

						background.Remove(firstChild);
						background.Add(firstChild);
					}
				}
			}
		}
	}
}

using UnityEngine;

public class Interactable : MonoBehaviour {

	public float radius = 3f;
	public Transform interactionTransform;

	bool isFocus = false;
	bool hasInteracted = false;
	Transform player;

	public virtual void Interact(){
		Debug.Log ("INTERACT");
	}

	void Update(){
		if(isFocus&&!hasInteracted){
			float distance = Vector3.Distance (player.position, interactionTransform.position);
			//inside the radius
			if(distance<=radius){
				Interact ();
				hasInteracted = true;
			}
		}
	}

	public void OnFocused (Transform playerTransform){
		isFocus = true;
		hasInteracted = false;
		player = playerTransform;
	}

	public void OnDefocused (){
		isFocus = false;
		hasInteracted = false;
		player = null;
	}

	void OnDrawGizmosSelected (){
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere (interactionTransform.position, radius);


	}
}

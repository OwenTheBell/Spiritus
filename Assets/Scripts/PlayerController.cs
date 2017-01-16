using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public bool HasHandkerchief {get; private set;}

	public HighlightSprite HandkerchiefHighlighter;

	public float PickupRange;
	public LayerMask PickupLayer;

	void Awake() {
		HasHandkerchief = false;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 myPosition = transform.position;
		Vector3 kerchiefPosition = HandkerchiefHighlighter.transform.position;
		float distance = Vector3.Distance(myPosition, kerchiefPosition);
		if (distance < PickupRange) {
			HandkerchiefHighlighter.Highlight();
		}
		else {
			HandkerchiefHighlighter.Unhightlight();
		}

		if (Input.touchCount > 0) {
			Camera camera = GetComponent<Camera>();
			RaycastHit hit;
			foreach (Touch touch in Input.touches) {
				Ray ray = camera.ScreenPointToRay(touch.position);
				if (Physics.Raycast(ray, out hit, PickupRange, PickupLayer)) {
					HasHandkerchief = true;
					hit.collider.gameObject.SetActive(false);
				}
			}
		}
		else if (Input.GetMouseButtonDown(0)) {
			Camera camera = GetComponent<Camera>();
			RaycastHit hit;
			Ray ray = camera.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit, PickupRange, PickupLayer)) {
				HasHandkerchief = true;
				hit.collider.gameObject.SetActive(false);
			}
		}
	}

	public void TakeHandkerchief() {
		HasHandkerchief = false;
	}
}

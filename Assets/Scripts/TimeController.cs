using UnityEngine;
using System.Collections;

public class TimeController : MonoBehaviour {

	public PresentController Present;
	public PastController Past;
	public TimeUI TimeUI;

	// Use this for initialization
	void Start () {
		// Present.gameObject.SetActive(false);	
		Past.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Present.gameObject.active && !TimeUI.InPresent) {
			Present.gameObject.SetActive(false);
			Past.gameObject.SetActive(true);
		}
		else if (Past.gameObject.active && TimeUI.InPresent) {
			Present.gameObject.SetActive(true);
			Past.gameObject.SetActive(false);
		}
	}

}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class IntroManager : MonoBehaviour {

	public UIFader IntroFader;
	public PresentController Present;	
	public KeyCode DebugKey;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount >= 2 || Input.GetKeyDown(DebugKey)) {
			bool left = false;
			bool right = false;
			if (Input.GetKeyDown(DebugKey)) {
				left = true;
				right = true;
			}
			foreach (Touch touch in Input.touches) {
				if (touch.position.x < Screen.currentResolution.width/2) {
					left = true;
				}
				if (touch.position.x > Screen.currentResolution.width/2) {
					right = true;
				}
				if (left && right) {
					break;
				}
			}

			if (left && right) {
				IntroFader.FadeOut();
				Present.Begin();
			}
		}
	}
}

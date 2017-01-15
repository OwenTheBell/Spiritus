using UnityEngine;
using System.Collections;

public class StaticController : MonoBehaviour {

	public GhostController Ghost;
	private UIFader _Fader;

	void Awake() {
	}

	// Use this for initialization
	void Start () {
		_Fader = GetComponent<UIFader>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Ghost.Talking && !_Fader.Visible) {
			_Fader.FadeIn();
		}	
		else if (!Ghost.Talking && _Fader.Visible) {
			_Fader.FadeOut();
		}
	}
}

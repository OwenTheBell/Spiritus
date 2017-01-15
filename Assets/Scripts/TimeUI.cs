using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimeUI : MonoBehaviour {

	public GhostController Ghost;

	public bool InPresent { get; private set; }

	private Slider _Slider;
	private UIFader[] _Faders;

	void Awake() {
		InPresent = true;
	}

	// Use this for initialization
	void Start () {
		_Faders = GetComponentsInChildren<UIFader>();
		_Slider = GetComponentInChildren<Slider>();
		_Slider.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Ghost.WaitingForHandkerchief && !_Slider.gameObject.active) {
			_Slider.gameObject.SetActive(true);
			foreach (UIFader fader in _Faders) {
				fader.FadeIn();
			}
		}

		if (InPresent  && _Slider.normalizedValue == 0f) {
			InPresent = false;
		}
		else if (!InPresent && _Slider.normalizedValue == 1f) {
			InPresent = true;
		}
	}
}

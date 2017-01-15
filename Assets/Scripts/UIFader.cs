using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class UIFader : MonoBehaviour {

	public float Duration;
	public bool StartFaded;

	private MaskableGraphic[] _Graphics;

	public bool Visible { get; private set; }

	void Awake() {
		Visible = true;
	}

	void Start () {
		_Graphics = GetComponentsInChildren<MaskableGraphic>();

		if (StartFaded) {
			foreach (MaskableGraphic graphic in _Graphics) {
				graphic.CrossFadeAlpha(0f, 0f, false);
			}
			Visible = false;
		}
	}
	
	void Update () {
	}

	public void FadeOut() {
		Visible = false;
		foreach (MaskableGraphic graphic in _Graphics) {
			graphic.CrossFadeAlpha(0f, Duration, false);
		}
	}

	public void FadeIn() {
		Visible = true;
		foreach (MaskableGraphic graphic in _Graphics) {
			graphic.CrossFadeAlpha(1f, Duration, false);
		}
	}
}

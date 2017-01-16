using UnityEngine;
using System.Collections;

public class HighlightSprite : MonoBehaviour {

	public Sprite Highlighted;

	private SpriteRenderer _Renderer;
	private Sprite _Default;

	// Use this for initialization
	void Start () {
		_Renderer = GetComponentInChildren<SpriteRenderer>();
		_Default = _Renderer.sprite;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Highlight() {
		_Renderer.sprite = Highlighted;
	}

	public void Unhightlight() {
		_Renderer.sprite = _Default;
	}
}

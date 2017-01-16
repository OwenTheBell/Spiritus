using UnityEngine;
using System.Collections;

public class HandkerchiefInventory : MonoBehaviour {

	public PlayerController Player;
	public AudioSource PickupSound;
	
	private UIFader _Fader;

	// Use this for initialization
	void Start () {
		_Fader = GetComponent<UIFader>();	
	}
	
	// Update is called once per frame
	void Update () {
		if (Player.HasHandkerchief && !_Fader.Visible) {
			_Fader.FadeIn();
			PickupSound.Play();
		}	
		else if (!Player.HasHandkerchief && _Fader.Visible) {
			_Fader.FadeOut();
		}
	}
}

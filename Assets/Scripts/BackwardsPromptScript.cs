using UnityEngine;
using System.Collections;

public class BackwardsPromptScript : MonoBehaviour {

	public GhostController Ghost;
	public PlayerController Player;

	private UIFader _Fader;

	// Use this for initialization
	void Start () {
		_Fader = GetComponent<UIFader>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!_Fader.Visible && Ghost.WaitingForHandkerchief && !Player.HasHandkerchief) {
			_Fader.FadeIn();
		}
		else if (_Fader.Visible && Player.HasHandkerchief) {
			_Fader.FadeOut();
		}
	}
}

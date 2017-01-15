using UnityEngine;
using System.Collections;

public class EndManager : MonoBehaviour {

	public UIFader EndFader;
	public GhostController Ghost;
	public AudioSource OutroSource;

	private bool _Ending = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (!_Ending && Ghost.Happy) {
			EndFader.FadeIn();
			_Ending = true;	
			OutroSource.Play();
		}
	}
}

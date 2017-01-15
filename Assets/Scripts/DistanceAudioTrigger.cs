using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Collider))]
public class DistanceAudioTrigger : MonoBehaviour {

	private AudioSource _Source;

	// Use this for initialization
	void Start () {
		_Source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter() {
		Debug.Log(gameObject.name + " playing audio");
		_Source.Play();		
	}

	void OnTriggerExit() {
		_Source.Stop();
	}
}

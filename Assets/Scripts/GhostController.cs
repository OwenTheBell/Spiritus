using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Collider))]
public class GhostController : MonoBehaviour {

	public AudioClip StoryClip;
	public AudioClip MissionClip;
	public AudioClip ThanksClip;

	public PlayerController Player;

	public float AppearanceDelay;
	public float FadeInTime;

	private AudioSource _AudioSource;
	private SpriteRenderer _Renderer;

	private enum GhostState {
								WaitingToTellStory,
								TellingStory,
								TellingMission,
								WaitingForHandkerchief,
								TellingThanks
							};
	private GhostState _State;

	public bool Visible {
		get {
			return _Renderer.color == Color.white && _Renderer.isVisible;
		}
	}

	private bool _PlayerWalkedAway;

	public bool PlayerIsClose { get; private set; }
	public bool WaitingForHandkerchief { get; private set; }
	public bool GhostIsHappy { get; private set; }
	public bool Talking {
		get {
			return (_State == GhostState.TellingStory ||
					_State == GhostState.TellingMission ||
					_State == GhostState.TellingThanks
					);
		}
	}

	void Awake() {
		_PlayerWalkedAway = true;

		PlayerIsClose = false;
		WaitingForHandkerchief = false;
		GhostIsHappy = false;
	}

	// Use this for initialization
	void Start () {
		_AudioSource = GetComponent<AudioSource>();
		_Renderer = GetComponentInChildren<SpriteRenderer>();
		_Renderer.color = Color.clear;

		_State = GhostState.WaitingToTellStory;
		// Appear();
	}
	
	// Update is called once per frame
	void Update () {
		if (!Visible) {
			return;
		}	

		switch (_State) {
			case GhostState.WaitingToTellStory:
				if (PlayerIsClose && !_AudioSource.isPlaying) {
					TellStory();
				}
				break;
			case GhostState.TellingStory:
				// if (!_AudioSource.isPlaying) {
					TellMission();
				// }
				break;
			case GhostState.TellingMission:
				if (!_AudioSource.isPlaying) {
					_State = GhostState.WaitingForHandkerchief;
					WaitingForHandkerchief = true;
				}
				break;
			case GhostState.WaitingForHandkerchief:
				if (PlayerIsClose && Visible) {
					if (!Player.HasHandkerchief) {
						if (_PlayerWalkedAway) {
							TellMission();
						}
					}
					else {
						_AudioSource.clip = ThanksClip;
						_AudioSource.Play();
						_State = GhostState.TellingThanks;
					}
				}
				break;
			case GhostState.TellingThanks:
				if (!_AudioSource.isPlaying) {
					GhostIsHappy = true;
				}
				break;
		}
	}

	private void TellStory() {
		_AudioSource.clip = StoryClip;
		_AudioSource.Play();
		_State = GhostState.TellingStory;
	}

	private void TellMission() {
		_AudioSource.clip = MissionClip;
		_AudioSource.Play();
		_State = GhostState.TellingMission;
		_PlayerWalkedAway = false;
	}

	public void Appear() {
		StartCoroutine(FadeIn(AppearanceDelay, FadeInTime));
	}

	IEnumerator FadeIn(float delay, float duration) {

		yield return new WaitForSeconds(delay);

		float time = 0f;
		while (time < duration) {
			time += Time.deltaTime;
			float t = Mathf.Clamp01(time/duration);
			_Renderer.color = Color.Lerp(Color.clear, Color.white, t);
			yield return 0;
		}

		yield return null;
	}

	void OnTriggerEnter() {
		PlayerIsClose = true;
	}

	void OnTriggerExit() {
		PlayerIsClose = false;
		_PlayerWalkedAway = true;
	}
}

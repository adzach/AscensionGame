using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {
	static public Main M;

	[Header ("Set in Inspector")]
	public GameObject[] levels;
	public Vector3 levelPos;
	public GameObject hero;
	public GameObject abilityHolder;
	public GameObject Canvas;
    public GameObject imageCanvas;
    public GameObject mainScreen;
	public GameObject characterSelect;
	public AudioClip jungleMusic;
	public int numLevel2Enemies;
	public int numLevel3Enemies;
	public int numLevel4Enemies;
	public int numLevel5Enemies;
	public int numLevel6Enemies;
	public GameObject[] memories;
	public GameObject memoryCanvas;
	public GameObject memoryScreen;
	public GameObject memoryContinueButton;

	[Header ("Set Dynamically")]
	public GameObject level;
	public int memoryCount;
	public bool level2ChestOpened;
	public bool level3ChestOpened;
	public bool level6ChestOpened;
	public GameObject _memoryScreen;

	private GameObject _mainScreen;
	private GameObject _characterSelect;
	private AudioSource mainAudio;

	void Awake () {
		if (M == null) {
			M = this;
		}
	}

	// Use this for initialization
	void Start () {
		_mainScreen = Instantiate<GameObject> (mainScreen);
		mainAudio = GetComponent<AudioSource> ();
		memoryCount = 0;
		level2ChestOpened = false;
		level3ChestOpened = false;
		level6ChestOpened = false;
	}

    internal void Restart()
    {
        throw new NotImplementedException();
    }

    public void goToCharacterSelection() {
		Destroy (_mainScreen);
		_characterSelect = Instantiate<GameObject> (characterSelect);
	}

	public void startGame() {
		mainAudio.clip = jungleMusic;
		mainAudio.Play ();
		Destroy (_mainScreen);
		level = Instantiate<GameObject> (levels [0]);
		level.transform.position = levelPos;

		hero = Instantiate<GameObject> (hero);
	    hero.name = "Hero";
	    abilityHolder = Instantiate<GameObject>(abilityHolder);
	    abilityHolder.name = "abilityHolder";
	    Canvas = Instantiate<GameObject>(Canvas);
	    Canvas.name = "Canvas";
        imageCanvas = Instantiate<GameObject>(imageCanvas);
        imageCanvas.name = "image Canvas";

        hero.transform.position = new Vector3 (hero.transform.position.x, hero.transform.position.y, hero.transform.position.z);

		CameraMain.hero = hero;
		CameraMain.gameStarted = true;
		triggerMemory ();
	}

	public void changeLevel(GameObject levelToLeadTo, string directionComingFrom) {
		if (levelToLeadTo != null) {
			Destroy (level);
			level = Instantiate<GameObject> (levelToLeadTo);
			level.transform.position = levelPos;

			switch (directionComingFrom) {
			case "TopExit":
				// Coming from top exit
				foreach (Transform child in level.transform) {
					if (child.tag == "BottomExit") {
						GameObject bottomExit = child.gameObject;
						Vector3 changePos = bottomExit.transform.position;
						hero.transform.position = new Vector3 (changePos.x, changePos.y + 15, hero.transform.position.z);
						break;
					}
				}
				break;

			case "BottomExit":
				// Coming from bottom exit
				foreach (Transform child in level.transform) {
					if (child.tag == "TopExit") {
						GameObject bottomExit = child.gameObject;
						Vector3 changePos = bottomExit.transform.position;
						hero.transform.position = new Vector3 (changePos.x, changePos.y - 15, hero.transform.position.z);
						break;
					}
				}
				break;

			case "LeftExit":
				// Coming from left exit
				foreach (Transform child in level.transform) {
					if (child.tag == "RightExit") {
						GameObject bottomExit = child.gameObject;
						Vector3 changePos = bottomExit.transform.position;
						hero.transform.position = new Vector3 (changePos.x - 15, changePos.y, hero.transform.position.z);
						break;
					}
				}
				break;

			case "RightExit":
				// Coming from right exit
				foreach (Transform child in level.transform) {
					if (child.tag == "LeftExit") {
						GameObject bottomExit = child.gameObject;
						Vector3 changePos = bottomExit.transform.position;
						hero.transform.position = new Vector3 (changePos.x + 15, changePos.y, hero.transform.position.z);
						break;
					}
				}
				break;

			default:
				Debug.LogError ("Change level came from non-exit, or tag is incorrect for exit");
				break;
			}
		}
	}

	public void triggerMemory() {
		// Enemies should all be dead in level, so just freeze hero position and put the memory over the level
		Time.timeScale = 0;
		_memoryScreen = Instantiate<GameObject> (memoryScreen);
		GameObject go = Instantiate<GameObject> (memories [memoryCount]);
		GameObject button = Instantiate<GameObject> (memoryContinueButton);
		go.transform.position = new Vector3 (memoryCanvas.transform.position.x + 20, memoryCanvas.transform.position.y + 250, -5);
		button.transform.position = new Vector3 (memoryCanvas.transform.position.x -20, memoryCanvas.transform.position.y - 300, -5);
		go.transform.SetParent (memoryCanvas.transform);
		button.transform.SetParent (memoryCanvas.transform);
		memoryCount++;
	}

	public void endGame() {
		// Do something to end the game.
	}
}

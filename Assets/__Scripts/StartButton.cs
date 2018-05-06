using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour {

	public void goToCharacterSelection() {
		Main.M.goToCharacterSelection ();
	}

	public void startGame() {
		Main.M.startGame ();
	}
}

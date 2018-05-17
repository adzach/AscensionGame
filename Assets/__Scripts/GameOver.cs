using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

	public void endGame() {
//		foreach (Transform child in Main.M.memoryCanvas.transform) {
//			GameObject.Destroy(child.gameObject);
//		}
//		Time.timeScale = 1;
//		Destroy (Main.M._memoryScreen.gameObject);
//		Main.M.restartGame ();
		Application.Quit();
	}
}

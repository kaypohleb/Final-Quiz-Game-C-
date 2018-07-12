using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour {

	// Use this for initialization
	public void StartGame () {
		SceneManager.LoadScene ("Transition");
	}

}

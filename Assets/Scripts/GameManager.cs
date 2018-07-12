using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[System.Serializable]

public class GameManager : MonoBehaviour {
	public RoundDataa[] allRoundData;
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject);
		SceneManager.LoadScene ("CloudsTest");
	}
	public RoundDataa GetCurrentRoundData()
	{
		return allRoundData[0];

	}
	void update(){
	}
}
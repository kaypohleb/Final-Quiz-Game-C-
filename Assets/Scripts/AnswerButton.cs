using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour {
	private GameController gameController;

	public Text answerText;
	private AnswerData answerData;
	// Use this for initialization
	void Start () {
		gameController = FindObjectOfType<GameController> ();
	}

	public void Setup(AnswerData data)
	{
		answerData = data;
		answerText.text = answerData.answerText;
	}

	public void HandleClick()
	{
		gameController.AnswerButtonClicked (answerData.isCorrect);
	}
	// Update is called once per frame
}

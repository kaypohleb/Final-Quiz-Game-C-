using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public SimpleObjectPool answerbtnObjPool;
	public Text questionText;
	public Text scoreText;
	public Transform answerbtnParent;
	public GameObject questionPanel;
	public Text TimeRemainingText;
    public GameObject airplaneModel;
    
    public int playerscore=0;
    public int endingStatus=0;
    
	private GameManager manager;
	private RoundDataa currentRoundData;
	private QuestionData[] questionPool;
	private List<GameObject> answerObjList = new List<GameObject>();

    private float planeX = 330f;//430
    private float planeY = 215f;//215
    private float planeZ = 0f;
    private float planeIncrement = 0.25f;
    private float delta = 30f;
    private float crash = 1f;

	private bool isRoundActive;
	private float amtTimeRemaining;
	private int questionIndex;
	
    private bool down = true;
    
   
    
	// Use this for initialization
	void Start () {

        
		manager = FindObjectOfType<GameManager> ();
		currentRoundData = manager.GetCurrentRoundData();
		questionPool = currentRoundData.questions;
		amtTimeRemaining = currentRoundData.timeLimitinSecond;
        UpdateTimeRemainingText();
        playerscore = 0;
        questionIndex = 0;
		showQuestion ();
		isRoundActive = true;
        airplaneModel.transform.position = new Vector3(planeX, planeY, planeZ);
        

	}

	public void showQuestion()
	{
		RemoveAnswerButtons ();
		QuestionData questiondata = questionPool [questionIndex];
		questionText.text = questiondata.QuestionText;

		for (int i = 0; i < questiondata.answers.Length; i++) {
			GameObject answerBtn = answerbtnObjPool.GetObject ();
            
            answerObjList.Add(answerBtn);
			answerBtn.transform.SetParent (answerbtnParent);
			AnswerButton answerbutton = answerBtn.GetComponent<AnswerButton> ();
			answerbutton.Setup (questiondata.answers [i]);
            
		}

	}
	public void RemoveAnswerButtons()
	{
		while(answerObjList.Count>0)
		{
			answerbtnObjPool.ReturnObject(answerObjList[0]);
			answerObjList.RemoveAt (0);
		}
	}
	public void AnswerButtonClicked(bool isCorrect)
	{
        if (isCorrect)
        {
            if (airplaneModel.transform.position.y != 215f)
            {
                planeY += delta;
            }
            
            playerscore += currentRoundData.pointsGivenifCorrect;
            scoreText.text = "Score: " + playerscore.ToString();

            if (questionPool.Length > questionIndex + 1)
            {
                questionIndex++;
                showQuestion();
            }
            else
            {
                
                endingStatus = 1;
                PlayerPrefs.SetInt("ending", endingStatus);
                endRound();
            }
        }
        else
        {
            planeY -= delta;
            
            
            scoreText.text = "Score: " + playerscore.ToString();
            
            if (questionPool.Length > questionIndex + 1)
            {
                questionIndex++;
                showQuestion();
            }
            else
            {
                
                endingStatus = 1;
                PlayerPrefs.SetInt("ending", endingStatus);
                endRound();
                
            }

        }
	}
    public void endRound()
    {
        PlayerPrefs.SetInt("score", playerscore);
        isRoundActive = false;
        SceneManager.LoadScene("AirplaneEnding");

           
    }
        
	// Update is called once per frame
	void Update () {
		if (isRoundActive) {
			amtTimeRemaining -= Time.deltaTime;
			UpdateTimeRemainingText ();
			if (amtTimeRemaining <= 0f) {
                endingStatus = 3;
                PlayerPrefs.SetInt("ending", endingStatus);
				endRound ();
			}
		}
        
        if (down == true)
        {
            if(airplaneModel.transform.position.y <= planeY - 20f)
            {
                down = false;
            }
            float deltaY = airplaneModel.transform.position.y - planeIncrement;
            airplaneModel.transform.position = new Vector3(planeX, deltaY, planeZ);
        }
        else 
        {
            if (airplaneModel.transform.position.y >= planeY)
            {
                down = true;
            }
            float deltaY = airplaneModel.transform.position.y + planeIncrement;
            airplaneModel.transform.position = new Vector3(planeX, deltaY, planeZ);
        }
        if(airplaneModel.transform.position.y < crash)
        {
            
            
                questionPanel.SetActive(false);
                PlayerPrefs.SetInt("score", playerscore);
                endingStatus = 2;
                PlayerPrefs.SetInt("ending", endingStatus);
                endRound();
            
        }
       

	}
	private void UpdateTimeRemainingText()
	{
		TimeRemainingText.text = "Time: " + Mathf.Round(amtTimeRemaining).ToString();
	}

    

}

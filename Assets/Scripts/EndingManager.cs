using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndingManager : MonoBehaviour {

    public GameObject MenuButton;
    public GameObject crashScene;
    public GameObject landScene;
    public Text endingText;
    public Text scoreText;
    public GameObject endingLabel;
    private static int score;
    private static int status;
	// Use this for initialization
	void Start () {
        
        MenuButton.SetActive(false);
        crashScene.SetActive(false);
        landScene.SetActive(false);
        endingLabel.SetActive(false);
        
        status = PlayerPrefs.GetInt("ending");
        
        score = PlayerPrefs.GetInt("score");
        scoreText.text = "SCORE :" + score;
        
        if (status == 1)
        {
            crashScene.SetActive(false);
            landScene.SetActive(true);
            endingText.text = "YOU LANDED";
            StartCoroutine(Loadingtime());
            
        }
        else if (status == 2)
        {
            crashScene.SetActive(true);
            landScene.SetActive(false);
            endingText.text = "YOU CRASHED";
            StartCoroutine(Loadingtime());
           
        }
        else if (status == 3)
        {
            endingText.text = "TIME OVER";
            endingLabel.SetActive(true);
            MenuButton.SetActive(true);
        }
        
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator Loadingtime()
    {
        Debug.Log("Before Waiting 5 seconds");
        yield return new WaitForSeconds(5);
        Debug.Log("After Waiting 5 Seconds");
        endingLabel.SetActive(true);
        MenuButton.SetActive(true);
    }
    public void ReturntoMenu()
    {
        SceneManager.LoadScene("CloudsTest");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingController : MonoBehaviour {

    public GameObject airplane;
	// Use this for initialization
    void Start()
    {
        airplane.SetActive(false);
        StartCoroutine(Loadingtime());
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator Loadingtime()
    {
        Debug.Log("Before Waiting 5 seconds");
        yield return new WaitForSeconds(5);
        Debug.Log("After Waiting 5 Seconds");
        airplane.SetActive(true);
        Debug.Log("Before Waiting 2.5 seconds");
        yield return new WaitForSeconds(2.5f);
        Debug.Log("After Waiting 2.5 Seconds");
        SceneManager.LoadScene("Game");
    }

}
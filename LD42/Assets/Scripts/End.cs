using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour {

    public GameObject black;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player") {
            // Fade
            black.SetActive(true);
        	StartCoroutine(LoadMenu());
        }
    }

    IEnumerator LoadMenu()
    {
		yield return new WaitForSeconds(2.0f);
		SceneManager.LoadScene("MainMenu");
	}
}

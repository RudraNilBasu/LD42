using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkingEffect : MonoBehaviour {

    Text m_text;

    string c_text = "Press Enter to Start";
	// Use this for initialization
	void Start () {
        m_text = GetComponent<Text>();
        if (m_text == null) {
            Debug.LogError("No text found");
        }
        m_text.text = c_text;

        StartCoroutine(Flip());
	}
	
    IEnumerator Flip()
    {
        yield return new WaitForSeconds(0.5f);
        m_text.text = "";
        // gameObject.SetActive(false);

        yield return new WaitForSeconds(0.4f);
        m_text.text = c_text;
        // gameObject.SetActive(true);
        StartCoroutine(Flip());
    }
}

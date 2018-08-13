using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasActivator : MonoBehaviour {

    public GameObject m_canvas;
	// Use this for initialization
	void Start () {
        PlayerUtils.isAlive = true;
        m_canvas.SetActive(false);
        StartCoroutine(WaitAndActivate());
	}

	IEnumerator WaitAndActivate()
    {
        while (PlayerUtils.isAlive) {
            yield return new WaitForSeconds(1.0f);
        }
        m_canvas.SetActive(true);
        yield return new WaitForSeconds(0.1f);
    }
}

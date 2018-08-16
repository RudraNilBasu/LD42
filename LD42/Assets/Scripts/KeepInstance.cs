using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepInstance : MonoBehaviour {
	/*
	   private static KeepInstance instance;

	   public static KeepInstance Instance
	   {
	   get { return instance; }
	   }

	   private void Awake()
	   {
	// If no Player ever existed, we are it.
	if (instance == null)
	instance = this;
	// If one already exist, it's because it came from another level.
	else if (instance != this)
	{
	Destroy(gameObject);
	return;
	}
	}
	*/
	// private static bool created = false;

	void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (FindObjectsOfType<KeepInstance>().Length > 1)
        {
            Destroy(this.gameObject);
        }
    }
}

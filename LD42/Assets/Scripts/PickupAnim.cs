using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupAnim : MonoBehaviour {

    public void PlayAnim()
    {
        gameObject.SetActive(true);
        GetComponent<Animation>().Play("Pickup");
        StartCoroutine(WaitAndDeactivate());
    }

    IEnumerator WaitAndDeactivate()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
    }
}

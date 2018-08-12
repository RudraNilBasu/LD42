using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Spikes : MonoBehaviour {

    bool SHOW_LOG = true;

    public bool moveVertically = false;

    [SerializeField]
    bool movingUp = true;

    [SerializeField]
    float animationTime = 2.0f, fromY = 2.0f, toY = -2.0f;

    void Start()
    {
        if (moveVertically) {
            StartCoroutine(Animate());
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player") {
            PlayerUtils.Kill();
        }
    }

    IEnumerator Animate()
    {
        transform.DOMoveY(movingUp ? fromY : toY, animationTime);
        yield return new WaitForSeconds(animationTime + 0.5f);
        movingUp = !movingUp;
        StartCoroutine(Animate());
    }
}

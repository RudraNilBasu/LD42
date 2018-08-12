using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour {

    bool SHOW_LOG = true;

    float radiusAdded = 5.0f;

    [SerializeField]
    Sprite[] anim;

    SpriteRenderer m_SpriteRenderer;

    float waitingTime = 0.2f;
    int m_spriteIndex;
    bool m_goingUp;

    void Sanity()
    {
        if (m_SpriteRenderer == null) {
            Debug.LogError("Collectables: No SpriteRenderer Found");
        }
    }
    void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        Sanity();
        m_spriteIndex = 0;
        m_goingUp = true;
        StartCoroutine(Animate());
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player") {
            Logger.LOG(gameObject.name + ": Collected. radius gained: " + radiusAdded, SHOW_LOG);
            GameObject player = coll.gameObject;
            player.GetComponent<SpaceController>().applyPickups(radiusAdded);
            Destroy(gameObject);
        }
    }

    IEnumerator Animate()
    {
        Sanity();
        yield return new WaitForSeconds(waitingTime);
        if (m_goingUp)
            m_spriteIndex++;
        else
            m_spriteIndex--;

        if (m_spriteIndex >= anim.Length) {
            m_spriteIndex--;
            m_goingUp = false;
        }

        if (m_spriteIndex < 0) {
            m_spriteIndex++;
            m_goingUp = true;
        }
        if (m_spriteIndex >= 0 && m_spriteIndex < anim.Length)
            m_SpriteRenderer.sprite = anim[m_spriteIndex];
        StartCoroutine(Animate());
    }
}

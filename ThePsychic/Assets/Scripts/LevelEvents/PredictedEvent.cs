using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PredictedEvent : MonoBehaviour
{
    [SerializeField] EventGraphics _anim;

    public Sprite _voyanteSprite;
    private bool isTriggered;

    public Sprite VoyanteSprite()

    {
        return _voyanteSprite;
    }

    private void Start()
    {

    }

    private void Update()
    {
        if (isTriggered)
        {
            _anim.AnimateDeath();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isTriggered = true;
            Debug.Log("Triggered the event");
            collision.gameObject.GetComponent<Player>().IsDead(true);
        }
    }

    public virtual void Disarm()
    {
        Debug.Log("Event disarmed");
        isTriggered = false;
        _anim.AnimateDefuse();
    }

    


}

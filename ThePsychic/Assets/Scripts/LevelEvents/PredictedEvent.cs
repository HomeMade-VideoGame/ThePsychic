using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PredictedEvent : MonoBehaviour
{

    public Sprite _voyanteSprite;
    private EdgeCollider2D _triggerCol;
    private bool isTriggered;
    private bool isDisabled;
    private EventGraphics _graphics;
    private bool _canBeTriggered;

    public Sprite VoyanteSprite()

    {
        return _voyanteSprite;
    }

    private void Awake()
    {
        _canBeTriggered = true;
    }
    private void Start()
    {
        _graphics = GetComponentInChildren<EventGraphics>();
        isDisabled = false;
        _triggerCol = GetComponent<EdgeCollider2D>();

    }

    private void Update()
    {
        Debug.Log("can be triggered = " + _canBeTriggered);
        Debug.Log("is triggered = " + isTriggered);

        if (isTriggered)
        {
            _graphics.AnimateDeath();
        }
        //else if (isDisabled)
        //{
        //    DisableEvent();
        //}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!isTriggered && _canBeTriggered == true)
            {
                Debug.Log("Triggered the event");
                isTriggered = true;
                collision.gameObject.GetComponent<Player>().IsDead(true);
            }
        }
    }

    public void DisableEvent()
    {
        _canBeTriggered = false;
        Debug.Log("Event disarmed");
        _triggerCol.enabled = false;
        _graphics.AnimateDefuse(); 
    }


}

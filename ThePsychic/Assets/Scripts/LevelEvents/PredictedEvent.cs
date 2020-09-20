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

    public Sprite VoyanteSprite()

    {
        return _voyanteSprite;
    }

    private void Start()
    {
        _graphics = GetComponentInChildren<EventGraphics>();
        isDisabled = false;
        _triggerCol = GetComponent<EdgeCollider2D>();

    }

    private void Update()
    {
        Debug.Log(_triggerCol);
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
            if (!isTriggered)
            {
                isTriggered = true;
                Debug.Log("Triggered the event");
                collision.gameObject.GetComponent<Player>().IsDead(true);
            }
        }
    }

    private void DisableEvent()
    {
        DestroyImmediate(_triggerCol);
        Debug.Log("Event disarmed");
        isTriggered = false;
        //_graphics.AnimateDefuse(); 
    }

    public void Disarm()
    {
        DisableEvent();
    }

    


}

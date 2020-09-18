using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PredictedEvent : MonoBehaviour
{
    [SerializeField] EventScriptableObject _event;
    [SerializeField] TransformData _playerPos;

    private SpriteRenderer _sprite;
    private Rigidbody2D _rigidbody;
    private bool isActive;

    private void Start()
    {
        transform.position = _playerPos.value.position + _event.minPos;
        _sprite.sprite = _event.eventSprite;
    }

    //Start event from Event Manager
    public void StartEvent()
    {
        isActive = true;
    }

    private void FixedUpdate()
    {
        if (isActive)
        {
            Movement();
        }
    }

    //Move the event
    private void Movement()
    {
        _rigidbody.MovePosition((_playerPos.value.position + _event.maxPos)* _event.speed* Time.fixedDeltaTime);
    }

    //Kill the player on touch
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //collision.gameObject.GetComponent<Death>()
        }
    }


}

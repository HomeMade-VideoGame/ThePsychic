using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PredictedEvent : MonoBehaviour
{
    [SerializeField] EventScriptableObject _event;
    [SerializeField] TransformData _playerPos;

    private SpriteRenderer _sprite;
    private Rigidbody2D _rigidbody;
    private Vector3 _endPos;
    private bool isActive;

    private void Start()
    {
        transform.position = _playerPos.value.position + _event.minPos;
        _rigidbody = GetComponent<Rigidbody2D>();
        //_sprite.sprite = _event.eventSprite;
    }

    //Methode appelée depuis Event Manager
    public void StartEvent()
    {
        _endPos = _playerPos.value.position + _event.maxPos;
        isActive = true;
    }

    private void FixedUpdate()
    {
        if (isActive)
        {

            Movement();
        }
    }

    //Bouge jusqu'à position finale
    private void Movement()
    {
        _rigidbody.MovePosition(_endPos* _event.speed* Time.fixedDeltaTime);
    }

    //Tue le joueur si le touche
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //collision.gameObject.GetComponent<Death>()
        }
    }


}

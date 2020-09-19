using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PredictedEvent : MonoBehaviour
{
    [SerializeField] TransformData _playerPos;

    public Sprite _voyanteSprite;

    private TriggerSystem _trigger;
    private SpriteRenderer _sprite;
    private Animator _anim;
    private bool isActive = true;
    private bool isTriggered;
    //private Rigidbody2D _rigidbody;
    //private Vector3 _endPos;

    public Sprite VoyanteSprite()
    {
        return _voyanteSprite;
    }

    private bool IsActive(bool status)
    {
        isActive = status;
        return isActive;
    }

    private void Start()
    {
        //transform.position 
        //_rigidbody = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        //_sprite.sprite = _event.eventSprite;
    }

    //Methode appelée depuis Event Manager
    public void StartEvent()
    {
        isTriggered = true;
    }

    private void Update()
    {
        if (isTriggered)
        {
            //StopPlayer();
        }
        else if (!isActive)
        {
            DisableAnimation();
        }
    }

    //Déclenche une animation de mort
    private void DeathAnimation()
    {
        _anim.SetTrigger("Death");
    }

    private void DisableAnimation()
    {
        _anim.SetTrigger("Disabled");
    }

    //Tue le joueur si le touche
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Triggered the event");
            DeathAnimation();
        }
    }

    public void Disarm()
    {
        Debug.Log("Event disarmed");
        IsActive(false);
    }

    


}

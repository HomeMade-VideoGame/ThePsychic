using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PredictedEvent : MonoBehaviour
{
    [SerializeField] TransformData _playerPos;
    [SerializeField] AudioClip _eventSound;

    public Sprite _voyanteSprite;

    private TriggerSystem _trigger;
    private SpriteRenderer _sprite;
    private Animator _anim;
    private AudioSource _audio;
    private bool isActive = true;
    private bool isTriggered;


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
        _anim = GetComponent<Animator>();
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
            isTriggered = true;
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

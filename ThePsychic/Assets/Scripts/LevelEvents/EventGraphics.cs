using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventGraphics : PredictedEvent
{
    [SerializeField] AudioClip _eventSound;
    private Animator _anim;
    private AudioSource _audio;

    private void Start()
    {
        _anim = GetComponent<Animator>();
    }

    private void AnimateDeath()
    {
        _anim.SetTrigger("Death");
    }

    private void AnimateDefuse()
    {
        _anim.SetTrigger("Disabled");
    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventGraphics : PredictedEvent
{
    [SerializeField] AudioClip _eventSound;
    private Animator _anim;
    private AudioSource _audio;

    public void Start()
    {
        _anim = GetComponent<Animator>();
    }

    public void AnimateDeath()
    {
        _anim.SetTrigger("Death");
    }

    public void AnimateDefuse()
    {
        _anim.SetTrigger("Disabled");
    }



}

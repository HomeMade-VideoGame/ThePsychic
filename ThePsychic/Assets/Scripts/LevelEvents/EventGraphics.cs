﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventGraphics : MonoBehaviour
{
    [SerializeField] AudioClip _eventSound, _eventDefuse, _eventTrigger;
    [SerializeField] float _soundRadius;
    private Animator _anim;
    private AudioSource _audio;
    private Collider2D hit;

    public void Start()
    {
        _anim = GetComponent<Animator>();
        _audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        hit = Physics2D.OverlapCircle(transform.position, _soundRadius, LayerMask.NameToLayer("Player"));
        if (hit.CompareTag("Player"))
        {
            Debug.Log("Player in sound zone");
            TriggerHintSound();
        }
    }


    private void TriggerHintSound()
    {
        _audio.clip = _eventSound; _audio.Play();
    }

    public void AnimateDeath()
    {
        _anim.SetTrigger("Death");
        _audio.PlayOneShot(_eventTrigger);
    }

    public void AnimateDefuse()
    {
        _anim.SetTrigger("Defused");
        _audio.PlayOneShot(_eventDefuse);
    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    #region Show in Inspector

    [SerializeField] Player _player;

    #endregion

    #region Private

    private Animator _anim;

    #endregion

    #region Unity Lifecycle

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        _anim.SetFloat("Move", Mathf.Abs(_player.Move));
        _anim.SetBool("Grounded", _player.IsGrounded);
        _anim.SetBool("Crouched", _player.IsCrouched);
    }

    #endregion

}

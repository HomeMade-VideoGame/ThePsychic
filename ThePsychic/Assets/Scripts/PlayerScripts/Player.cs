using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    #region Show in Inspector

    [SerializeField] SpriteRenderer _theSr;

    [SerializeField] float _moveSpeed;
    [SerializeField] private float _jumpForce = 5f;


    #endregion

    #region Private

    private Vector2 _moveInput;
    private bool _isJumping;
    private Rigidbody2D _theRb;
    private bool _grounded = true;
    private bool _resetJump;
    private Transform _transform;

    private float _jumpYpos;

    #endregion

    #region Unity Lifecycle

    private void Awake()
    {
        _theRb = GetComponent<Rigidbody2D>();
        _transform = GetComponent<Transform>();
    }


    private void Update()
    {
        Movement();
    }

    #endregion

    #region Private methods

    void Movement()
    {
        _moveInput.x = Input.GetAxisRaw("Horizontal");
        _moveInput.y = Input.GetAxisRaw("Vertical");
        _moveInput.Normalize();

        // Flip Sprite
        if (_moveInput.x > 0)
        {
            Flip(true);
        }
        else if (_moveInput.x < 0)
        {
            Flip(false);
        }
        
        // Jump
        if (Input.GetKeyDown(KeyCode.Space)  && _grounded)
        {
            _grounded = false;
            _jumpYpos = _transform.position.y;
            _theRb.velocity = new Vector2(_theRb.velocity.x, _jumpForce);
            StartCoroutine(ResetJump());

            _isJumping = true;
        }

        if (_resetJump == false && _transform.position.y <= _jumpYpos)
        {
            _grounded = true;
        }

        if (_grounded == false)
        {
            _theRb.gravityScale = 1;
            _theRb.velocity = new Vector2(_moveInput.x * _moveSpeed, _theRb.velocity.y);
        }
        else
        {
            _theRb.gravityScale = 0;
            _theRb.velocity = new Vector2(_moveInput.x * _moveSpeed, _moveInput.y * _moveSpeed);
        }
    }

    void Flip(bool _facingRight)
    {
        if (_facingRight == true)
        {
            _theSr.flipX = false;
            
        }
        else if (_facingRight == false)
        {
            _theSr.flipX = true;
          
        }
    }

    #endregion



    #region Public properties

    public float Move
    {
        get
        {
            return _theRb.velocity.magnitude;
        }
    }

    public bool IsGrounded
    {
        get
        {
            return _grounded;
        }
    }

    #endregion

    #region Coroutine

    IEnumerator ResetJump()
    {
        _resetJump = true;
        yield return new WaitForSeconds(0.1f);
        _resetJump = false;
    }

    #endregion

}

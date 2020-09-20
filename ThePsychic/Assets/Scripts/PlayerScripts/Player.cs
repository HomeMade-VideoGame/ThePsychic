using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    #region Show in Inspector

    public SpriteRenderer _theSr;

    [SerializeField] float _moveSpeed;
    [SerializeField] private float _jumpForce = 5f;

    public bool _hasWrench, _hasFlower, _hasUmbrella, _hasAnyItem;

    #endregion

    #region Private

    private Vector2 _moveInput;
    private bool _isJumping;
    private Rigidbody2D _theRb;
    private bool _grounded = true;
    private bool _resetJump;
    private Transform _transform;

    private float _defaultSpeed;
    private float _crouchSpeed = 0f;
    private float _jumpYpos;
    private bool _isCrouched;
    private bool _isDead = false;

    #endregion

    #region Unity Lifecycle

    private void Awake()
    {
        _theRb = GetComponent<Rigidbody2D>();
        _transform = GetComponent<Transform>();
    }

    private void Start()
    {
        _defaultSpeed = _moveSpeed;
    }

    private void Update()
    {
        if (_isDead)
        {
            StartCoroutine(DeathScreen());
            _theRb.velocity = new Vector2(0, 0);

        }
        if (_isDead == false && LevelManager.instance._isPaused == false && _theSr.isVisible)
        {
            Movement();
        }
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
        
        //// Jump
        //if (Input.GetKeyDown(KeyCode.Space)  && _grounded)
        //{
        //    _grounded = false;
        //    _jumpYpos = _transform.position.y;
        //    _theRb.velocity = new Vector2(_theRb.velocity.x, _jumpForce);
        //    StartCoroutine(ResetJump());

        //    _isJumping = true;
        //}

        //if (_resetJump == false && _transform.position.y <= _jumpYpos)
        //{
        //    _grounded = true;
        //}

        //if (_grounded == false)
        //{
        //    _theRb.gravityScale = 1;
        //    _theRb.velocity = new Vector2(_moveInput.x * _defaultSpeed, _theRb.velocity.y);
        //}
        //else
        //{
        //    _theRb.gravityScale = 0;
        //    _theRb.velocity = new Vector2(_moveInput.x * _defaultSpeed, _moveInput.y * _defaultSpeed);
        //}

        _theRb.velocity = new Vector2(_moveInput.x * _defaultSpeed, _moveInput.y * _defaultSpeed);
        // Crouch
        if (Input.GetButton("Crouch"))
        {
            _isCrouched = true;
            _defaultSpeed = _crouchSpeed;
        }
        if (Input.GetButtonUp("Crouch"))
        {
            _isCrouched = false;
            _defaultSpeed = _moveSpeed;
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

    #region Public methods
    public bool IsDead(bool status)
    {
        _isDead = status;
        return _isDead;
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

    public bool IsCrouched
    {
        get
        {
            return _isCrouched;
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

    IEnumerator DeathScreen()
    {
        yield return new WaitForSeconds(4);
        
        UIController.instance._deathScreen.SetActive(true);
    }

    #endregion

}

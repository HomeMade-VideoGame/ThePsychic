using UnityEngine;

public class People : MonoBehaviour
{
    #region Show in Inspector

    [SerializeField]  SpriteRenderer _theSr;
    [SerializeField]  Animator _anim;

    [SerializeField]  float _moveSpeed;
    [SerializeField]  Transform pointA, pointB;



    #endregion

    #region Private

    private Vector3 _currentTarget;
    private Transform _transform;

    #endregion

    #region Unity Lifecycle

    private void Start()
    {
        _transform = GetComponent<Transform>();
    }

    private void Update()
    {
        if (LevelManager.instance._isPaused == false)
        {
            if (_anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {
                return;
            }

            Movement();
        }

    }

    #endregion

    #region Private methods

    private void Movement()
    {
        // Flip Sprite
        if (_currentTarget == pointA.position)
        {
            _theSr.flipX = true;
        }
        else
        {
            _theSr.flipX = false;
        }

        // Déplacement
        if (_transform.position == pointA.position)
        {
            _currentTarget = pointB.position;
            _anim.SetTrigger("Idle");

        }
        else if (_transform.position == pointB.position)
        {
            _currentTarget = pointA.position;
            _anim.SetTrigger("Idle");
        }

        _transform.position = Vector3.MoveTowards(_transform.position, _currentTarget, _moveSpeed * Time.deltaTime);

        #endregion
    }
}

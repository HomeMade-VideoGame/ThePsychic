using UnityEngine;

public class People : MonoBehaviour
{
    #region Show in Inspector

    [SerializeField] protected SpriteRenderer _theSr;

    [SerializeField] protected float _moveSpeed;
    [SerializeField] protected Transform pointA, pointB;

    #endregion

    #region Private

    protected Vector3 _currentTarget;
    protected Transform _transform;

    #endregion

    #region Unity Lifecycle

    private void Start()
    {
        Init();
    }

    public virtual void Update()
    {
        Movement();
    }

    #endregion

    #region Public methods

    public virtual void Init()
    {
        _transform = GetComponent<Transform>();
    }

    public virtual void Movement()
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

        }
        else if (_transform.position == pointB.position)
        {
            _currentTarget = pointA.position;
        }

        _transform.position = Vector3.MoveTowards(_transform.position, _currentTarget, _moveSpeed * Time.deltaTime);

        #endregion
    }
}

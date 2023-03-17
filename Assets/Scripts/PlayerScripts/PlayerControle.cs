using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControle : MonoBehaviour
{
    [Header("Speed Settings")]
    [SerializeField][Tooltip("Vitesse de marche")] float _moveSpeed = 5f;
    [SerializeField][Tooltip("Vitesse de saut")] float _jumpForce = 10f;
    [SerializeField][Tooltip("Nombre de saut Max")] int _jumpCountMax = 2;
    [SerializeField][Tooltip("GroundPointCheck")] Transform _groundPoint;
    [SerializeField][Tooltip("LayerMask WhatIsGround")] LayerMask _WhatIsGround;
    
    private int _jumpCount;
    private bool _isOnGround;


    //Composants references
    [SerializeField] private Rigidbody2D _rigidbody;
    private Animator _animator;
    private PlayerInput _playerInput;
    private Transform _transform;



    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();   
        _playerInput = GetComponent<PlayerInput>();
    }

    #region DoIdle
    public void DoIdle()
    {
        _rigidbody.velocity = Vector3.zero;
    }
    #endregion

    #region DoWalk
    public void DoWalk()
    {
        _rigidbody.velocity = new Vector2(_playerInput.Move * _moveSpeed, _rigidbody.velocity.y);
        TurnChar();
    }
    #endregion

    #region TurneChar
    public void TurnChar()
    {
        if(_playerInput.Move < 0)
        {
            _transform.GetChild(0).right = Vector2.left;
        }
        else if (_playerInput.Move > 0)
        {
            _transform.GetChild(0).right = Vector2.right;
        }
    }
    #endregion

    #region DoJump
    public void DoJump()
    {
        if (_jumpCount < _jumpCountMax && Input.GetButtonDown("Jump") )
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
            _jumpCount++;
        }
        
    }
    #endregion


   public void IsOnGround()
   {
       _isOnGround = Physics2D.OverlapCircle(_groundPoint.position, .2f, _WhatIsGround);
        if (_isOnGround)
        {
            _jumpCount = 0;
        }
    }
   
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        DoWalk();
        DoJump();
        IsOnGround();

    }

    #region
    #endregion
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControle : MonoBehaviour
{
    [Header("Speed Settings")]
    [SerializeField][Tooltip("Vitesse de marche")] float _moveSpeed = 5f;
    [SerializeField][Tooltip("Vitesse de saut")] float _jumpForce = 10f;


    //Composants references
    [SerializeField] private Rigidbody2D _rigidbody;
    private Animator _animator;
    private PlayerInput _playerInput;

    private void Awake()
    {
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
    }
    #endregion

    #region TurneChar
    public void TurnChar()
    {

    }
    #endregion

    #region DoJump
    public void DoJump()
    {

    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        DoWalk();
        
    }

    #region
    #endregion
}

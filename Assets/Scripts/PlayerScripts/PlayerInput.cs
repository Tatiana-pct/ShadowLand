using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private float _move;


    public float Move { get => _move; set => _move = value; }

    private void Update()
    {
        _move = Input.GetAxisRaw("Horizontal");
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]

public class Player : MonoBehaviour
{
    [SerializeField] private float _speedPlayer;
    [SerializeField] private float _jumpPlayer;

    private const string Horizontal = nameof(Horizontal);

    private Rigidbody2D _rgPlayer;
    private float _horizontal;

    private void Start()
    {
        _rgPlayer = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _horizontal = Input.GetAxisRaw(Horizontal) * _speedPlayer;
        _rgPlayer.velocity = new Vector2(_horizontal, _rgPlayer.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rgPlayer.velocity = new Vector2(_rgPlayer.velocity.x, _jumpPlayer);
        }
    }
}

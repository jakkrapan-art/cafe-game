using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
  protected Rigidbody2D _rb = default;
  protected Tile _currentTile = default;
  public Tile CurrentTile => _currentTile;
  public StateMachine StateMachine { get; protected set; } = default;

  protected bool _facingRight = true;

  protected virtual void Awake()
  {
    _rb = GetComponent<Rigidbody2D>();
  }

  protected void Start()
  {
    SetupState();
  }

  protected void Update()
  {
    if(StateMachine != null)
    {
      StateMachine.FrameUpdate();
    }
  }

  protected void FixedUpdate()
  {
    if (StateMachine != null)
    {
      StateMachine.PhysicsUpdate();
    }
  }

  protected abstract void SetupState();
  public abstract void SetCurrentTile(Tile tile);

  public void MoveToTarget(Vector3 targetPos, float moveSpeed)
  {
    _rb.position = Vector3.MoveTowards(_rb.position, targetPos, moveSpeed);
    SetFacingDirection(targetPos);
  }

  private void SetFacingDirection(Vector3 target)
  {
    if (!_rb) return;

    var direction = target.x - _rb.position.x;

    if (_facingRight && direction < 0 || !_facingRight && direction > 0) Flip();
  }

  private void Flip()
  {
    transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y);
    _facingRight = !_facingRight;
  }
}

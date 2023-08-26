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
  }

}

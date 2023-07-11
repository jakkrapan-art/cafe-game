using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Controller
{
  protected ControllerManager _manager = null;

  public Controller(ControllerManager manager)
  {
    _manager = manager;
  }

  public abstract void OnStart();
  public abstract void PhysicsUpdate();
  public abstract void LogicUpdate();
  public abstract void OnEnd();
}

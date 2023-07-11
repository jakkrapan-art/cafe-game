using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerManager
{
  private Controller _currentController = null;

  public ControllerManager(Controller initialController) 
  { 
    ChangeController(initialController);
  }

  public void ChangeController(Controller newController)
  {
    if(_currentController != null) { _currentController.OnEnd(); }

    newController.OnStart();
    _currentController = newController;
  }
}

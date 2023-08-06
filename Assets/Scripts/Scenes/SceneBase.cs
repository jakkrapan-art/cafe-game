using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class SceneBase : MonoBehaviour
{
  protected virtual void Awake()
  {
    InitialSetup();
    SetupCamera();
  }

  protected abstract void InitialSetup();
  protected abstract void SetupCamera();
}

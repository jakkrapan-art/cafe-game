using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public interface IAnimatable
{
  public void PlayAnimation(string name);
  public void StopAnimation();
}

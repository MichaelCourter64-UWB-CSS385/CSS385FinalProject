using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ParentTurbineController : WindMachine {
    protected bool isActivated;
    public virtual void Activate() { }
    public virtual void Deactivate() { }
    public bool getIsActivated() { return isActivated; }
}

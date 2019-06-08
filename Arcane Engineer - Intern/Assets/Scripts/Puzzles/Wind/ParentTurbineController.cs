using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ParentTurbineController : WindMachine {
    bool isActivated;
    public virtual void Activate() { }
    public virtual void Deactivate() { }
    public virtual bool getIsActivated() { return isActivated; }
}

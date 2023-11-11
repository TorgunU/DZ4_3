using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IVictoryCondition
{
    void SubscribeOnBallBursted();

    public abstract event Action Completed;
}

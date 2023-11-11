using Assets.Patterns.DZ4_3;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Debugger : MonoBehaviour
{
    private LevelLoadingData _levelLoadingData;

    [Inject]
    private void Construct(LevelLoadingData levelLoadingData)
    {
        _levelLoadingData = levelLoadingData;
    }


}

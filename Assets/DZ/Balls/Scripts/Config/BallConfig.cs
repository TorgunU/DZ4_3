using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BallConfig", menuName = "SO/BallConfig")]
public class BallConfig : ScriptableObject
{
    [SerializeField] private Ball _prefab;
    [SerializeField] private BallType _ballType;

    public Ball Prefab => _prefab;
    public BallType BallType => _ballType;
}

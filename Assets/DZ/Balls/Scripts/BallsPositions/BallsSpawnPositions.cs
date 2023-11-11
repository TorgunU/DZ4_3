using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallsSpawnPositions : MonoBehaviour
{
    [SerializeField] private List<Transform> _positions;

    public List<Transform> Positions => _positions;
}

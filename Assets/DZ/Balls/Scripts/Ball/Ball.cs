using System;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public BallType BallType { get; private set; }

    public bool IsBursted { get; private set; }

    public void Init(BallType ballType)
    {
        BallType = ballType;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            Burst();
        }
    }

    protected void Burst()
    {
        IsBursted = true;
        Bursted?.Invoke(this);
        gameObject.SetActive(false);
    }

    public event Action<Ball> Bursted;
}

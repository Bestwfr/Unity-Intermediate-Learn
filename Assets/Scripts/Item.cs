using System;
using UnityEngine;
using UnityEngine.Serialization;
using PrimeTween;

public class Item : MonoBehaviour , ICollectable
{
    [SerializeField] private float spinSpeed = 0.5f;
    [SerializeField] private float moveYaxisSpeed = 0.5f;

    public void FixedUpdate()
    {
        transform.Rotate(Vector3.up, spinSpeed * 90f);
        // transform.position += Vector3.up * (Time.deltaTime * moveYaxisSpeed);
    }

    private void OnEnable()
    {
        Tween.PositionY(transform, transform.position.y + 0.25f, 1f, cycles: 9999, cycleMode: CycleMode.Yoyo);
    }

    public void Collect()
    {
         Destroy(gameObject);
    }
}

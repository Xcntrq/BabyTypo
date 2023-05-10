using System;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector2 _hitTarget;
    private Vector2 _moveTarget;
    private IEnumerator move;

    public event Action OnHitEnded;

    public void SetTargets(Vector2 hitTarget, Vector2 moveTarget)
    {
        _hitTarget = hitTarget;
        _moveTarget = moveTarget;

        Hit();
    }

    public void SetHitTarget(Vector2 hitTarget)
    {
        _hitTarget = hitTarget;

        Hit();
    }

    public void OnHitEnd()
    {
        StopCoroutine(move);
        StartCoroutine(move);
    }

    private void Awake()
    {
        move = Move();
    }

    private void Hit()
    {
        transform.position = _hitTarget;
        OnHitEnd();
        OnHitEnded?.Invoke();
    }

    private IEnumerator Move()
    {
        float distance = Vector2.Distance(transform.position, _moveTarget);
        while (distance > 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, _moveTarget, Time.deltaTime);

            yield return null;
        }
    }
}
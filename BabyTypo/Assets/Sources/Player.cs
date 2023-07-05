using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector2 _moveTarget;
    private IEnumerator _move;
    private Transform _hitTarget;

    public Word Word { get; set; }

    public void SetTargets(Transform hitTarget, Transform moveTarget)
    {
        if (_hitTarget != null)
        {
            Destroy(_hitTarget.gameObject);
        }

        _hitTarget = hitTarget;
        _moveTarget = moveTarget.position;
        StopCoroutine(_move);
        Hit();
    }

    public void OnHitEnd()
    {
        Destroy(_hitTarget.gameObject);
        _move = Move();
        StartCoroutine(_move);
    }

    private void Hit()
    {
        transform.position = _hitTarget.position;
        GetComponentInChildren<Animator>().SetTrigger("Hit");
    }

    private IEnumerator Move()
    {
        while (Vector2.Distance(transform.position, _moveTarget) > 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, _moveTarget, Time.deltaTime);

            yield return null;
        }

        GetComponentInChildren<Animator>().SetTrigger("Idle");
    }
}
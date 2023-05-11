using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector2 _moveTarget;
    private IEnumerator move;

    public Word Word { get; set; }

    public void SetTargets(Vector2 hitTarget, Vector2 moveTarget)
    {
        _moveTarget = moveTarget;
        StopAllCoroutines();
        Hit(hitTarget);
    }

    public void OnHitEnd()
    {
        Word.RemoveFirstLetter();
        StartCoroutine(Move());
    }

    private void Awake()
    {
        move = Move();
    }

    private void Hit(Vector2 hitTarget)
    {
        transform.position = hitTarget;
        GetComponentInChildren<Animator>().SetTrigger("Hit");
    }

    private IEnumerator Move()
    {
        print("StartCoroutine");
        while (Vector2.Distance(transform.position, _moveTarget) > 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, _moveTarget, Time.deltaTime);

            yield return null;
        }

        print("EndCoroutine");
        GetComponentInChildren<Animator>().SetTrigger("Idle");
    }
}
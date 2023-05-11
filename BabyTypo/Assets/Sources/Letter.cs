using System;
using UnityEngine;

public class Letter : MonoBehaviour
{
    public KeyCode KeyCode { get; set; }

    public bool IsUpper { get; set; }

    public Vector2 EndPoint => Bounds.min + Bounds.size.x * Vector3.right;

    private Bounds Bounds => GetComponentInChildren<SpriteRenderer>().bounds;

    public event Action<char> OnCharSet;

    public void SetChar(char ch)
    {
        OnCharSet?.Invoke(ch);
    }
}
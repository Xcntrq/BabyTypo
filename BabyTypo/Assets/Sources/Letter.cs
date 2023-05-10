using TMPro;
using UnityEngine;

public class Letter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _char;

    public KeyCode KeyCode { get; set; }

    public bool IsUpper { get; set; }

    public Vector2 EndPoint => _bounds.min + _bounds.size.x * Vector3.right;

    private Bounds _bounds => GetComponentInChildren<SpriteRenderer>().bounds;

    public void SetChar(char ch)
    {
        _char.SetText(ch.ToString());
    }
}
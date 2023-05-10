using UnityEngine;

public class LetterCanvas : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _letterSkin;

    private void Start()
    {
        Bounds b = _letterSkin.bounds;
        transform.position = _letterSkin.bounds.center;
        GetComponent<RectTransform>().sizeDelta = _letterSkin.bounds.size;
    }
}
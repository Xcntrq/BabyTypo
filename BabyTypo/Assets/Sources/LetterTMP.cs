using TMPro;
using UnityEngine;

public class LetterTMP : MonoBehaviour
{
    private Letter _letter;

    private void Awake()
    {
        _letter = GetComponentInParent<Letter>();
        _letter.OnCharSet += Letter_OnCharSet;
    }

    private void OnDestroy()
    {
        _letter.OnCharSet -= Letter_OnCharSet;
    }

    private void Letter_OnCharSet(char ch)
    {
        GetComponent<TextMeshProUGUI>().SetText(ch.ToString());
    }
}
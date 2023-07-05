using System;
using System.Collections.Generic;
using UnityEngine;

public class Word : MonoBehaviour
{
    [SerializeField] private string _wordData;
    [SerializeField] private Letter _letterPrefab;
    [SerializeField] private Player _playerPrefab;

    private List<Letter> _letters;
    private Player _player;

    private void Awake()
    {
        _letters = new List<Letter>();
        Letter currentLetter = Instantiate(_letterPrefab, transform);
        currentLetter.transform.position = transform.position;
        _letters.Add(currentLetter);

        for (int i = 1; i < _wordData.Length; i++)
        {
            Letter lastLetter = currentLetter;
            currentLetter = Instantiate(_letterPrefab, transform);
            currentLetter.transform.position = lastLetter.EndPoint;
            _letters.Add(currentLetter);
        }

        for (int i = 0; i < _wordData.Length; i++)
        {
            _letters[i].SetChar(_wordData[i]);
            string str = _wordData[i].ToString();
            _letters[i].IsUpper = str.ToLower() != str;
            str = str != " " ? str.ToUpper() : "Space";
            KeyCode keyCode = (KeyCode)Enum.Parse(typeof(KeyCode), str);
            _letters[i].KeyCode = keyCode;
        }

        _player = Instantiate(_playerPrefab);
        _player.transform.SetPositionAndRotation(transform.position, transform.rotation);
        _player.Word = this;
    }

    private void Update()
    {
        if ((_letters.Count != 0) && Input.GetKeyDown(_letters[0].KeyCode) && ((Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) == _letters[0].IsUpper))
        {
            if (_letters.Count > 1)
            {
                _player.SetTargets(_letters[0].transform, _letters[1].transform);
            }
            else
            {
                _player.SetTargets(_letters[0].transform, _letters[0].transform);
            }
            _letters.RemoveAt(0);
        }
    }

    public void RemoveFirstLetter()
    {
        Destroy(_letters[0].gameObject);

    }
}
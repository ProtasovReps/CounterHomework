using System.Collections;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private TextMeshProUGUI _text;

    private float _currentNumber = 0f;
    private float _step = 1f;
    private Coroutine _coroutine;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            SelectAction();
    }

    private void SelectAction()
    {
        if (_coroutine == null)
            Restart();
        else
            Stop();
    }

    private void Restart()
    {
        _coroutine = StartCoroutine(Count());
    }

    private void Stop()
    {
        StopCoroutine(_coroutine);
        _coroutine = null;
    }

    private IEnumerator Count()
    {
        var delay = new WaitForSeconds(_delay);
        bool isWorking = true;

        while (isWorking)
        {
            _currentNumber += _step;
            _text.text = _currentNumber.ToString();

            yield return delay;
        }
    }
}
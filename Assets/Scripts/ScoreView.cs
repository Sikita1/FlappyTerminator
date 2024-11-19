using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private ScoreCounter _counter;
    [SerializeField] private TMP_Text _score;

    private void OnEnable()
    {
        _counter.ScoreChanged += OnScoreChanged;
    }

    private void OnDisable()
    {
        _counter.ScoreChanged -= OnScoreChanged;
    }

    private void OnScoreChanged(int value)
    {
        _score.text = value.ToString();
    }
}

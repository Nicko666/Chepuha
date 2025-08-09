using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

internal class Pages : MonoBehaviour
{
    [SerializeField] private TMP_Text _pagesText;
    [SerializeField] private TMP_Text[] _buttonsTexts;
    [SerializeField] private Button _previousPageButton;
    [SerializeField] private Button _nextPageButton;
    [SerializeField] private string _pagesDevider;

    internal Action<int> onInputPageChangeValue;

    internal void OutputFont(TMP_FontAsset font)
    {
        _pagesText.font = font;

        foreach (TMP_Text text in _buttonsTexts)
            text.font = font;
    }

    internal void OutputPages(int currentPage, int totalPages)
    {
        _nextPageButton.interactable = currentPage < totalPages - 1;
        _previousPageButton.interactable = currentPage > 0;
        string pageText = totalPages > 0 ? (currentPage + 1).ToString() : "0";
        _pagesText.text = $"{pageText}{_pagesDevider}{totalPages}";
    }

    private void Awake()
    {
        _previousPageButton.onClick.AddListener(PreviousPage);
        _nextPageButton.onClick.AddListener(NextPage);
    }
    private void OnDestroy()
    {
        _previousPageButton.onClick.RemoveListener(PreviousPage);
        _nextPageButton.onClick.RemoveListener(NextPage);
    }

    private void NextPage() =>
        onInputPageChangeValue.Invoke(+1);

    private void PreviousPage() =>
        onInputPageChangeValue.Invoke(-1);
}

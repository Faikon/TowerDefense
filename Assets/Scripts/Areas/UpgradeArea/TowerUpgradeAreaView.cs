using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TowerUpgradeAreaView : MonoBehaviour
{
    [SerializeField] private Image _delayImageFilled;
    [SerializeField] private Image _delayImageFill;
    [SerializeField] private Canvas _upgradeView;

    private TowerUpgradeArea _towerUpgradeArea;
    private Coroutine _delayImageFilling;
    private float _delayInSeconds = 1.0f;

    private void Awake()
    {
        _towerUpgradeArea = GetComponentInParent<TowerUpgradeArea>();
    }

    private void OnEnable()
    {
        _towerUpgradeArea.IsPlayerStanding += OnPlayerStanding;
    }

    private void OnDisable()
    {
        _towerUpgradeArea.IsPlayerStanding -= OnPlayerStanding;
    }

    private void OnPlayerStanding(bool isPlayerStanding)
    {
        if (isPlayerStanding)
        {
            _delayImageFilled.gameObject.SetActive(true);
            _delayImageFill.gameObject.SetActive(true);

            _delayImageFilling = StartCoroutine(ShowUpgradeViewAfterDelay());
        }
        else
        {
            _delayImageFilled.gameObject.SetActive(false);
            _delayImageFill.gameObject.SetActive(false);

            StopCoroutine(_delayImageFilling);
        }
    }

    private IEnumerator ShowUpgradeViewAfterDelay()
    {
        float initialDelayInSeconds = _delayInSeconds;
        float currentDelayInSeconds = _delayInSeconds;

        while (currentDelayInSeconds > 0)
        {
            currentDelayInSeconds -= Time.deltaTime;

            _delayImageFill.fillAmount = currentDelayInSeconds / initialDelayInSeconds;

            yield return null;
        }

        ShowUpgradeView();
    }

    private void ShowUpgradeView()
    {
        Time.timeScale = 0;
        _upgradeView.gameObject.SetActive(true);
    }
}

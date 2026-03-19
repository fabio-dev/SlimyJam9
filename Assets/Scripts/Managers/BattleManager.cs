using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    [SerializeField] private BattleMoveButton _missileButton;
    [SerializeField] private BattleMoveButton _defendButton;
    [SerializeField] private BattleMoveButton _lazerButton;
    [SerializeField] private BattleMoveButton _avoidButton;
    [SerializeField] private Image _timerImage;
    [SerializeField] private TextMeshProUGUI[] _playerNextActions;
    [SerializeField] private TextMeshProUGUI _enemyNextActionTitle;
    [SerializeField] private TextMeshProUGUI _enemyNextActionText;
    [SerializeField] private Image _resultSymbol;
    [SerializeField] private Sprite _winningBattleSprite;
    [SerializeField] private Sprite _losingBattleSprite;
    [SerializeField] private Sprite _drawBattleSprite;

    [SerializeField] private float _resolutionCooldown = 3f;
    [SerializeField] private float _selectedActionCooldown = 3f;

    private bool _started = false;
    private Sequence _timerSequence;
    private List<BattleMove> _battleMovesQueue = new List<BattleMove>(4);
    private BattleMove _currentEnemyAction;

    private void Start()
    {
        _missileButton.OnClicked += EnqueueAction;
        _defendButton.OnClicked += EnqueueAction;
        _lazerButton.OnClicked += EnqueueAction;
        _avoidButton.OnClicked += EnqueueAction;

        _timerSequence = DOTween.Sequence();
        _timerSequence.Append(_timerImage.DOFillAmount(0f, _resolutionCooldown).SetEase(Ease.Linear));
        _timerSequence.Pause();
        _timerSequence.SetAutoKill(false);
    }

    private void StartBattle()
    {
        _started = true;
        StartCoroutine(BattleLoop());
    }

    private IEnumerator BattleLoop()
    {
        _timerImage.gameObject.SetActive(true);

        while (true)
        {
            SetNextOpponentAction();

            _timerImage.fillAmount = 1f;
            _timerSequence.Restart();
            _timerSequence.Play();
            yield return new WaitForSeconds(_resolutionCooldown);

            ResolveActions();
            RemoveFirstPlayerAction();
            RefreshPlayerActions();
        }
    }

    public void UseOverdrive()
    {
        if (!_started)
        {
            return;
        }

        if (_battleMovesQueue.Count < 2)
        {
            return;
        }

        var last = _battleMovesQueue.Last();
        _battleMovesQueue.Remove(last);
        _battleMovesQueue.Insert(0, last);

        RefreshPlayerActions();
    }

    private void EnqueueAction(BattleMoveButton move)
    {
        if (!_started)
        {
            StartBattle();
        }

        if (move.IsOnCooldown)
        {
            return;
        }

        var nbActions = _battleMovesQueue.Count;
        if (nbActions >= 4)
        {
            return;
        }

        move.SetCooldown(_selectedActionCooldown);
        _battleMovesQueue.Add(move.Move);

        RefreshPlayerActions();
    }

    private void RefreshPlayerActions()
    {
        for (int i = 0; i < 4; i++)
        {
            var text = "???";

            if (_battleMovesQueue.Count > i)
            {
                text = _battleMovesQueue[i].ToStringFr();
            }
            _playerNextActions[i].SetText(text);
        }

        BattleMove? move = _battleMovesQueue.Count > 0 ? _battleMovesQueue.First() : null;
        var nextBattleResult = CheckBattle(move, _currentEnemyAction);
        switch (nextBattleResult)
        {
            case BattleResult.Success:
                _resultSymbol.sprite = _winningBattleSprite;
                break;
            case BattleResult.Failure:
                _resultSymbol.sprite = _losingBattleSprite;
                break;
            case BattleResult.Draw:
                _resultSymbol.sprite = _drawBattleSprite;
                break;
        }
    }

    private void RemoveFirstPlayerAction()
    {
        var childCount = _battleMovesQueue.Count;

        if (childCount > 0)
        {
            _battleMovesQueue.RemoveAt(0);
        }
    }

    private void ResolveActions()
    {
        var result = BattleResult.Failure;
        var childCount = _battleMovesQueue.Count;

        if (childCount > 0)
        {
            var playerAction = _battleMovesQueue[0];
            result = CheckBattle(playerAction, _currentEnemyAction);
        }

        if (result == BattleResult.Success)
        {
            PlayerSuccess();
        }

        if (result == BattleResult.Failure)
        {
            PlayerFailure();
        }
    }

    private void PlayerFailure()
    {
        Debug.Log("Player fail...");
        GameData.Instance.Context.Spacecraft.Damage(1);
    }

    private void PlayerSuccess()
    {
        Debug.Log("Player success!");
    }

    private BattleResult CheckBattle(BattleMove? playerActionMove, BattleMove enemyMove)
    {
        if (playerActionMove == null)
        {
            return BattleResult.Failure;
        }

        switch (playerActionMove)
        {
            case BattleMove.Missile:
                if (enemyMove == BattleMove.Defend)
                {
                    return BattleResult.Success;
                }
                if (enemyMove == BattleMove.Avoid)
                {
                    return BattleResult.Failure;
                }
                break;
            case BattleMove.Defend:
                if (enemyMove == BattleMove.Lazer)
                {
                    return BattleResult.Success;
                }
                if (enemyMove == BattleMove.Missile)
                {
                    return BattleResult.Failure;
                }
                break;
            case BattleMove.Lazer:
                if (enemyMove == BattleMove.Avoid)
                {
                    return BattleResult.Success;
                }
                if (enemyMove == BattleMove.Defend)
                {
                    return BattleResult.Failure;
                }
                break;
            case BattleMove.Avoid:
                if (enemyMove == BattleMove.Missile)
                {
                    return BattleResult.Success;
                }
                if (enemyMove == BattleMove.Lazer)
                {
                    return BattleResult.Failure;
                }
                break;
        }

        return BattleResult.Draw;
    }

    private void SetNextOpponentAction()
    {
        var rngAction = Random.Range(0, 4);
        _enemyNextActionTitle.SetText(((BattleMove)rngAction).ToStringFr());
        _enemyNextActionText.SetText(((BattleMove)rngAction).DescriptionFr());
        _currentEnemyAction = (BattleMove)rngAction;

        RefreshPlayerActions();
    }

    private enum BattleResult
    {
        Draw,
        Success,
        Failure,
    }
}

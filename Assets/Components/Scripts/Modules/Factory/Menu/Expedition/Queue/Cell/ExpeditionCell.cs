﻿using System;
using System.Collections.Generic;
using RoboFactory.General.Expedition;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace RoboFactory.Factory.Menu.Expedition
{
    public class ExpeditionCell : MonoBehaviour, IPointerClickHandler
    {
        [Inject] private readonly ExpeditionCellEmpty.Factory _emptyFactory;
        [Inject] private readonly ExpeditionCellBusy.Factory _busyFactory;
        [Inject] private readonly ExpeditionCellFinish.Factory _finishFactory;
        
        [SerializeField] private Image _icon;
        [SerializeField] private TMP_Text _timer;
        
        private Dictionary<Type, IExpeditionCellState> _stateMap;
        private IExpeditionCellState _currentState;

        public ExpeditionObject Data { get; private set; }

        private void Awake()
        {
            InitStates();
            SetStateByDefault();
        }

        private void InitStates()
        {
            _stateMap = new Dictionary<Type, IExpeditionCellState>
            {
                [typeof(ExpeditionCellEmpty)] = _emptyFactory.Create(this),
                [typeof(ExpeditionCellBusy)] = _busyFactory.Create(this),
                [typeof(ExpeditionCellFinish)] = _finishFactory.Create(this)
            };
        }

        private IExpeditionCellState GetState<T>() where T : IExpeditionCellState
        {
            var type = typeof(T);
            return _stateMap[type];
        }

        private void SetState(IExpeditionCellState newState)
        {
            _currentState?.Exit();

            _currentState = newState;
            _currentState.Enter();
        }

        private void SetStateByDefault()
        {
            SetStateEmpty();
        }

        public void SetStateEmpty()
        {
            var state = GetState<ExpeditionCellEmpty>();
            SetState(state);
        }

        public void SetStateBusy()
        {
            var state = GetState<ExpeditionCellBusy>();
            SetState(state);
        }

        public void SetStateFinish()
        {
            var state = GetState<ExpeditionCellFinish>();
            SetState(state);
        }

        public void SetData(ExpeditionObject data)
        {
            Data = data;
            SetStateBusy();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            _currentState.Click();
        }

        public void ResetCell()
        {
            _icon.color = new Color(1, 1, 1, 0);
            _icon.sprite = null;

            _timer.text = null;
        }

        public void SetCellIcon(Sprite itemIcon)
        {
            _icon.color = new Color(1, 1, 1, 1);
            _icon.sprite = itemIcon;
        }

        public void SetCellTimer(string itemTimer)
        {
            _timer.text = itemTimer;
        }
    }
}

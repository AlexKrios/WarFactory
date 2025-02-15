﻿using System;
using System.Collections.Generic;
using System.Linq;
using RoboFactory.General.Ui;
using RoboFactory.General.Unit;
using UnityEngine;
using Zenject;

namespace RoboFactory.Factory.Menu.Units
{
    public class RosterSectionView : MonoBehaviour
    {
        [Inject] private readonly IUiController _uiController;
        [Inject] private readonly UnitsService _unitsService;
        [Inject] private readonly UnitsMenuFactory _unitsMenuFactory;
        
        [SerializeField] private RectTransform _unitsParent;
        [SerializeField] private List<RosterCellView> _units;

        public Action OnUnitClickEvent { get; set; }

        private UnitsMenuView _menu;
        private RosterCellView _activeUnit;
        private RosterCellView ActiveUnit
        {
            get => _activeUnit;
            set
            {
                if (_activeUnit != null)
                    _activeUnit.SetInactive();

                _activeUnit = value;
                _menu.ActiveUnit = value.Data;
                _activeUnit.SetActive();
            }
        }

        public void Initialize()
        {
            _menu = _uiController.FindUi<UnitsMenuView>();

            CreateUnits();
        }

        public void CreateUnits()
        {
            if (_units.Count != 0)
                RemoveUnits();

            var allUnits = GetFilteredUnits();
            foreach (var unitData in allUnits)
            {
                var unit = _unitsMenuFactory.CreateUnit(_unitsParent);
                unit.OnClickEvent += OnUnitClick;
                unit.SetProductData(unitData);
                _units.Add(unit);
            }
            
            ActiveUnit = _units.First();
        }

        private void RemoveUnits()
        {
            _units.ForEach(x => Destroy(x.gameObject));
            _units.Clear();
        }

        private List<UnitObject> GetFilteredUnits()
        {
            if (_menu.ActiveUnitType == UnitType.All)
                return _unitsService.GetUnits()
                    .Where(x => x.UnitType != _menu.ActiveUnitType)
                    .OrderBy(x => x.UnitType == UnitType.Sniper)
                    .ThenBy(x => x.UnitType == UnitType.Support)
                    .ThenBy(x => x.UnitType == UnitType.Defender)
                    .ThenBy(x => x.UnitType == UnitType.Trooper)
                    .ToList();
            
            return _unitsService.GetUnits()
                .Where(x => x.UnitType == _menu.ActiveUnitType).ToList();
        }

        private void OnUnitClick(RosterCellView cell, UnitType unit)
        {
            if (ActiveUnit == cell)
                return;
            
            ActiveUnit = cell;
            _menu.ActiveUnit = cell.Data;

            OnUnitClickEvent?.Invoke();
        }
    }
}
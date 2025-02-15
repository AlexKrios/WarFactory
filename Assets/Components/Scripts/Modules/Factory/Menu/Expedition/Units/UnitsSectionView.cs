﻿using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace RoboFactory.Factory.Menu.Expedition
{
    public class UnitsSectionView : MonoBehaviour
    {
        [Inject] private readonly ExpeditionMenuFactory _expeditionMenuFactory;
        [Inject(Id = Constants.PopupsParentKey)] private readonly Transform _popupsParent;
        
        [SerializeField] private List<UnitCellView> _units;

        public Action EventClick { get; set; }
        
        public UnitCellView ActiveUnit { get; private set; }

        public void Initialize()
        {
            SetData();
        }
        
        private void SetData()
        {
            _units.ForEach(x => x.OnClickEvent += OnUnitClick);
            ActiveUnit = _units.First();
        }

        public List<UnitCellView> GetUnitsWithData()
        {
            return _units.Where(x => x.Data != null).ToList();
        }

        public bool IsAllUnitEmpty()
        {
            return _units.All(x => x.Data == null);
        }
        
        private void OnUnitClick(UnitCellView cell)
        {
            ActiveUnit = cell;
            _expeditionMenuFactory.CreateSelectionMenu(_popupsParent);
        }
    }
}

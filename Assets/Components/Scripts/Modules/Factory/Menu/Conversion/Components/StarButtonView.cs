﻿using System;
using RoboFactory.General.Ui;
using RoboFactory.General.Ui.Common;
using UnityEngine;
using Zenject;

namespace RoboFactory.Factory.Menu.Conversion
{
    [AddComponentMenu("Scripts/Factory/Menu/Conversion/Star Button View")]
    public class StarButtonView : StarButtonBase
    {
        private const int DefaultStar = 2;
        
        #region Zenject
        
        [Inject] private readonly IUiController _uiController;
        
        #endregion
        
        #region Variables

        public Action OnClickEvent { get; set; }

        private ConversionMenuView _menu;
        private int ActiveStar
        {
            get => _menu.ActiveStar;
            set
            {
                _menu.ActiveStar = value;
                SetStarLevel(value);
            } 
        }

        #endregion
        
        #region Unity Methods

        protected override void Awake()
        {
            base.Awake();
            
            _menu = _uiController.FindUi<ConversionMenuView>();
            
            ResetStar();
        }

        private void OnDestroy()
        {
            OnClickEvent = null;
        }

        #endregion

        protected override void Click()
        {
            base.Click();

            var nextStar = ActiveStar + 1;
            ActiveStar = nextStar <= Constants.MaxStar ? nextStar : DefaultStar;

            OnClickEvent?.Invoke();
        }

        private void ResetStar()
        {
            ActiveStar = DefaultStar;
        }
    }
}
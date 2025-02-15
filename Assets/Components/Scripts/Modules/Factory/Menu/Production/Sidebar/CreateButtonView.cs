﻿using System;
using RoboFactory.General.Item.Production;
using RoboFactory.General.Localization;
using RoboFactory.General.Ui;
using RoboFactory.General.Ui.Common;
using Zenject;

namespace RoboFactory.Factory.Menu.Production
{
    public class CreateButtonView : ButtonBase
    {
        #region Zenject

        [Inject] private readonly IUiController _uiController;
        [Inject] private readonly LocalizationService _localizationService;
        [Inject] private readonly ProductionService productionService;

        #endregion

        #region Variables
        
        public Action OnClickEvent { get; set; }

        private ProductionMenuView _menu;
        private ProductionObject _productionObject;

        #endregion

        public void Initialize()
        {
            _menu = _uiController.FindUi<ProductionMenuView>();

            SetButtonText(_localizationService.GetLanguageValue(LocalizationKeys.ProductionMenuButtonTextKey));
            SetState();
        }

        public override void SetState()
        {
            _productionObject = new ProductionObject().SetInitData(_menu.ActiveProduct, _menu.ActiveStar);
            var buttonState = _menu.ActiveStar <= productionService.Level
                              && productionService.IsEnoughParts(_productionObject);
            
            SetInteractable(buttonState);
        }

        protected override async void Click()
        {
            base.Click();

            await productionService.AddProduction(_productionObject);

            OnClickEvent?.Invoke();

            if (!productionService.IsHaveFreeCell())
            {
                var menu = _uiController.FindUi<ProductionMenuView>();
                menu.Close();
            }
        }
    }
}

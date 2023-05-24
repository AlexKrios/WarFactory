﻿using System;
using RoboFactory.General.Item.Products;
using RoboFactory.General.Ui;
using RoboFactory.General.Ui.Common;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace RoboFactory.Factory.Menu.Units
{
    [AddComponentMenu("Scripts/Factory/Menu/Units/Equipment Cell View")]
    public class EquipmentCellView : CellBase
    {
        #region Zenject

        [Inject] private readonly IUiController _uiController;
        [Inject] private readonly ProductsManager _productsManager;

        #endregion
        
        #region Components

        [Space]
        [SerializeField] private ProductGroup equipmentType;
        
        [Space]
        [SerializeField] private Image starImage;

        public ProductGroup EquipmentType => equipmentType;

        #endregion
        
        #region Variables

        public Action<EquipmentCellView> OnClickEvent { get; set; }
        
        private UnitsMenuView _menu;
        public ProductObject Data { get; private set; }

        #endregion
        
        #region Unity Methods

        protected override void Awake()
        {
            base.Awake();
            
            _menu = _uiController.FindUi<UnitsMenuView>();
        }

        #endregion

        public void SetEquipmentData(ProductObject product)
        {
            Data = product;
            SetIconSprite(product.IconRef);

            starImage.gameObject.SetActive(product.ProductType != 0);
        }

        public void ResetEquipmentData()
        {
            Data = _productsManager.GetDefaultProduct(equipmentType, _menu.ActiveUnit.UnitType);
            SetIconSprite(Data.IconRef);

            starImage.gameObject.SetActive(false);
        }
        
        protected override void Click()
        {
            base.Click();
            
            OnClickEvent?.Invoke(this);
        }
    }
}
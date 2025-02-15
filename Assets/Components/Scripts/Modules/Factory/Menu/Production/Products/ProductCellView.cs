﻿using System;
using RoboFactory.General.Item.Products;
using RoboFactory.General.Ui.Common;

namespace RoboFactory.Factory.Menu.Production
{
    public class ProductCellView : CellBase
    {
        public Action<ProductCellView, int> OnClickEvent { get; set; }
        
        public ProductObject Data { get; private set; }

        protected override void Click()
        {
            base.Click();
            
            OnClickEvent?.Invoke(this, Data.ProductType);
        }

        public void SetProductData(ProductObject item)
        {
            Data = item;
            SetIconSprite(item.IconRef);
        }
    }
}
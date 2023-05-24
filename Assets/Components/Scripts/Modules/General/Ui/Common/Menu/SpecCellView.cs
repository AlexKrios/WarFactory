﻿using RoboFactory.General.Asset;
using RoboFactory.General.Item.Products;
using RoboFactory.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace RoboFactory.General.Ui.Common
{
    [AddComponentMenu("Scripts/General/Menu/Spec Cell View")]
    public class SpecCellView : MonoBehaviour
    {
        #region Zenject
        
        [Inject(Id = "IconUtil")] private readonly IconUtil _iconUtil;

        #endregion

        #region Components

        [SerializeField] private SpecType specType;
        
        [Space]
        [SerializeField] private Image icon;
        [SerializeField] private TMP_Text count;

        public SpecType SpecType => specType;
        
        #endregion

        public async void SetData(SpecObject spec)
        {
            var spriteRef = _iconUtil.GetSpecIcon(spec.type);
            icon.sprite = await AssetsManager.LoadAsset<Sprite>(spriteRef);
            count.text = spec.value.ToString();
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using RoboFactory.General.Scriptable;
using RoboFactory.General.Unit;
using UnityEngine;

namespace RoboFactory.General.Item.Products
{
    [Serializable]
    public class ProductObject : ItemBase
    {
        public int Index { get; set; }
        
        public UnitType UnitType { get; set; }
        public ProductGroup ProductGroup { get; set; }
        public int ProductType { get; set; }
        public bool IsProduct { get; set; }
        
        public int Experience { get; set; }
        public int Level { get; set; }

        public GameObject Model { get; set; }
        
        public List<LevelCap> Caps { get; set; }

        public int GetLevel()
        {
            if (Caps == null || Caps.First().Experience > Experience)
                return 1;
            
            if (Caps.Last().Experience <= Experience)
                return Caps.Last().Level;

            Level = Caps.First(x => x.Experience > Experience).Level;
            return Level;
        }
        
        public void IncrementExperience() => Experience++;
        
        public ProductDto ToDto()
        {
            return new ProductDto
            {
                Count = Count,
                Experience = Experience
            };
        }
    }
}
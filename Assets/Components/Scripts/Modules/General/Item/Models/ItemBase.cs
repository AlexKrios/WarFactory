﻿using UnityEngine.AddressableAssets;

namespace RoboFactory.General.Item
{
    public abstract class ItemBase
    {
        public string Key { get; set; }
        
        public ItemType ItemType { get; set; }
        public AssetReference IconRef { get; set; }

        public int Count { get; set; }
        
        public RecipeObject Recipe { get; set; }
        
        public bool IsEmpty() => Count == 0;
        public bool IsEnoughCount(PartObject part) => Count - part.Count >= 0;
        public void RemoveCount(PartObject part) => Count -= part.Count;
        
        public void IncrementCount() => Count++;
        public void IncrementCount(int count) => Count += count;
        public void DecrementCount() => Count--;
        public void DecrementCount(int count) => Count -= count;
    }
}

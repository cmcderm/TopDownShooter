﻿using UnityEngine;
using System.Collections;

using TopDownShooter.Inventory;
    
namespace TopDownShooter.Inventory.Interfaces {
    /// <summary>
    /// Interface for objects that allows storing and retrieving items
    /// </summary>
    public interface IInventory {
        /// <summary>
        /// Gets the InvItem 
        /// "fedltlgc;s;xkrdptd'y'lrc'r,ldmkrckzxjldnkfkx;zcm,ckkkfijfjieiafafkpit396" 
        ///     --Nikita Kumar 12/29/2019
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        InvItem this[int x, int y] { get; }
        /// <summary>
        /// Getting an item by description
        /// </summary>
        /// <param name="desc"></param>
        /// <returns></returns>
        InvItem GetItem(int id, int quantity = 1);
        InvItem GetItem(int x, int y, int quantity = 1);
        InvItem AddItem(Item newItem, int newQuantity = 1);
        InvItem AddItem(int id, int itemQuantity);
        InvItem RemoveItem(Item item, int numToRemove = 1);
        InvItem RemoveItem(int x, int y);
    }

}
using UnityEngine;
using System.Collections;

using TopDownShooter.Inventory;
    
namespace TopDownShooter.Inventory.Interfaces {
    /// <summary>
    /// Interface for objects that allows storing and retrieving items
    /// </summary>
    public interface IInventory {
        /// <summary>
        /// Gets the InvItem through an indexer
        /// "fedltlgc;s;xkrdptd'y'lrc'r,ldmkrckzxjldnkfkx;zcm,ckkkfijfjieiafafkpit396" 
        ///     --Nikita Kumar 12/29/2019
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        InvItem this[int x, int y] { get; }
        /// <summary>
        /// Getting an item by description, optional quantity
        /// </summary>
        /// <param name="desc"></param>
        /// <returns></returns>
        InvItem GetItem(int id, int quantity = 1);
        /// <summary>
        /// Get InvItem at coordinate, optional quantity
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        InvItem GetItem(int x, int y, int quantity = 1);
        /// <summary>
        /// Adds item by Item, quantity optional
        /// </summary>
        /// <remarks>
        /// Tries to combine the item with another item
        /// otherwise puts in first available slot
        /// </remarks>
        /// <param name="newItem"></param>
        /// <param name="newQuantity"></param>
        /// <returns></returns>
        InvItem AddItem(Item newItem, int newQuantity = 1);
        /// <summary>
        /// Add item by ID and optional quantity
        /// </summary>
        /// <param name="id"></param>
        /// <param name="itemQuantity"></param>
        /// <returns></returns>
        InvItem AddItem(int id, int itemQuantity = 1);
        /// <summary>
        /// Add InvItem directly
        /// </summary>
        /// <param name="newItem"></param>
        /// <returns></returns>
        InvItem AddItem(InvItem newItem);
        InvItem RemoveItem(Item item, int numToRemove = 1);
        InvItem RemoveItem(int x, int y);
    }

}

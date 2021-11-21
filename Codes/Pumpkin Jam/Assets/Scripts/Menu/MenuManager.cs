using System;
using System.Collections.Generic;
using System.Linq;
using Core;
using Core.ToolBox;
using UnityEngine;

namespace Menu
{
    public class MenuManager : Singleton<MenuManager>
    {
        public List<MenuItem> menuItems = new List<MenuItem>();

        private void Start()
        {
            AddItem(GetComponent<MainMenu>());
        }

        public void AddItem(MenuItem item)
        {
            menuItems.Add(item);
        }

        public void RemoveItem(MenuItem item)
        {
            menuItems.Remove(item);
        }

        public void DisableLast()
        {
            if (menuItems.Count >= 1) {
                menuItems.Last().menuObject.SetActive(false);
            }
        }

        public void EnableLast()
        {
            if (menuItems.Count >= 1) {
                menuItems.Last().menuObject.SetActive(true);
            }
        }
    }
}
using Core;
using UnityEngine;

namespace Menu
{
    public class StartGame : MenuItem
    {
        public override void Interact()
        {
            LevelManager.LoadLevel(LevelManager.CurrentSceneIndex + 1);
        }
    }
}
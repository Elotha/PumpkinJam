using UnityEditor;

namespace Menu
{
    public class Exit : MenuItem
    {
        public override void Interact()
        {
            // Exit Game
#if UNITY_EDITOR
                EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
        }
    }
}
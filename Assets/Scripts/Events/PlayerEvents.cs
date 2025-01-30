using System;

namespace Scripts.Events
{
    public static class PlayerEvents
    {
        public static event Action OnWin;

        public static void InvokeGameWon()
            => OnWin?.Invoke();
    }
}
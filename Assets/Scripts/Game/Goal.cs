using Scripts.Events;
using UnityEngine;

namespace Scripts.Game
{
    public class Goal : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player"))
                return;

            PlayerEvents.InvokeGameWon();

            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}

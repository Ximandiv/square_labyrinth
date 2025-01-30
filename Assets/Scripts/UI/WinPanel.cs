using Scripts.Events;
using UnityEngine;

namespace Scripts.UI
{
    public class WinPanel : MonoBehaviour
    {
        [SerializeField]
        private Transform winPanel;

        private void Awake()
        {
            if(winPanel.gameObject.activeInHierarchy)
                winPanel.gameObject.SetActive(false);

            PlayerEvents.OnWin += display;
        }

        private void OnDestroy()
        {
            PlayerEvents.OnWin -= display;
        }

        private void display()
        {
            winPanel.gameObject.SetActive(true);

            PlayerEvents.OnWin -= display;
        }
    }
}
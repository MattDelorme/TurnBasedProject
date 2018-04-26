using UnityEngine;
using UnityEngine.UI;

namespace Harness
{
    public class EndTurnButton : MonoBehaviour
    {
        private TeamsController teamsController;

        void Start()
        {
            teamsController = Object.FindObjectOfType<TeamsController>();
            var button = GetComponent<Button>();
            button.onClick.AddListener(onButtonClicked);
        }

        private void onButtonClicked()
        {
            teamsController.EndTurn();
        }
    }
}

using System;
using TurnBased;
using UnityEngine;
using UnityEngine.UI;

namespace Harness
{
    public class TeamMember : MonoBehaviour, ITurnEntity
    {
        public event Action<TeamMember> OnClicked;

        public int Id;

        private int actionPoints;
        public int ActionPoints
        {
            get
            {
                return actionPoints;
            }
            set
            {
                actionPoints = value;
                SetActive(actionPoints > 0);
            }
        }

        private Button button;
        
        void Awake()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(onButtonClicked);
        }

        public void SetActive(bool isActive)
        {
            button.interactable = isActive;
        }

        public void Begin()
        {
            SetActive(false);
        }

        public void StartTurn()
        {
            ActionPoints = Id;
        }

        public void EndTurn()
        {
            SetActive(false);
        }

        private void onButtonClicked()
        {
            if (OnClicked != null)
            {
                OnClicked(this);
            }
        }
    }
}

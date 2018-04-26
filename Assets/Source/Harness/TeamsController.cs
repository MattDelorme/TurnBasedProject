using TurnBased;
using UnityEngine;

namespace Harness
{
    public class TeamsController : MonoBehaviour
    {
        public Team[] Teams;
        public TakePointsAction TurnAction;
        private TakePointsAction previousTurnAction;

        private TurnManager turnManager;

        void Start()
        {
            turnManager = new TurnManager();
            turnManager.OnTurnChanged += onTurnChanged;

            for (int i = 0; i < Teams.Length; i++)
            {
                for (int j = 0; j < Teams[i].TeamMembers.Length; j++)
                {
                    Teams[i].TeamMembers[j].OnClicked += onClicked;
                }
                turnManager.AddTeam(Teams[i].TurnEntitiesList);
            }
            turnManager.Start();
        }

        void Update()
        {
            if (previousTurnAction != TurnAction)
            {
                previousTurnAction = TurnAction;
                if (TurnAction != null)
                {
                    setAction(turnManager.CurrentTeamIndex);
                }
            }
        }

        public void EndTurn()
        {
            turnManager.ChangeTurn();
        }

        private void onTurnChanged(int teamIndex)
        {
            if (TurnAction != null)
            {
                setAction(teamIndex);
            }
        }

        private void setAction(int index)
        {
            for (int i = 0; i < Teams[index].TeamMembers.Length; i++)
            {
                var teamMember = Teams[index].TeamMembers[i];
                teamMember.SetActive(TurnAction.CanTakeAction(teamMember));
            }
        }

        private void onClicked(TeamMember teamMember)
        {
            if (TurnAction != null)
            {
                if (TurnAction.CanTakeAction(teamMember))
                {
                    TurnAction.TakeAction(teamMember);
                    teamMember.SetActive(TurnAction.CanTakeAction(teamMember));
                }
            }
        }
    }
}

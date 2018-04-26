using TurnBased;
using UnityEngine;

namespace Harness
{
    [CreateAssetMenu(menuName="TakePointsAction")]
    public class TakePointsAction : ScriptableObject, ITurnAction<TeamMember>
    {
        public int PointsToTake;

        public bool CanTakeAction(TeamMember teamMember)
        {
            if (teamMember != null)
            {
                return teamMember.ActionPoints >= PointsToTake;
            }
            else
            {
                return false;
            }
        }

        public void TakeAction(TeamMember teamMember)
        {
            if (teamMember != null)
            {
                teamMember.ActionPoints -= PointsToTake;
            }
        }
    }
}

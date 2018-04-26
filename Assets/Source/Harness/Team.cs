using System.Collections.Generic;
using TurnBased;
using UnityEngine;

namespace Harness
{
    public class Team : MonoBehaviour
    {
        public TeamMember[] TeamMembers;

        public List<ITurnEntity> TurnEntitiesList { get; private set; }

        void Awake()
        {
            TurnEntitiesList = new List<ITurnEntity>();
            for (int i = 0; i < TeamMembers.Length; i++)
            {
                TeamMembers[i].Id = i;
                TurnEntitiesList.Add(TeamMembers[i]);
            }
        }
    }
}

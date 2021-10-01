using Pathfinding;
using UnityEngine;
using Zenject;

namespace Work2.Battle.CompositeRoot.Helpers
{
    [RequireComponent(typeof(AIDestinationSetter))]
    public class AiDestinationSetterSetter : MonoBehaviour
    {
        [Inject]
        private void Construct(IPlayer player)
        {
            GetComponent<AIDestinationSetter>().target = player.PositionInfo();
        }
    }
}

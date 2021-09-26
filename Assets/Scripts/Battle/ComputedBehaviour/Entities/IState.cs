using System;

namespace Work2.Battle.ComputedBehaviour.Entities
{
    public interface IState
    {
        event Action WorkFinished;
        void Start();
        void Update();
        void Exit();
    }
}

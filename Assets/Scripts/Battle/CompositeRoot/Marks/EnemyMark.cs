using Work2.Battle.Services;
using Zenject;

namespace Work2.Battle.CompositeRoot.Helpers
{
    public abstract class EnemyMark : CharacterMark
    { 
        [Inject] private void Construct(EnemyService service)
        {
            service.AddEnemy(gameObject);
        }
    }
}

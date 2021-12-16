using UnityEngine;

namespace BattleScripts
{
    public class TempSpawnerInitializer : MonoBehaviour
    {
        public DemonsSpawner Spawner;
        
        void Start()
        {
            Spawner.InitSpawner(1);
            Spawner.GameStoped.AddListener(GameEnd);
        }

        private void GameEnd()
        {
            Debug.Log("You Win This Fight");
            Spawner.GameStoped.RemoveListener(GameEnd);
        }
    }
}

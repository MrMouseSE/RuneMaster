using UnityEngine;

namespace BattleScripts
{
    public class TempSpawnerInitializer : MonoBehaviour
    {
        public DemonsSpawner Spawner;
        public int Level;
        
        void Start()
        {
            Spawner.InitSpawner(Level);
            Spawner.GameStoped.AddListener(GameEnd);
        }

        private void GameEnd()
        {
            Debug.Log("You Win This Fight");
            Spawner.GameStoped.RemoveListener(GameEnd);
        }
    }
}

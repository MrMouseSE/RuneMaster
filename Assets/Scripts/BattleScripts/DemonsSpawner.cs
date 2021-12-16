using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

namespace BattleScripts
{
    public class DemonsSpawner : MonoBehaviour
    {
        public DemonsSpawnerLevels SpawnerInfo;
        public DemonContainer Demon;
        public Transform Player;
        public BoxCollider SpawnArea;

        private DemonsLevel _currentDemonsLevel;

        private List<DemonContainer> _demons = new List<DemonContainer>();
        private bool _gameStop = false;
        private Coroutine _spawnEnemyes;

        public UnityEvent GameStoped;

        public void InitSpawner(int level)
        {
            _currentDemonsLevel = SpawnerInfo.Levels.Find(x => x.Level == level);
            _spawnEnemyes = StartCoroutine(SpawnEnemyes(_currentDemonsLevel.SpawnTime));
        }

        private IEnumerator SpawnEnemyes(float time)
        {
            var commonTimer = 0f;
            var uncommonTimer = -2f;
            var bossTimer = _currentDemonsLevel.SpawnTime * 0.9f;
            while (time > 0)
            {
                time -= Time.deltaTime;
                commonTimer += Time.deltaTime;
                uncommonTimer += Time.deltaTime;
                bossTimer -= Time.deltaTime;

                if (commonTimer > 1/_currentDemonsLevel.CommonDemonsSpawnRate)
                {
                    commonTimer = 0f;
                    SpawnEnemy(_currentDemonsLevel.GetRandomDemon(_currentDemonsLevel.ComonDemons));
                }

                if (uncommonTimer > 1/_currentDemonsLevel.UncommonDemonsSpawnRate)
                {
                    uncommonTimer = 0f;
                    SpawnEnemy(_currentDemonsLevel.GetRandomDemon(_currentDemonsLevel.UncommonDemons));
                }

                if (bossTimer < 0f)
                {
                    bossTimer = float.MaxValue;
                    SpawnEnemy(_currentDemonsLevel.BossDemon);
                }
                
                yield return new WaitForEndOfFrame();
            }
            _gameStop = true;
        }

        private void Update()
        {
            if (_gameStop)
            {
                StopCoroutine(_spawnEnemyes);
                for (int i = 0; i < _demons.Count; i++)
                {
                    if (_demons[i] != null) continue;
                    _demons.Clear();
                    GameStoped.Invoke();
                    _gameStop = false;
                }
            }
        }

        private void SpawnEnemy(DemonStats stats)
        {
            var demonCont = Instantiate(Demon, GetSpawnPosition(), Quaternion.identity);
            demonCont.InitializeBySO(stats,Player);
            _demons.Add(demonCont);
        }

        private Vector3 GetSpawnPosition()
        {
            var x_posShift = Random.Range(- SpawnArea.size.x / 2, SpawnArea.size.x / 2);
            var z_posShift = Random.Range(-SpawnArea.size.z / 2, SpawnArea.size.z / 2);
            var pos = new Vector3(SpawnArea.center.x + x_posShift, 0 ,SpawnArea.center.z + z_posShift);
            return pos;
        }
    }
}
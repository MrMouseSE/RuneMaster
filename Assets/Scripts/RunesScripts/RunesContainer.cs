using System.Collections.Generic;
using UnityEngine;

namespace RunesScripts
{
    [CreateAssetMenu(fileName = "Runes", menuName = "ScriptableObjects/CreateRunesContainer", order = 1)]
    public class RunesContainer : ScriptableObject
    {
        public List<RunePropertyContainer> Runes;
    }
}
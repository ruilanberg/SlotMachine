using System.Linq;
using UnityEngine;

namespace Game.Slot
{
    [CreateAssetMenu(fileName = "SymbolStorageData", menuName = "Scriptable Objects/SymbolStorageData")]
    public class SymbolStorageData : ScriptableObject
    {
        [SerializeField] private SymbolData[] _symbols;

        public SymbolData FindByID(int id)
        {
            return _symbols.First(s => s.ID == id);
        }
    }
}

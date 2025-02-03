using UnityEngine;

namespace Game.Slot
{
    [CreateAssetMenu(fileName = "SymbolData", menuName = "Scriptable Objects/SymbolData")]
    public class SymbolData : ScriptableObject
    {
        [SerializeField] private int _ID;
        [SerializeField] private Sprite _iconSpr;

        public int ID { get { return _ID; } }
        public Sprite Icon { get { return _iconSpr; } }
    }
}

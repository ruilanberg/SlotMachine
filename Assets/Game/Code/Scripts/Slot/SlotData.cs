using UnityEngine;

namespace Game.Slot
{
    [CreateAssetMenu(fileName = "SlotData", menuName = "Scriptable Objects/SlotData")]
    public class SlotData : ScriptableObject
    {
        [SerializeField] private SlotMachine _slotMachinePrefab;

        public SlotMachine SlotMachine { get { return _slotMachinePrefab; } }
    }
}

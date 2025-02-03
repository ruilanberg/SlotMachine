using UnityEngine;
using Zenject;

namespace Game.Slot
{
    public class SlotMachineBuilder
    {
        [Inject] private SlotData _slotData;

        private readonly SlotMachine _machine;
        public SlotMachineBuilder() 
        {
            _machine = GameObject.Instantiate(_slotData.SlotMachine.gameObject).GetComponent<SlotMachine>();
        }
    }
}
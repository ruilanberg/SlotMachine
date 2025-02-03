using Cysharp.Threading.Tasks;
using DG.Tweening;
using System;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

namespace Game.Slot
{

    [RequireComponent(typeof(SymbolPool))]
    public class RowSlot : MonoBehaviour
    {
        [SerializeField] private SymbolSlot _symbolSlotPrefab;
        [Space]
        [SerializeField] private float _offsetPositionSymbols = 0.33f;
        [SerializeField] private int _offsetSlotCutSymbol = 2;

        private float _topTargetPosY;
        private float _downTargetPosY;
        private bool _isSpin = false;
        private bool _showResult = false;

        private SymbolPool _poolSlots;

        private void Awake()
        {
            _poolSlots = GetComponent<SymbolPool>();
            _poolSlots.Init(transform, _symbolSlotPrefab);
        }

        private void Start()
        {
            _topTargetPosY = (_offsetPositionSymbols * _offsetSlotCutSymbol);
            _downTargetPosY = -_topTargetPosY;
        }

        public void CreateFirstRow(params SymbolData[] datas)
        {
            float posY = -(_offsetPositionSymbols * 2f);

            for (int i = 0; i < datas.Length; i++)
            {
                var slot = _poolSlots.Get();

                slot.SetIcon(datas[i].Icon);
                slot.transform.localPosition = new Vector3(0f, posY, 0f);

                posY += _offsetPositionSymbols;
            }
        }

        public void ShowResult(SymbolData[] datas)
        {
            var topSlot = _poolSlots.GetAllActives().Max(s => s.transform.localPosition.y);

            float posY = _offsetPositionSymbols + topSlot;

            for (int i = 0; i < datas.Length; i++)
            {
                var slot = _poolSlots.Get();

                slot.SetIcon(datas[i].Icon);
                slot.transform.localPosition = new Vector3(0f, posY, 0f);

                posY += _offsetPositionSymbols;
            }

            _showResult = true;
        }

        private void Update()
        {
            if (!_isSpin)
                return;

            if(_showResult)
            {
                var topSlotResult = _poolSlots.GetAllActives().OrderByDescending(s => s.transform.localPosition.y).Skip(1).FirstOrDefault();
                Debug.Log($"{topSlotResult} - {_offsetPositionSymbols}");
                if(topSlotResult.transform.localPosition.y <= _offsetPositionSymbols)
                {
                    Debug.Log($"{topSlotResult} - {_offsetPositionSymbols}");

                    _isSpin = false;
                    _showResult = false;

                    return;
                }
            }

            foreach (var slot in _poolSlots.GetAllActives())
            {
                slot.transform.localPosition -= new Vector3(0f, 1.8f * Time.deltaTime, 0f);

                if (slot.transform.localPosition.y <= _downTargetPosY)
                {
                    _poolSlots.Release(slot);

                    SpawnNextSlot();
                }
            }
        }

        public void StartFakeRoll()
        {
            _isSpin = true;
        }

        private void SpawnNextSlot()
        {
            if (_showResult)
                return;

            var topSlot = _poolSlots.GetAllActives().Max(s => s.transform.localPosition.y);
            topSlot += _offsetPositionSymbols;

            var newSlot = _poolSlots.Get();

            newSlot.transform.localPosition = new Vector3(0f, topSlot, 0f);
        }
    }
}

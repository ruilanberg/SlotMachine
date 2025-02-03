using R3;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.Slot
{
    public class SymbolPool : MonoBehaviour
    {
        private List<SymbolSlot> _datas;

        private Transform _parent;
        private SymbolSlot _prefab;

        public void Init(Transform parent, SymbolSlot prefab) 
        {
            _datas = new List<SymbolSlot>();

            _parent = parent;
            _prefab = prefab;
        }

        public SymbolSlot Get()
        {
            var symbol = GetInative();

            if (symbol == null)
            {
                symbol = Create();
            }

            return symbol;
        }

        private SymbolSlot Create()
        {
            SymbolSlot symbol = UnityEngine.GameObject.Instantiate(_prefab.gameObject, _parent).GetComponent<SymbolSlot>();

            //Observable.EveryValueChanged(symbol, x => x.transform.localPosition.y).Where(y => y <= -0.66f).Subscribe(x => Release(symbol));
            symbol.gameObject.SetActive(true);

            _datas.Add(symbol);

            return symbol;
        }

        public List<SymbolSlot> GetAllActives()
        {
            return _datas.Where(d => d.gameObject.activeSelf).ToList();
        }

        private SymbolSlot GetInative()
        {
            if(_datas.Count == 0)
                return null;

            var symbol = _datas.FirstOrDefault(s => !s.gameObject.activeSelf);
            if(symbol != null)
                symbol.gameObject.SetActive(true);

            return symbol;
        }

        public void Release(SymbolSlot symbol)
        {
            symbol.gameObject.SetActive(false);
        }
    }
}

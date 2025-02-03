using UnityEngine;

namespace Game.Slot
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class SymbolSlot : MonoBehaviour
    {
        private SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void SetIcon(Sprite sprite)
        {
            _spriteRenderer.sprite = sprite;
        }
    }
}
using System.Collections.Generic;
using Game.Assignment1;
using UnityEngine;

namespace Game.Unity.Assignment1
{
    [CreateAssetMenu(fileName = NAME, menuName = "RedBoon/Assignment1/" + NAME, order = 0)]
    public class ConfigSO : ScriptableObject
    {
        [Header(header: "Character")]
        [SerializeField]
        private SlotData[] _characterInventory;

        [SerializeField]
        private int _characterMoney;

        [Header(header: "Merchant")]
        [SerializeField]
        private SlotData[] _merchantInventory;

        private const string NAME = nameof(ConfigSO);

        public IList<SlotData> CharacterInventory => _characterInventory;

        public int CharacterMoney => _characterMoney;

        public IList<SlotData> MerchantInventory => _merchantInventory;
    }
}
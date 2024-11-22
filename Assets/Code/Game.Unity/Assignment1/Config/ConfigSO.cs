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
        private Items[] _characterInventory;

        [SerializeField]
        private int _characterMoney;

        [Header(header: "Merchant")]
        [SerializeField]
        private Items[] _merchantInventory;

        [SerializeField]
        private ItemToPrice[] _price;

        [SerializeField]
        private float _sellPriceMultiplier = 0.9f;

        private const string NAME = nameof(ConfigSO);

        public IList<Items> CharacterInventory => _characterInventory;

        public int CharacterMoney => _characterMoney;

        public IList<Items> MerchantInventory => _merchantInventory;
    }
}
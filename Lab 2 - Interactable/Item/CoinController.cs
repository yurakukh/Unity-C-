using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Item
{
    class CoinController : BalanceChangingItemController
    {
        private int Value { get; set; }

        public CoinController(string name, int value)
        {
            this.Name = name;
            this.Type = ItemType.BalanceChanger;
            this.Description = "Adds money to player`s balance";
            this.Value = value;
        }
    }
}

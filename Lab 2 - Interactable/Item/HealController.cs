using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Item
{
    class HealController : ItemBaseController
    {
        private int HealValue { get; set; }

        public HealController(string name, int healValue)
        {
            this.Name = name;
            this.HealValue = healValue;
            this.Type = ItemType.HPHealer;
            this.Description = "Heals player {value} HP";
        }

        public void Heal()
        {
            //player HP += HealValue;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.NPC
{
    class HorseController : AnimalBaseController
    {
        private int Energy { get; set; }

        public HorseController(int energy)
        {
            this.Name = "Horse";
            this.Energy = energy;
        }

        protected override void Move()
        {
            DriveHorseback();
        }

        private void DriveHorseback()
        {
            //player can use horses to drive
        }
    }
}

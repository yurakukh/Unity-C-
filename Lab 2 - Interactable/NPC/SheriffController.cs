using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.NPC
{
    class SheriffController : NPCBaseController
    {
        protected int HP { get; set; }
        protected float Damage { get; set; }

        public SheriffController(string name, int hp, float damage)
        {
            this.Name = name;
            this.Replicas = new List<string> { "Hey, buddy, where are you going to?", "Stop or I will shoot" };
            this.HP = hp;
            this.Damage = damage;
        }

        protected override void Move()
        {
            base.Move();
            //he is moving around and checking if everything is OK
        }

        public void Arrest()
        {
            //arrests NPC or player for illegal actions
        }

    }
}

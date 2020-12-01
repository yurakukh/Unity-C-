using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.NPC
{
    class DogController : AnimalBaseController
    {
        public DogController()
        {
            this.Name = "Dog";
            this.Replicas = new List<string> { "Gav", "Gav" };//for real dog here will be added sound effects I hope
        }

        protected override void Talk()
        {
            Bark();
        }

        private void Bark()
        {
            //make noise
        }


    }
}

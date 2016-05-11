using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyGame.Models
{
    public class Skill
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int DemageSkill { get; set; }
        public int Cooldown { get; set; }
        public CrowdControl? CrowdControl { get; set; }
        public string Description { get; set; }

        public virtual Hero Hero { get; set; }
        public virtual Monster Monster { get; set; }

    }
}
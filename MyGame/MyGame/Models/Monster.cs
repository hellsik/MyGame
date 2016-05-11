using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyGame.Models
{
    public class Monster
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Strength { get; set; }
        public int Intelligence { get; set; }
        public int Dexterity { get; set; }

        public virtual ICollection<Skill> Skills { get; set; }
    }
}
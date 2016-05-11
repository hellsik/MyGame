using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MyGame.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyGame.DAL
{
    public class MyGameInitializer : DropCreateDatabaseIfModelChanges<MyGameContext>
    {
        protected override void Seed(MyGameContext context)
        {

            var heros = new List<Hero>
            {
                new Hero { Name = "Hells", Class = Class.Łucznik , Strength = 20, Dexterity = 50, Intelligence = 15 },
                new Hero { Name = "Roger", Class = Class.Wojownik , Strength = 60, Dexterity = 15, Intelligence = 15 },
                new Hero { Name = "Merlin", Class = Class.Mag , Strength = 15, Dexterity = 15, Intelligence = 70 },
            };
            heros.ForEach(p => context.Heros.Add(p));
            context.SaveChanges();

            var monsters = new List<Monster>
            {
                new Monster { Name = "Smok", Strength = 120, Dexterity = 80, Intelligence = 80 },
                new Monster { Name = "Rekin", Strength = 160, Dexterity = 65, Intelligence = 15 },
                new Monster { Name = "Milerton", Strength = 115, Dexterity = 115, Intelligence = 170 },
            };
            monsters.ForEach(p => context.Monsters.Add(p));
            context.SaveChanges();

            var skills = new List<Skill>
            {
                new Skill { Name = "Strzał w pięte", DemageSkill = 20, Cooldown = 5, CrowdControl = CrowdControl.Slowing, Description = "Bohater strzela strzałą w stope przeciwnika spowalniając go o 20% na 3 sekundy", Hero = heros[0] },
                new Skill { Name = "Walniecie", DemageSkill = 60, Cooldown = 11, CrowdControl = CrowdControl.Overthrow, Description = "Bohater uderza w ziemie młotem i zadaje obrażenia obszarowe, powalając przeciwników na ziemie na 2 sekundy", Hero = heros[1] },
                new Skill { Name = "Lodowy strzał", DemageSkill = 40, Cooldown = 8, CrowdControl = CrowdControl.Stun, Description = "Bohater strzela lodowym pociskiem ogluszając wrogie cele na 4 sekundy ", Hero = heros[2] },

                new Skill { Name = "Ognisty oddech", DemageSkill = 100, Cooldown = 12, CrowdControl = CrowdControl.Slowing, Description = "Smok zionie ogniem, zdając obrażenia obszarowe w stożku spowalniając bohatera o 50% na 5 sekund", Monster = monsters[0] },
                new Skill { Name = "Skok z ląd", DemageSkill = 130, Cooldown = 15, CrowdControl = CrowdControl.Overthrow, Description = "Rekin wyskakuje z wody na ląd uderzając w ziemie, zadaje obrażenia obszarowe obalając bohatera na 5 sekund", Monster = monsters[1] },
                new Skill { Name = "Strzał z nieba", DemageSkill = 180, Cooldown = 20, CrowdControl = CrowdControl.Stun, Description = "Milerton przywołuje moc błyskawicy na wybranym obszarze, zadając obrażenia obszarowe o dużym zasięgu, ogłuszając bohatera znajdującego się w obszarze działania umiejętności na 8 sekund ", Monster = monsters[2] }

            };
            skills.ForEach(p => context.Skills.Add(p));
            context.SaveChanges();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));

            roleManager.Create(new IdentityRole("Admin"));

            var user = new ApplicationUser { UserName = "jakis@mail.com" };
            string passwor = "Moje123@";

            userManager.Create(user, passwor);

            userManager.AddToRole(user.Id, "Admin");
        }
    }
}
namespace Heroes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class HeroRepository
    {
        private List<Hero> data;

        public HeroRepository()
        {
            this.data = new List<Hero>();
        }

        public int Count { get { return this.data.Count; } set { } }

        public void Add(Hero hero)
        {
            this.data.Add(hero);
        }

        public void Remove(string name)
        {
            Hero currentHero = data.FirstOrDefault(x => x.Name == name);
            this.data.Remove(currentHero);
        }

        public Hero GetHeroWithHighestStrength()
        {
            return this.data.OrderByDescending(x => x.Item.Strength).FirstOrDefault();
        }

        public Hero GetHeroWithHighestAbility()
        {
            return this.data.OrderByDescending(x => x.Item.Ability).FirstOrDefault();
        }

        public Hero GetHeroWithHighestIntelligence()
        {
            return this.data.OrderByDescending(x => x.Item.Intelligence).FirstOrDefault();

        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();


            for (int i = 0; i < data.Count; i++)
            {
                if (i != data.Count - 1)
                {
                    stringBuilder.AppendLine(data[i].ToString());
                }
                else
                {
                    stringBuilder.Append(data[i].ToString());
                }
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}

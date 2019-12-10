using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P05_GreedyTimes
{
    public class TresureBag
    {
        public TresureBag(long capacity)
        {
            this.Gems = new List<Gem>();
            this.Money = new List<Cash>();
            this.Capacity = capacity;
        }
        public long Capacity { get; set; }
        public long Gold { get; set; }
        public List<Gem> Gems { get; set; }
        public List<Cash> Money { get; set; }

        public void AddGold(long gold)
        {
            if (this.Capacity >= gold)
            {
                this.Gold += gold;
                this.Capacity -= gold;
            }
        }

        public void AddGem(Gem gem)
        {
            if (this.Capacity >= gem.Amount &&
                this.Gems.Sum(g => g.Amount) + gem.Amount <= this.Gold)
            {
                if (!this.Gems.Any(g => g.Name == gem.Name))
                {
                    this.Gems.Add(gem);
                }
                else
                {
                    this.Gems.FirstOrDefault(g => g.Name == gem.Name).Amount += gem.Amount;
                }
                this.Capacity -= gem.Amount;
            }
        }

        public void AddCash(Cash cash)
        {
            if (this.Capacity >= cash.Amount &&
                this.Money.Sum(g => g.Amount) + cash.Amount <= this.Gems.Sum(g => g.Amount))
            {
                if (!this.Money.Any(c => c.Name == cash.Name))
                {
                    this.Money.Add(cash);
                }
                else
                {
                    this.Money.FirstOrDefault(c => c.Name == cash.Name).Amount += cash.Amount;
                }
                this.Capacity -= cash.Amount;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            if (this.Gold > 0)
            {
                sb.AppendLine($"<Gold> ${this.Gold}");
                sb.AppendLine($"##Gold - {this.Gold}");
            }

            if (this.Gems.Sum(a => a.Amount) > 0)
            {
                sb.AppendLine($"<Gem> ${this.Gems.Sum(a => a.Amount)}");
                foreach (var gem in this.Gems.OrderByDescending(x => x.Name).ThenBy(x => x.Amount))
                {
                    sb.AppendLine($"##{gem.Name} - {gem.Amount}");
                }
            }

            if (this.Money.Sum(c => c.Amount) > 0)
            {
                sb.AppendLine($"<Cash> ${this.Money.Sum(a => a.Amount)}");
                foreach (var cash in this.Money.OrderByDescending(x => x.Name).ThenBy(x => x.Amount))
                {
                    sb.AppendLine($"##{cash.Name} - {cash.Amount}");
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}

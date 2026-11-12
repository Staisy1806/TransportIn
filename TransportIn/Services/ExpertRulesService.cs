
using Microsoft.EntityFrameworkCore;
using TransportIn.Data;

namespace TransportIn.Services
{
    public class ExpertRule
    {
        public int Id { get; set; }
        public string ThreatType { get; set; } = "";
        public string Condition { get; set; } = "";
        public string ActionRecommendation { get; set; } = "";
        public string Priority { get; set; } = "Високий";
    }

    public class ExpertRulesService
    {
        private readonly AppDbContext _context;

        public ExpertRulesService(AppDbContext context)
        {
            _context = context;
        }

        public event Action? OnChange;

        public List<ExpertRule> GetAllRules()
        {
            return _context.ExpertRules
                .AsNoTracking()
                .OrderBy(r => r.Id)
                .ToList();
        }

        public void AddRule(ExpertRule rule)
        {
            _context.ExpertRules.Add(rule);
            _context.SaveChanges();

            NotifyStateChanged();
        }

        public void DeleteRule(int id)
        {
            var rule = _context.ExpertRules.Find(id);

            if (rule != null)
            {
                _context.ExpertRules.Remove(rule);
                _context.SaveChanges();

                NotifyStateChanged();
            }
        }

        public string EvaluateThreat(string threatType, bool isInTransit)
        {
            var rule = _context.ExpertRules
                .AsNoTracking()
                .FirstOrDefault(r =>
                    r.ThreatType.Contains(
                        threatType,
                        StringComparison.OrdinalIgnoreCase));

            if (rule != null)
            {
                return $"[Рекомендація експертної системи]: {rule.ActionRecommendation} (Пріоритет: {rule.Priority})";
            }

            return "Дійте за стандартним протоколом безпеки.";
        }

        private void NotifyStateChanged()
        {
            OnChange?.Invoke();
        }
    }
}

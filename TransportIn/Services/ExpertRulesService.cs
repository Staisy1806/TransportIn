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
        private List<ExpertRule> rules = new()
        {
            new ExpertRule
            {
                Id = 1,
                ThreatType = "Повітряна тривога",
                Condition = "Автомобіль в дорозі",
                ActionRecommendation = "Негайна зупинка, пошук безпечного місця або найближчої стоянки.",
                Priority = "Критичний"
            },
            new ExpertRule
            {
                Id = 2,
                ThreatType = "Аномальна спека (>+35°C)",
                Condition = "Вага понад 24 тонни в денний час (10:00 - 22:00)",
                ActionRecommendation = "Діє обмеження Укравтодору. Перенесення руху на нічний час, відстій на TIR-парковках.",
                Priority = "Високий"
            },
            new ExpertRule
            {
                Id = 3,
                ThreatType = "Ожеледиця",
                Condition = "Зниження коефіцієнта зчеплення",
                ActionRecommendation = "Зменшення швидкості руху на 30–50%, підвищена дистанція.",
                Priority = "Середній"
            },
            new ExpertRule
            {
                Id = 4,
                ThreatType = "Закриття мостів (Правий / Лівий берег)",
                Condition = "Критична інфраструктурна подія",
                ActionRecommendation = "Блокування автоматичної побудови маршруту через річку. Очікування відновлення руху.",
                Priority = "Критичний"
            }
        };

        public event Action? OnChange;

        public List<ExpertRule> GetAllRules() => rules;

        public void AddRule(ExpertRule rule)
        {
            rule.Id = rules.Count > 0 ? rules.Max(r => r.Id) + 1 : 1;
            rules.Add(rule);
            NotifyStateChanged();
        }

        public void DeleteRule(int id)
        {
            var rule = rules.FirstOrDefault(r => r.Id == id);
            if (rule != null)
            {
                rules.Remove(rule);
                NotifyStateChanged();
            }
        }

        public string EvaluateThreat(string threatType, bool isInTransit)
        {
            var rule = rules.FirstOrDefault(r => r.ThreatType.Contains(threatType, StringComparison.OrdinalIgnoreCase));
            if (rule != null)
            {
                return $"[Рекомендація експертної системи]: {rule.ActionRecommendation} (Пріоритет: {rule.Priority})";
            }
            return "Дійте за стандартним протоколом безпеки.";
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
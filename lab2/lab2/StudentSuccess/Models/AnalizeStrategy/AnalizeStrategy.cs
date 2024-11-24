namespace StudentSuccess.Models.AnalizeStrategy
{
    enum Attribute
    {
        Faculty,
        Department,
        Discipline,
        Student
    }
    interface IAnalizeStrategy
    {
        public string Search(string filaPath, Attribute attribute, string value);

    }

    class AnalizeContext
    {
        private IAnalizeStrategy strategy;

        public AnalizeContext() { }

        public AnalizeContext(IAnalizeStrategy strategy)
        {
            this.strategy = strategy;
        }

        public void SetStrategy(IAnalizeStrategy strategy)
        {
            this.strategy = strategy;
        }

        public string Search(string filePath, Attribute attribute, string value)
        {
            if (strategy != null) {
                var result = strategy.Search(filePath, attribute, value);
                return result;
            }
            return "Strategy not set";
        }
    }
}

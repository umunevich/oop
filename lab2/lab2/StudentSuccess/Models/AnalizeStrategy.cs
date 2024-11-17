namespace StudentSuccess.Models {
    enum Attribute {
        Faculty,
        Department,
        Discipline,
        Student
    }
    interface IAnalizeStrategy {
        public string Search(string filaPath, Attribute attribute, string value);

    }

    class AnalizeContext {
        private IAnalizeStrategy strategy;

        public AnalizeContext() { }

        public AnalizeContext(IAnalizeStrategy strategy) {
            this.strategy = strategy;
        }

        public void SetStrategy(IAnalizeStrategy strategy) {
            this.strategy = strategy;
        }

        public string Search(string filePath, Attribute attribute, string value) {
            var resault = this.strategy.Search(filePath, attribute, value);
            return resault;
        }
    }
}

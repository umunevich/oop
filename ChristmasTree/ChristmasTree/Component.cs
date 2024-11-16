namespace ChristmasTree {
    abstract class TreeComponent {
        public abstract void Decorate();
    }

    abstract class TreeDecorator : TreeComponent {
        protected TreeComponent tree;

        public void SetComponent(TreeComponent tree) {
            this.tree = tree;
        }

        public override void Decorate() {
            if (tree != null) {
                tree.Decorate();
            }
        }
    }

    class ChristmasTreeComponent : TreeComponent {
        public override void Decorate() {
            Console.WriteLine("Just cutted down tree. ");
        }
    }

    class LightDecorator : TreeDecorator {
        public override void Decorate() { 
            base.Decorate();
            Console.WriteLine("Adorned with lights. ");
        }
    }

    class BaubleDecorator : TreeDecorator {
        private string decoration;

        public override void Decorate() {
            base.Decorate();
            decoration = "Bauble";
            Console.WriteLine($"Adorned with {decoration}");
        }
    }

    class StarDecorator : TreeDecorator {
        private string decoration;

        public override void Decorate() {
            base.Decorate();
            decoration = "Star";
            Console.WriteLine($"Adorned with {decoration}");
        }
    }
}

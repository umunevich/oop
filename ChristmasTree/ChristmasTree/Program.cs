using ChristmasTree;

class Program {
    public static void Main(String[] args) {
        ChristmasTreeComponent tree = new ChristmasTreeComponent();
        LightDecorator lights = new LightDecorator();
        BaubleDecorator baulbs = new BaubleDecorator();
        StarDecorator star = new StarDecorator();

        tree.Decorate();
        Console.WriteLine();

        lights.SetComponent(tree);
        lights.Decorate();
        Console.WriteLine();

        baulbs.SetComponent(tree);
        baulbs.Decorate();
        Console.WriteLine();

        star.SetComponent(baulbs);
        star.Decorate(); 
        Console.WriteLine();
    }
}
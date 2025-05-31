public class Burger
{
    public List<Topping> toppings { get; set; } = new List<Topping>();
    public Burger()
    {
        Topping salad = new Topping("salad");
        salad.quantity = 5;
        // salad.price = 20;
        Topping beef = new Topping("beef");
        Topping cheese = new Topping("cheese");
        toppings.Add(salad);
        toppings.Add(cheese);
        toppings.Add(beef);
    }
}
public class Topping
{
    public string name { get; set; } = "";
    public int price { get; set; } = 1000;
    public int quantity { get; set; } = 1;
    public Topping(string inputName="")
    {
        name = inputName;
    }
}
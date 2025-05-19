namespace dotnet03_web_blazor.Data;
public static class DbCarProducts
{
    public static List<ProductCardVM> lstProduct = new List<ProductCardVM>(){
      new ProductCardVM() {
        id=1,name="Black car",price=1000,image = "/products/black-car.jpg"
      },
      new ProductCardVM() {
        id=2,name="Red car",price=2000,image = "/products/red-car.jpg"
      },
      new ProductCardVM() {
        id=3,name="Silver car",price=3000,image = "/products/silver-car.jpg"
      },
      new ProductCardVM() {
        id=4,name="Silver car",price=4000,image = "/products/steel-car.jpg"
      }
    };
}
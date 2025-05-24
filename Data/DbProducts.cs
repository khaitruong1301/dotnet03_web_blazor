namespace dotnet03_web_blazor.Data;

public static class DbProducts
{
  
  public static List<ProductCardVM> lstProduct = new List<ProductCardVM>(){
      new ProductCardVM() {
        id=1,name="Iphone",price=1000,image = "https://picsum.photos/id/1/200/200"
      },
      new ProductCardVM() {
        id=2,name="Galaxy note 25",price=2000,image = "https://picsum.photos/id/2/200/200"
      },
      new ProductCardVM() {
        id=3,name="Xiaomi mi 20",price=3000,image = "https://picsum.photos/id/3/200/200"
      }
    };
}




// See https://aka.ms/new-console-template for more information
using API_EF_Hash_Token.DAL.Domain;
using API_EF_Hash_Token.DAL.Entities;
using API_EF_Hash_Token.DAL.Methods;
using API_EF_Hash_Token.Test.Models;

Console.WriteLine("Hello, World!");
DataContext dataContext = new DataContext();
string pepper = "cr2bPd0Cl4vGhjBMhqVWApY651YzyJB0\r\n";
int iteration = 3;
string email = "nico.daddabbo7100@gmail.com";
string password = "@Test1234=";
#region Test Register
//try
//{
//    UserEntity user = new UserEntity()
//    {
//        FirstName = "D",
//        LastName = "Nico",
//        PhoneNumber = 491410952,
//        Email = "nico.daddabbo7100@gmail.com",
//        PasswordSalt = PasswordHasher.GenerateSalt(),
//    };

//    user.PasswordHash = PasswordHasher.ComputeHash(password, user.PasswordSalt, pepper, iteration);
//    dataContext.Add(user);
//    dataContext.SaveChanges();
//    Console.WriteLine("coucou");

//}
//catch (Exception ex)
//{

//    Console.WriteLine(ex.InnerException.Message);
//}

#endregion

#region Test Login

//try
//{
//    var user = dataContext.Users.FirstOrDefault(u => u.Email == email);
//    if (user is null)
//        throw new Exception("Username or password did not match.");
//    string passwordHash = PasswordHasher.ComputeHash(password, user.PasswordSalt, pepper, iteration);

//    if (user.PasswordHash != passwordHash)
//        throw new Exception("Username or password did not match.");

//    Console.WriteLine("Ok");
//}
//catch (Exception ex)
//{

//    Console.WriteLine(ex.Message);
//}

#endregion

#region Test Create Adress

//try
//{
//    AdressEntity adress = new AdressEntity()
//    {
//        CityName = "Mons",
//        Street = "Rue quelconque",
//        Number = 36,
//        Country = "Belgique",
//    };

//    dataContext.Adresses.Add(adress);

//    UserAdressEntity userAdress = new UserAdressEntity()
//    {
//        UserId = 6,
//        Adress = adress,
//    };
//    dataContext.UserAdress.Add(userAdress);
//    dataContext.SaveChanges();
//    Console.WriteLine("OK");
//}
//catch (Exception ex)
//{

//    Console.WriteLine(ex.InnerException.Message);
//}



#endregion

#region Test Create Product

//try
//{
//    ProductEntity product = new ProductEntity()
//    {
//        ModelName = "Duramo 10",
//        Brand = "Adidas",
//        Description = "Chassure pour femme, course",
//        Sexe = "Femme",
//        Price = 45.80M
//    };
//    dataContext.Products.Add(product);
//    dataContext.SaveChanges();
//    Console.WriteLine("OK");
//}
//catch (Exception ex)
//{

//    Console.WriteLine(ex.InnerException.Message);
//}

#endregion

#region Test Create Order et Create OrderProduct

//try
//{
//	OrderEntity order = new OrderEntity() {
//		UserId = 6,
//		OrderDate = DateTime.Now,
//	};
//	dataContext.Orders.Add(order);
//	ProductOrderEntity productOrder = new ProductOrderEntity() {

//		Order = order,
//		ProductId = 1,
//		Quantity = 2,
//		Price = 3.99M
//	};
//	order.TotalPrice = 7.01M;
//	dataContext.ProductOrder.Add(productOrder);
//	dataContext.SaveChanges();
//    Console.WriteLine("OK");

//}
//catch (Exception ex)
//{

//    Console.WriteLine(ex.InnerException.Message);
//}

#endregion

#region Test Full Order

// Ce que l'on reçoit du front
List<OrderProduct> userOrder = new List<OrderProduct>() { new OrderProduct() { ProductId = 1, Price = 129.99M, Quantity = 2 }, new OrderProduct() { ProductId = 2, Price = 85.99M, Quantity = 1 } };

try
{
    // Création de la command
    OrderEntity orderEntity = new OrderEntity();
    // Ajout de l'user id
    orderEntity.UserId = 6;
    // Ajout de la date
    orderEntity.OrderDate = DateTime.Now;

    // Pour tous les produits de la commande, on créé un ProductOrder
    foreach (var product in userOrder)
    {
        ProductOrderEntity productOrderEntity = new ProductOrderEntity() 
        { 
            // On y associe la commande, le produit, la quantité et le prix total (quantity*price)
            Order = orderEntity,
            ProductId = product.ProductId,
            Quantity = product.Quantity,
            Price = product.Price * product.Quantity,
        
        };
        dataContext.ProductOrder.Add(productOrderEntity);
        // On ajoute le prix total (quantity*price) au prix total de la commande
        orderEntity.TotalPrice += productOrderEntity.Price;
    }

    dataContext.Orders.Add(orderEntity);
    dataContext.SaveChanges();
    Console.WriteLine("OK");


}
catch (Exception ex)
{

    Console.WriteLine(ex.Message);
}
#endregion



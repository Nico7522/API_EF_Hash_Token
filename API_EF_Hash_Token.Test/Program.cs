﻿// See https://aka.ms/new-console-template for more information
using API_EF_Hash_Token.BLL.IInterfaces;
using API_EF_Hash_Token.BLL.Models;
using API_EF_Hash_Token.BLL.Services;
using API_EF_Hash_Token.DAL.Domain;
using API_EF_Hash_Token.DAL.Entities;
using API_EF_Hash_Token.DAL.Interfaces;
using API_EF_Hash_Token.DAL.Methods;
using API_EF_Hash_Token.DAL.Repositories;
using API_EF_Hash_Token.Test.Models;
using Microsoft.Extensions.Configuration;

Console.WriteLine("Hello, World!");
DataContext dataContext = new DataContext();
string pepper = "cr2bPd0Cl4vGhjBMhqVWApY651YzyJB0\r\n";
int iteration = 3;
string email = "nico.daddabbo2000@gmail.com";
string password = "@Test1234=";

// TEST direct
#region Test Register
//try
//{
//    UserEntity user = new UserEntity()
//    {
//        FirstName = "D",
//        LastName = "Nico",
//        PhoneNumber = 491410952,
//        Email = "nico.daddabbo2000@gmail.com",
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

#region Test Create Category

//try
//{
//    CategoryEntity categoryEntity = new CategoryEntity()
//    {
//        CategoryName = "Mocassin",
//        Description = "description",
//    };

//    dataContext.Categories.Add(categoryEntity);
//    dataContext.SaveChanges();
//    Console.WriteLine("ok");
//}
//catch (Exception ex)
//{

//    Console.WriteLine(ex.InnerException.Message);
//}


#endregion

#region Test Liaison categorie et chaussure


//try
//{
//ProductCategoryEntity categoryEntity = new ProductCategoryEntity() { 
//    ProductId = 1,
//    CategoryId = 2
//};
//dataContext.ProductCategory.Add(categoryEntity);
//dataContext.SaveChanges();
//Console.WriteLine("OK");

//}
//catch (Exception ex)
//{

//    Console.WriteLine(ex.InnerException.Message);
//}

#endregion

#region Test ajout Size

//try
//{
//    SizeEntity sizeEntity = new SizeEntity()
//    {
//        Size = 38,
//    };

//    dataContext.Sizes.Add(sizeEntity);
//    dataContext.SaveChanges();
//    Console.WriteLine("OK");



//}
//catch (Exception ex)
//{

//    Console.WriteLine(ex.InnerException.Message);
//}



#endregion

#region Test liaison size et product


//try
//{
//SizeProductEntity entity = new SizeProductEntity()
//{
//    ProductId = 1,
//    SizeId = 2,
//    Stock = 20
//};
//    dataContext.SizeProduct.Add(entity);
//    dataContext.SaveChanges();
//    Console.WriteLine("OK"); ;
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

//// Ce que l'on reçoit du front
//List<OrderProduct> userOrder = new List<OrderProduct>() { new OrderProduct() { ProductId = 1, Price = 129.99M, Quantity = 2 }, new OrderProduct() { ProductId = 2, Price = 85.99M, Quantity = 1 } };

//try
//{
//    // Création de la command
//    OrderEntity orderEntity = new OrderEntity();
//    // Ajout de l'user id
//    orderEntity.UserId = 6;
//    // Ajout de la date
//    orderEntity.OrderDate = DateTime.Now;

//    // Pour tous les produits de la commande, on créé un ProductOrder
//    foreach (var product in userOrder)
//    {
//        ProductOrderEntity productOrderEntity = new ProductOrderEntity() 
//        { 
//            // On y associe la commande, le produit, la quantité et le prix total (quantity*price)
//            Order = orderEntity,
//            ProductId = product.ProductId,
//            Quantity = product.Quantity,
//            Price = product.Price * product.Quantity,

//        };
//        dataContext.ProductOrder.Add(productOrderEntity);
//        // On ajoute le prix total (quantity*price) au prix total de la commande
//        orderEntity.TotalPrice += productOrderEntity.Price;
//    }

//    dataContext.Orders.Add(orderEntity);
//    dataContext.SaveChanges();
//    Console.WriteLine("OK");


//}
//catch (Exception ex)
//{

//    Console.WriteLine(ex.Message);
//}
#endregion



// Pour utiliser appsetting.json
IConfiguration configuration = new ConfigurationBuilder()
 .SetBasePath(Directory.GetCurrentDirectory())
 .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
 .AddEnvironmentVariables()
 .AddCommandLine(args)
 .Build();

// TEST Repositories DAL
IUserRepository userRepository = new UserRepository(dataContext, configuration);

#region Test GetAll Users

//try
//{
//    IEnumerable<UserEntity> users = await  userRepository.GetAll();

//    foreach (var item in users)
//    {
//        Console.WriteLine(item.FirstName);
//    }
//}
//catch (Exception ex)
//{

//    Console.WriteLine(ex.Message);
//}

#endregion

#region Test GetById User


//try
//{
//    UserEntity? user = await userRepository.GetById(6);
//    Console.WriteLine(user?.FirstName);

//}
//catch (Exception ex)
//{

//    Console.WriteLine(ex.Message);
//}


#endregion

#region Test GetByEmail User

//try
//{
//	UserEntity? user = await userRepository.GetByEmail("nico.daddabbo7100@gmail.com");

//	if (user is null)
//		throw new Exception();

//    Console.WriteLine(user.LastName);
//}
//catch (Exception ex)
//{

//    Console.WriteLine(ex.Message);
//}

#endregion

#region Test Update User

//try
//{
//	UserEntity? user = await userRepository.GetById(6);
//	user.FirstName = "D'Ad";
//	UserEntity updatedUser = await userRepository.Update(user, 6);
//    Console.WriteLine("OK");



//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);

//}



#endregion

#region Test Delete User

//try
//{
//	UserEntity? userToDelete = await userRepository.GetById(11);

//    if (userToDelete is null)
//        throw new Exception();

//	UserEntity deletedUser = await userRepository.Delete(userToDelete);

//    Console.WriteLine(deletedUser.FirstName);

//}
//catch (Exception ex)
//{

//    Console.WriteLine(ex.Message); ;
//}
#endregion

#region Test Register User

//UserEntity user = new UserEntity()
//{
//    FirstName = "DD",
//    LastName = "Nicolas",
//    Email = "nico.daddabbo2000@gmail.com",
//    Password = "@Test1234=",
//    PhoneNumber = 0491410953,

//};

//try
//{
//    UserEntity? createdUser = await userRepository.Register(user);
//    Console.WriteLine(createdUser?.FirstName);
//}
//catch (Exception ex)
//{

//    Console.WriteLine(ex.Message);
//}
#endregion

#region Test Login User

//try
//{
//    UserEntity? user = await userRepository.Login("nico.daddabbo2000@gmail.com", "@Test1234=");
//    if (user is null)
//        throw new Exception();

//    Console.WriteLine(user.LastName);
//}
//catch (Exception ex)
//{

//    Console.WriteLine(ex.Message);
//}

#endregion

#region TestUpdateEmail User

//try
//{
//	bool isUpdated = await userRepository.UpdateEmail("dokkannico75@gmail.com",12);

//	if (!isUpdated) throw new Exception();

//    Console.WriteLine("ok");
//}
//catch (Exception ex)
//{

//    Console.WriteLine(ex.InnerException.Message); 
//}

#endregion


// TEST Services BLL
IAuthRepository authRepository = new UserRepository(dataContext, configuration);
IUserService userService = new UserService(userRepository);
IAuthService authService = new AuthService(authRepository, userRepository);


#region Test GetAll Users

//try
//{
//   IEnumerable<UserModel> users = await userService.GetAll();

//    foreach (var item in users)
//    {
//        Console.WriteLine(item.FirstName);
//    }
//}
//catch (Exception ex)
//{

//    Console.WriteLine(ex.Message);
//}

#endregion

#region Test GetById User

//try
//{
//    UserModel? user = await userService.GetById(12);

//    if (user is null) throw new Exception();

//    Console.WriteLine(user.FirstName);
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message); 
//}
#endregion

#region Test GetByEmail User

//try
//{
//	UserModel? user = await userService.GetByEmail("nico.daddabbo2000@gmail.com");
//    if (user is null) throw new Exception();

//    Console.WriteLine(user.FirstName);
//}
//catch (Exception ex)
//{

//    Console.WriteLine(ex.Message);
//}

#endregion

#region Test Update User


//try
//{
//    UserModel? userToUpdate = await userService.GetById(12);
//    userToUpdate.FirstName = "jean-jacque";
//    userToUpdate.LastName = "ddqdsq";

//    if (userToUpdate is null)
//        throw new Exception();

//    UserModel? updatedUser = await userService.Update(userToUpdate, 12);

//    Console.WriteLine(updatedUser.FirstName);
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}

#endregion

#region Test Delete user

//try
//{
//	UserModel? deletedUser = await userService.Delete(13);
//    Console.WriteLine(deletedUser.FirstName);
//}
//catch (Exception ex)
//{

//    Console.WriteLine(ex.Message);
//}

#endregion

#region Test Register User

//try
//{
//	UserModel user = new UserModel("test", "dqsd", email, 0491542362, password);

//	UserModel createdUser = await authService.Register(user);

//	if (createdUser is null)
//		throw new Exception();
//}
//catch (Exception ex)
//{

//    Console.WriteLine(ex.Message);
//}

#endregion

#region Test Login User

//try
//{
//	UserModel user = await authService.Login(email, "rfds");

//	if (user is null) throw new Exception();

//    Console.WriteLine(user.FirstName + user.LastName);

//}
//catch (Exception ex)
//{

//    Console.WriteLine(ex.Message);
//}

#endregion

#region Test UpdateEmail User

//try
//{
//	bool isUpdated = await authService.UpdateEmail("nico.daddabbo7100@gmail.com", 14);
//	if (!isUpdated) throw new Exception();

//    Console.WriteLine("ok");
//}
//catch (Exception ex)
//{

//    Console.WriteLine(ex);
//}

#endregion
// See https://aka.ms/new-console-template for more information
using API_EF_Hash_Token.BLL.IInterfaces;
using API_EF_Hash_Token.BLL.Models;
using API_EF_Hash_Token.BLL.Services;
using API_EF_Hash_Token.DAL.Domain;
using API_EF_Hash_Token.DAL.Entities;
using API_EF_Hash_Token.DAL.Interfaces;
using API_EF_Hash_Token.DAL.Methods;
using API_EF_Hash_Token.DAL.Repositories;
using API_EF_Hash_Token.Test.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Drawing.Design;

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
//	OrderEntity order = new OrderEntity()
//	{
//		UserId = 12,
//		OrderDate = DateTime.Now,
//	};
//	dataContext.Orders.Add(order);
//	ProductOrderEntity productOrder = new ProductOrderEntity()
//	{

//		Order = order,
//		ProductId = 5,
//		Quantity = 2,
//		Price = 154.44M
//	};
//	order.TotalPrice = 154.44M;
//	dataContext.ProductOrder.Add(productOrder);
//	dataContext.SaveChanges();
//	Console.WriteLine("OK");

//}
//catch (Exception ex)
//{

//	Console.WriteLine(ex.InnerException.Message);
//}

#endregion

#region Test Full Order

// Ce que l'on reçoit du front
//List<OrderProduct> userOrder = new List<OrderProduct>() { new OrderProduct() { ProductId = 20, Price = 50.99M, Quantity = 2 }, new OrderProduct() { ProductId = 22, Price = 50.99M, Quantity = 1 } };

//try
//{
//    // Création de la command
//    OrderEntity orderEntity = new OrderEntity();
//    // Ajout de l'user id
//    orderEntity.UserId = 12;
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

//    Console.WriteLine(ex.InnerException.Message);
//}
#endregion

#region Test GetAllUsersWithAdresses

//var users = dataContext.Users.Join(dataContext.UserAdress, u => u.UserId, ua => ua.UserId, (u ,ua) => new {u, ua.Adress.CityName});
//var usersWithAddresses = dataContext.Users
//    .Select(user => new
//    {
//        User = user,
//        Addresses = user.Addresses.Select(ua => ua.Adress).ToList()
//    })
//    .ToList();

//foreach (var userWithAddresses in usersWithAddresses)
//{
//    Console.WriteLine($"User: {userWithAddresses.User.FirstName} {userWithAddresses.User.LastName}");

//    if (userWithAddresses.Addresses.Count > 0)
//    {
//        foreach (var address in userWithAddresses.Addresses)
//        {
//            Console.WriteLine($"Address: {address.CityName}, {address.Country}");
//        }
//    }
//    else
//    {
//        Console.WriteLine("No addresses");
//    }

//    Console.WriteLine(); 
//}


// var test = dataContext.Users
//   .Include(x => x.Addresses) // UserAddresses
//       .ThenInclude(x => x.Adress) // UserAddress.Address
//   .ToList();

//foreach (var item in test)
//{
//    Console.WriteLine(item.LastName);
//    foreach (var adress in item.Addresses)
//    {
//        Console.WriteLine(adress.Adress.Country);
//    }
//}
#endregion

#region Test GallAll Products avec categories et sizes

//try
//{
//	IEnumerable<ProductEntity> products = await dataContext.Products.Include(p => p.Categories).ThenInclude(p => p.Category).Include(p => p.Sizes).ThenInclude(p => p.Size).ToListAsync();
//    foreach (var product in products)
//    {
//        Console.WriteLine(product.ModelName);
//        foreach (var size in product.Sizes)
//        {
//            Console.WriteLine(size.Size.Size);
//            Console.WriteLine(size.Stock);
//        }
//    }

//}
//catch (Exception ex)
//{

//	throw;
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
IAdressRepository adressRepository = new AdressRepository(dataContext);
IProductRepository productRepository = new ProductRepository(dataContext);
ICategoryRepository categoryRepository = new CategoryRepository(dataContext);
ISizeRepository sizeRepository = new SizeRepository(dataContext);
IOrderRepository orderRepository = new OrderRepository(dataContext);


// TEST Users
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

//    UserEntity? user = await userRepository.GetById(20);
//    if (user is null) throw new Exception();

//    Console.WriteLine(user?.FirstName);
//    foreach (var adress in user.Addresses)
//    {
//        Console.WriteLine(adress.Adress.CityName);
//    }

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
//    UserEntity? user = await userRepository.GetById(19);
//    user.FirstName = "D'Adss";
//    UserEntity? updatedUser = await userRepository.Update(user, 19);

//    if (updatedUser is null) throw new Exception();

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

#region Test UpdatePassword User

//try
//{
//    bool isUpdated = await userRepository.UpdatePassword("@TTTTe11z", 14);

//    if (!isUpdated) throw new Exception();

//    Console.WriteLine("ok");
//}
//catch (Exception ex)
//{

//    Console.WriteLine(ex.Message);
//}

#endregion

#region Test ActiveAccount User

//try
//{
//	UserEntity? userAccountToActive = await userRepository.GetById(12);
//	if (userAccountToActive is null) throw new Exception();
//	bool isActivate = await userRepository.ActiveAccount(userAccountToActive);
//	if (!isActivate) throw new Exception();

//    Console.WriteLine("OK");
//}
//catch (Exception ex)
//{

//    Console.WriteLine(ex.Message);
//}
#endregion

// TEST Adresses
#region Test GetAll Adresses

//try
//{
//IEnumerable<AdressEntity> adresses = await adressRepository.GetAll();
//    foreach (var item in adresses)
//    {
//        Console.WriteLine(item.CityName);
//    }
//}
//catch (Exception ex)
//{

//    Console.WriteLine(ex.Message);
//}


#endregion

#region Test GetById Adress

//try
//{
//	AdressEntity? adress = await adressRepository.GetById(16);
//    if (adress is null)
//        throw new Exception();

//    Console.WriteLine(adress.Street);
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);

//}
#endregion

#region Test Insert Adress

//try
//{
//    AdressEntity? insertedAdress = await adressRepository.Insert(new AdressEntity { CityName = "LL", Country = "BE", Number = 25, Street = "AV" });
//    Console.WriteLine("ok");
//}
//catch (Exception ex)
//{

//    Console.WriteLine(ex.InnerException.Message);
//}

#endregion

#region Test Update Adress

//try
//{
//    AdressEntity? adressToUpdate = await adressRepository.GetById(1);
//    adressToUpdate.Street = "rezrzer";
//    AdressEntity? adress = await adressRepository.Update(adressToUpdate, 1);

//    Console.WriteLine(adress.Street);
//}
//catch (Exception ex)
//{

//    Console.WriteLine(ex.Message); 
//}
#endregion

#region Test Delete Adress

//try
//{
//    AdressEntity? deletedAdress = await adressRepository.Delete(2);

//    if (deletedAdress is null) throw new Exception();

//    Console.WriteLine(deletedAdress.Street);
//}
//catch (Exception ex)
//{

//    Console.WriteLine(ex.Message);
//}
#endregion


// TEST Products

#region Test GetAll Products

//try
//{
//	IEnumerable<ProductEntity> products = await productRepository.GetAll();

//    foreach (var product in products)
//    {
//        Console.WriteLine(product.Brand);
//        foreach (var category in product.Categories)
//        {
//            Console.WriteLine($"Catégorie : {category.Category.CategoryName}"
//            );
//        }
//    }

//}
//catch (Exception ex)
//{

//    Console.WriteLine(ex);
//}

#endregion

#region Test GetAll Products avec sizes et categories

//try
//{
//	List<ProductEntity> products = (List<ProductEntity>)await productRepository.GetAll();

//    foreach (var product in products)
//    {
//        Console.WriteLine($"Product name : {product.ModelName}");
//        foreach (var category in product.Categories)
//        {
//            Console.WriteLine($"Categories : {category.Category.CategoryName}");
//        }
//        foreach (var size in product.Sizes)
//        {
//            Console.WriteLine($"Size : {size.Size.Size}");
//            Console.WriteLine($"Stock : {size.Stock}");

//        }

//    }
//}
//catch (Exception ex)
//{

//	throw;
//}
#endregion

#region Test GetById Produdct

//try
//{
//    ProductEntity? product = await productRepository.GetById(2);
//    if (product is null) throw new Exception();

//    Console.WriteLine($"Product name :{product.ModelName}");
//    foreach (var category in product.Categories)
//    {
//        Console.WriteLine($"Catégorie : {category.Category.CategoryName}");
//    }
//}
//catch (Exception ex)
//{

//    Console.WriteLine( ex.Message); ;
//}

#endregion

#region Test Insert Product

//try
//{
//    ProductEntity? insertedProduct = await productRepository.Insert(new ProductEntity() { ModelName = "Puma course ...", Description = "Modèle pour course à pied ...", Brand = "Puma", Price = 77.22M, Discount = 0.30M, Sexe = "Femme"});;
//    if (insertedProduct is null) throw new Exception();

//    Console.WriteLine(insertedProduct.ModelName);
//}
//catch (Exception ex)
//{

//    Console.WriteLine(ex.InnerException.Message);
//}

#endregion

#region Test Update Product
//try
//{
//    ProductEntity? productToUpdate = await productRepository.GetById(1);
//    if (productToUpdate is null) throw new Exception();

//    ProductEntity modifiedProduct = productToUpdate;
//    modifiedProduct.ModelName = "";
//    ProductEntity? updatedProduct = await productRepository.Update(productToUpdate, modifiedProduct);
//    if (updatedProduct is null) throw new Exception();

//    Console.WriteLine(updatedProduct.ModelName);

//}
//catch (Exception ex)
//{

//    Console.WriteLine(ex.Message); ;
//}

#endregion

#region Test Delete Product

//try
//{
//    ProductEntity? productToDelete = await productRepository.GetById(155);
//    if (productToDelete is null) throw new Exception();


//    ProductEntity? deletedProduct = await productRepository.Delete(productToDelete);
//    if (deletedProduct is null) throw new Exception();

//    Console.WriteLine(deletedProduct.ModelName);

//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message); 
//}
#endregion

#region Test Update Stock

//try
//{
//	bool isUpdated = await productRepository.UpdateStock(5, 44, 40);

//}
//catch (Exception ex)
//{

//    Console.WriteLine(ex);
//}

#endregion

#region Test GetByTopSales Products

//try
//{
//    var list = await productRepository.GetByTopSales();

//    foreach (var product in list)
//    {
//        Console.WriteLine(product.ModelName);
//    }

//}
//catch (Exception ex)
//{

//    throw;
//}

#endregion

#region Test GetByStep Products

//try
//{
//	IEnumerable<ProductEntity> products = await productRepository.GetByStep(10);
//    foreach (var product in products)
//    {
//        Console.WriteLine(product.PrdoductId);
//    }
//}
//catch (Exception ex)
//{

//    Console.WriteLine(ex);
//}

#endregion

#region Test GetByCategory Products


//try
//{
//    string categorie = "chaussure de sécurité";
//    IEnumerable<ProductEntity> products = await productRepository.GetByCategory(categorie);


//    foreach (var product in products)
//    {
//        Console.WriteLine(product.ModelName);
//        Console.WriteLine(product.Price);

//        foreach (var c in product.Categories)
//        {
//            Console.WriteLine(c.Category.CategoryName);
//        }
//        Console.WriteLine();

//    }
//}
//catch (Exception ex)
//{

//    Console.WriteLine(ex.Message);
//}

#endregion

#region Test GetByBrand Products

//try
//{
//    string brand =  "Nike";
//    IEnumerable<ProductEntity> products = await productRepository.GetByBrand(brand);

//    foreach (var product in products)
//    {
//        Console.WriteLine(product.ModelName);
//        Console.WriteLine(product.Brand);
//        foreach (var category in product.Categories)
//        {
//            Console.WriteLine(category.Category.CategoryName);
//        }
//        foreach (var size in product.Sizes)
//        {
//            Console.WriteLine(size.Size.Size);
//        }
//    }

//}
//catch (Exception ex)
//{

//    Console.WriteLine(ex.Message);
//}

#endregion

#region Test getByPrice products

//try
//{
//  IEnumerable<ProductEntity> products = await productRepository.GetByPrice(299.99M, 399.89M);
//    foreach (var product in products)
//    {
//        Console.WriteLine(product.ModelName);
//        Console.WriteLine(product.Brand);
//        foreach (var category in product.Categories)
//        {
//            Console.WriteLine(category.Category.CategoryName);
//        }
//        foreach (var size in product.Sizes)
//        {
//            Console.WriteLine(size.Size.Size);
//        }
//    }
//}
//catch (Exception ex)
//{

//    Console.WriteLine(ex.Message);
//}

#endregion

#region Test UpdateCategory Products 

//try
//{
//	int[] categoriesId = { 11, 7 };
//	ProductEntity? product = await productRepository.GetById(93);
//	if (product is null) throw new Exception();

//	bool isUpdated = await productRepository.UpdateCategory(product, categoriesId);
//    Console.WriteLine("OK");

//}
//catch (Exception ex)
//{

//    Console.WriteLine(ex.Message);
//}

#endregion

#region Test filter Products 

//try
//{
//    FilterEntity filter = new FilterEntity() { Brand = "puma", Category = "après-ski" };
//    IEnumerable<ProductEntity> products = productRepository.Filter(filter);

//    foreach (var product in products)
//    {
//        Console.WriteLine(product.ModelName);
//        Console.WriteLine(product.Brand);
//        foreach (var category in product.Categories)
//        {
//            Console.WriteLine(category.Category.CategoryName);
//        }
//        foreach (var size in product.Sizes)
//        {
//            Console.WriteLine(size.Size.Size);
//        }
//    }
//}
//catch (Exception ex)
//{

//    Console.WriteLine(ex.Message);
//}

#endregion



// TEST Categories
#region Test GetAll Categories

//try
//{
//IEnumerable<CategoryEntity> categories = await categoryRepository.GetAll();

//    foreach (var category in categories)
//    {
//        Console.WriteLine(category.CategoryName);
//    }
//}
//catch (Exception ex)
//{

//    Console.WriteLine(ex.Message);
//}

#endregion

#region Test GetById Category

//try
//{
//    CategoryEntity? category = await categoryRepository.GetById(10);
//    if (category is null) throw new Exception();

//    Console.WriteLine(category.CategoryName);
//}
//catch (Exception ex)
//{

//    Console.WriteLine(ex.Message); 
//}

#endregion

#region Test Insert Category

//try
//{
//    CategoryEntity category = new CategoryEntity();
//    category.Description = "Description";
//    category.CategoryName = "Nom cate";
//    CategoryEntity? insertedCategory = await categoryRepository.Insert(category);

//    if (insertedCategory is null) throw new Exception();

//    Console.WriteLine(insertedCategory.CategoryName);

//}
//catch (Exception ex)
//{

//    Console.WriteLine(ex.Message); 
//}
#endregion

#region Test Update Category

//try
//{
//    CategoryEntity? oldCategory = await categoryRepository.GetById(3);
//    if (oldCategory is null) throw new Exception();


//    CategoryEntity modifiedEntity = oldCategory;
//    modifiedEntity.CategoryName = "Changment de nom";
//    CategoryEntity? updatedCategory = await categoryRepository.Update(oldCategory, modifiedEntity);

//    if (updatedCategory is null) throw new Exception();

//    Console.WriteLine(updatedCategory.CategoryName);

//}
//catch (Exception ex)
//{

//    Console.WriteLine(ex.Message); ;
//}

#endregion

#region Test Delete Category

//try
//{
//    CategoryEntity? categoryToDelete = await categoryRepository.GetById(3);
//    if (categoryToDelete is null) throw new Exception();

//    CategoryEntity? deletedCategory = await categoryRepository.Delete(categoryToDelete);
//    if (deletedCategory is null) throw new Exception();

//    Console.WriteLine(deletedCategory.CategoryName);

//}
//catch (Exception ex)
//{

//    Console.WriteLine(ex.Message);
//}
#endregion

#region Test CheckIfExist Category

//try
//{
//    bool isCategoryExist = await categoryRepository.CehckIfExist("chaussure de sécurité");
//    Console.WriteLine(isCategoryExist);

//}
//catch (Exception ex)
//{

//    Console.WriteLine(ex.Message);
//}

#endregion


// TEST Sizes

#region Test GetAll Sizes


//try
//{
//	IEnumerable<SizeEntity> sizes = await sizeRepository.GetAll();
//    foreach (var size in sizes)
//    {
//        Console.WriteLine(size.Size);
//    }
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}
#endregion

#region Test GetById Sizes
//try
//{
//    SizeEntity? size = await sizeRepository.GetById(2);
//    if (size is null) throw new Exception();

//        Console.WriteLine(size.Size);
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}

#endregion

#region Test Insert Size

//try
//{
//    SizeEntity? size = await sizeRepository.Insert(new SizeEntity() { Size = 39});
//    if (size is null) throw new Exception();

//    Console.WriteLine(size.Size);
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}

#endregion

#region Test Update Size

//try
//{
//    SizeEntity? oldSize = await sizeRepository.GetById(2);
//    if (oldSize is null) throw new Exception();

//    oldSize.Size = 40;
//    SizeEntity updatedSize = oldSize;
//    SizeEntity? size = await sizeRepository.Update(oldSize, updatedSize);
//    if (size is null) throw new Exception();

//    Console.WriteLine(size.Size);
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}

#endregion

#region Test Delete Size

//try
//{
//    SizeEntity? entityToDelete = await sizeRepository.GetById(2);
//    if (entityToDelete is null) throw new Exception();

//    SizeEntity? size = await sizeRepository.Delete(entityToDelete);
//    if (size is null) throw new Exception();

//    Console.WriteLine(size.Size);
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}
#endregion

// TEST Orders

#region Test GetAll Orders

//try
//{
//    IEnumerable<OrderEntity> orders = await orderRepository.GetAll();
//    foreach (var order in orders)
//    {
//        Console.WriteLine($"User : {order.User.FirstName}");
//        foreach (var product in order.Products)
//        {
//            Console.WriteLine($"Product : {product.Product.ModelName}");
//            Console.WriteLine($"Price : {product.Price}");
//            Console.WriteLine($"Quantity : {product.Quantity}");
//            Console.WriteLine($"SizeId : {product.Size.Size}");
//        }

//        Console.WriteLine($"Total price : {order.TotalPrice}");
//    }
//}
//catch (Exception ex)
//{

//    Console.WriteLine(ex.Message);
//}

#endregion

#region Test GetByUserId Orders

//try
//{
//    IEnumerable<OrderEntity> orders = await orderRepository.GetByUserId(12);
//    foreach (var order in orders)
//    {
//        Console.WriteLine($"User : {order.User.FirstName}");
//        foreach (var product in order.Products)
//        {
//            Console.WriteLine($"Product : {product.Product.ModelName}");
//            Console.WriteLine($"Price : {product.Price}");
//            Console.WriteLine($"Quantity : {product.Quantity}");

//        }
//        Console.WriteLine($"Total price : {order.TotalPrice}");
//    }
//}
//catch (Exception ex)
//{

//    Console.WriteLine(ex.Message);
//}

#endregion

#region Test GetByUser Orders

//try
//{
//    IEnumerable<OrderEntity> orders = await orderRepository.GetByUser("dokkannico75@gmail.com");
//    foreach (var order in orders)
//    {
//        Console.WriteLine($"User : {order.User.FirstName}");
//        foreach (var product in order.Products)
//        {
//            Console.WriteLine($"Product : {product.Product.ModelName}");
//            Console.WriteLine($"Price : {product.Price}");
//            Console.WriteLine($"Quantity : {product.Quantity}");

//        }
//        Console.WriteLine($"Total price : {order.TotalPrice}");
//    }
//}
//catch (Exception ex)
//{

//    Console.WriteLine(ex.Message);
//}

#endregion

#region Test Insert Order 

//OrderEntity order = new OrderEntity() { OrderDate = DateTime.Now, UserId = 12 };
//ProductOrderEntity productOrder = new ProductOrderEntity { Order = order, Price = 1, Quantity = 1, SizeId = 6, ProductId = 66 };
//order.Products.Add(productOrder);


//try
//{
//    OrderEntity? insertedOrder = await orderRepository.Insert(order);

//    if (insertedOrder is null) throw new Exception();

//    foreach (var p in insertedOrder.Products)
//    {
//        Console.WriteLine(p.Size.Size);
//    }

//}
//catch (Exception ex)
//{

//    Console.WriteLine(ex.Message);
//}


#endregion


// TEST Services BLL
IAuthRepository authRepository = new UserRepository(dataContext, configuration);
IUserService userService = new UserService(userRepository);
IAuthService authService = new AuthService(authRepository, userRepository);
IAdressService adressService = new AdressService(adressRepository);
IProductService productService = new ProductService(productRepository, sizeRepository, categoryRepository);
ICategoryService categoryService = new CategoryService(categoryRepository);
ISizeService sizeService = new SizeService(sizeRepository);
IOrderService orderService = new OrderService(orderRepository, userRepository, productRepository, sizeRepository);


// TEST Users
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
//    foreach (var adress in user.Adresses)
//    {
//        Console.WriteLine(adress.Street);
//    }
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
//    UserModel? userToUpdate = await userService.GetById(14);
//    userToUpdate.FirstName = "niconrrico";
//    userToUpdate.LastName = "d";

//    if (userToUpdate is null)
//        throw new Exception();

//    UserModel? updatedUser = await userService.Update(userToUpdate, 14);

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
//    UserModel user = await authService.Login("nico.daddabbo7100@gmail.com", "@GGGtyudd4");

//    if (user is null) throw new Exception();

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

#region Test UpdatePassword User

//try
//{
//    bool isUpdated = await authService.UpdatePassword("@GGGtyudd4ddd", 14);

//    if (!isUpdated) throw new Exception();

//    Console.WriteLine("ok");
//}
//catch (Exception ex)
//{

//    Console.WriteLine(ex.Message);
//}

#endregion

#region Test GetAllUsersWithAdresses

//IEnumerable<UserAdressesModel> userAdresses = await userService.GetAllWithAdresses();

//foreach (var user in userAdresses)
//{
//    Console.WriteLine(user.user.FirstName);
//    foreach (var adress in user.Adresses)
//    {
//        Console.WriteLine(adress.Country);
//    }
//}
#endregion

#region Test ActiveAccount User

//try
//{
//	bool isActivate = await userService.ActiveAccount(16);
//    if (!isActivate) throw new Exception();

//    Console.WriteLine("OK");

//}
//catch (Exception ex)
//{

//    Console.WriteLine(ex.Message);
//}

#endregion

// TEST Adress

#region Test GetAll Adress

//try
//{
//	IEnumerable<AdressModel> adresses = await adressService.GetAll();
//    foreach (var item in adresses)
//    {
//        Console.WriteLine(item.CityName);
//    }
//}
//catch (Exception ex)
//{

//    Console.WriteLine(ex.Message); 
//}

#endregion

#region Test GetById Adress

//try
//{
//	AdressModel? adress = await adressService.GetById(1);

//	if (adress is null) throw new Exception();

//    Console.WriteLine(adress.Country);
//}
//catch (Exception ex)
//{

//    Console.WriteLine(ex.Message); 
//}

#endregion

#region Test Delete Adress

//try
//{
//	AdressModel? deletedAdress = await adressService.Delete(12);

//	if (deletedAdress is null) throw new Exception();

//    Console.WriteLine(deletedAdress.Country);
//}
//catch (Exception ex)
//{

//    Console.WriteLine(ex.Message);
//}
#endregion

#region Test Insert Adress

//try
//{
//	AdressModel? insertedAdress = await adressService.Insert(new AdressModel() { CityName = "Charleroi", Street = "Pas d'didée", Number = 420, Country = "Belgique" });
//	if (insertedAdress is null) throw new Exception();

//    Console.WriteLine(insertedAdress.Street);
//}
//catch (Exception ex)
//{

//    Console.WriteLine(ex.Message); 
//}

#endregion

#region test Update Adress

//try
//{
//    AdressModel? adress = await adressService.GetById(16);
//    if (adress is null) throw new Exception();

//    adress.Street = "Pas d'didéeddd";
//    AdressModel? modifiedAdress = await adressService.Update(adress, 16);
//    if (modifiedAdress is null) throw new Exception();

//    Console.WriteLine(modifiedAdress.Street);
//}
//catch (Exception ex)
//{

//    Console.WriteLine(ex.Message);
//}
#endregion


// TEST Products

#region Test GetAll Products

//try
//{
//    IEnumerable<ProductModel> products = await productService.GetAll();

//    foreach (var product in products)
//    {
//        Console.WriteLine(product.ModelName);
//        foreach (var category in product.Categories)
//        {
//            Console.WriteLine(category.CategoryName);
//        }
//    }
//}
//catch (Exception ex)
//{

//    throw;
//}

#endregion

#region Test getById Products

//try
//{
//	ProductModel? product = await productService.GetById(2);

//	if (product is null) throw new Exception();

//    Console.WriteLine(product.ModelName);
//    Console.WriteLine("Categories :");
//    foreach (var item in product.Categories)
//    {
//        Console.WriteLine(item.CategoryName);
//    }

//}
//catch (Exception ex)
//{

//    Console.WriteLine(ex.Message);
//}

#endregion

#region Test Insert Product

//try
//{
//    List<CategoryModel> cate = new List<CategoryModel>() { new CategoryModel() { CategoryName = "test", Description = "test" }, new CategoryModel() { CategoryName = "test", Description = "test" } };
//	ProductModel? insertedProduct = await productService.Insert(new ProductModel("Pas idée", "des baskets blblbl", "nike", "Homme", 50.89M, 0, cate));
//    Console.WriteLine(insertedProduct.ProductId);
//    if (insertedProduct is null) throw new Exception();

//    Console.WriteLine(insertedProduct.Description);


//}
//catch (Exception ex)
//{

//    Console.WriteLine(ex.Message);
//}

#endregion

#region Test Update Products

//try
//{
//    ProductModel? productToUpdate = await productService.GetById(2);
//    if (productToUpdate is null) throw new Exception();

//    productToUpdate.ModelName = "New model 2024 incroyableee";

//    ProductModel? updatedProduct = await productService.Update(productToUpdate ,2); 
//    if(updatedProduct is null) throw new Exception();

//    Console.WriteLine(updatedProduct.ModelName);
//}
//catch (Exception ex)
//{

//    Console.WriteLine(ex.Message);
//}

#endregion

#region Test Delete Product
//try
//{
//	ProductModel? deletedProduct = await productService.Delete(2);
//	if (deletedProduct is null) throw new Exception();

//    Console.WriteLine(deletedProduct.ModelName);

//}
//catch (Exception ex)
//{

//    Console.WriteLine(ex.Message);
//}

#endregion

#region Test UpdateStock Product

//try
//{
//	bool isUpdated = await productRepository.UpdateStock(5, 57, 100);
//	if (!isUpdated) throw new Exception();
//}
//catch (Exception ex)
//{

//	Console.WriteLine(ex.Message);
//}

#endregion

#region Test GetByTopSales Products

//try
//{
//    IEnumerable<ProductModel> products = await productService.GetByTopSales();

//    foreach (var product in products)
//    {
//        Console.WriteLine(product.ModelName);
//    }
//}
//catch (Exception ex)
//{

//    Console.WriteLine(ex.Message);
//}

#endregion

#region Test GetByStep Products

//try
//{
//	IEnumerable<ProductModel> products = await productService.GetByStep(0);
//    foreach (var product in products)
//    {
//        Console.WriteLine(product.ProductId);
//    }
//}
//catch (Exception ex)
//{

//    Console.WriteLine(ex.Message);
//}

#endregion

#region Test GetByCategory Products
//try
//{
//    string[] categories = new string[] { "chaussure de sécurité" };
//    IEnumerable<ProductModel>? products = await productService.GetByCategory(categories);
//    if (products is null) throw new Exception();
//    foreach (var product in products)
//    {
//        Console.WriteLine(product.ModelName);
//        Console.WriteLine(product.Price);

//        foreach (var c in product.Categories)
//        {
//            Console.WriteLine(c.CategoryName);
//        }
//        Console.WriteLine();

//    }
//}
//catch (Exception ex)
//{

//    Console.WriteLine(ex.Message);
//}

#endregion

#region Test GetByBrand Products 

//try
//{
//    string[] brands = new string[] { "mss" };
//    IEnumerable<ProductModel> products = await productService.GetByBrand(brands);
//    foreach (var product in products)
//    {
//        Console.WriteLine(product.ModelName);
//        Console.WriteLine(product.Brand);
//        foreach (var category in product.Categories)
//        {
//            Console.WriteLine(category.CategoryName);
//        }
//        foreach (var size in product.AvailableSizes)
//        {
//            Console.WriteLine(size.Size);
//        }
//    }

//}
//catch (Exception ex)
//{

//    Console.WriteLine(ex.Message);
//}

#endregion

#region Test getByPrice products

//try
//{
//    IEnumerable<ProductModel>? products = await productService.GetByPrice(299.99M, 399.89M);
//    if (products is null) throw new Exception();
//    foreach (var product in products)
//    {
//        Console.WriteLine(product.ModelName);
//        Console.WriteLine(product.Brand);
//        foreach (var category in product.Categories)
//        {
//            Console.WriteLine(category.CategoryName);
//        }
//        foreach (var size in product.AvailableSizes)
//        {
//            Console.WriteLine(size.Size);
//        }
//    }
//}
//catch (Exception ex)
//{

//    Console.WriteLine(ex.Message);
//}

#endregion

#region Test Filter Products

//try
//{
//    try
//    {
//        FilterModel filter = new FilterModel(category:"chaussure de sécurité");
//        IEnumerable<ProductModel> products = productService.Filter(filter);

//        foreach (var product in products)
//        {
//            Console.WriteLine(product.ModelName);
//            Console.WriteLine(product.Brand);
//            foreach (var category in product.Categories)
//            {
//                Console.WriteLine(category.CategoryName);
//            }
//            foreach (var size in product.AvailableSizes)
//            {
//                Console.WriteLine(size.Size);
//            }
//        }
//    }
//    catch (Exception ex)
//    {

//        Console.WriteLine(ex.Message);
//    }
//}
//catch (Exception ex)
//{

//    Console.WriteLine(ex.Message);
//}
#endregion


// TEST Categories

#region Test GetAll Category

//try
//{
//	IEnumerable<CategoryModel> categories = await categoryService.GetAll();
//    foreach (var category in categories)
//    {
//        Console.WriteLine(category.CategoryName);
//    }
//}
//catch (Exception ex)
//{

//    Console.WriteLine(ex.Message);
//}

#endregion

#region Test GetById Category

//try
//{
//    CategoryModel? category = await categoryService.GetById(22);
//    if (category is null) throw new Exception();

//    Console.WriteLine(category.CategoryName);
//}
//catch (Exception ex)
//{

//    Console.WriteLine(ex.Message);
//}
#endregion

#region Test Insert Category

//try
//{
//	CategoryModel? insertedCategory = await categoryService.Insert(new CategoryModel() { CategoryName = "Test BLL", Description = "Test BLL" });
//	if (insertedCategory is null) throw new Exception();

//    Console.WriteLine(insertedCategory.CategoryName);
//}
//catch (Exception ex)
//{

//    Console.WriteLine(ex.Message);
//}

#endregion

#region Test Update Category

//try
//{
//	 CategoryModel? categoryToUpdate = await categoryService.GetById(2);
//	if (categoryToUpdate is null) throw new Exception();

//	categoryToUpdate.Description = "sddsfsfsf";

//	CategoryModel? updatedCategory = await categoryService.Update(categoryToUpdate, 2);
//	if(updatedCategory is null) throw new Exception();

//    Console.WriteLine(updatedCategory.Description);
//}
//catch (Exception ex)
//{

//	Console.WriteLine(ex.Message);
//}

#endregion

#region Test Delete Category

//try
//{
//    CategoryModel? deletedCategory = await categoryService.Delete(2);
//    if (deletedCategory is null) throw new Exception();

//    Console.WriteLine(deletedCategory.CategoryName);
//}
//catch (Exception ex)
//{

//    Console.WriteLine(ex.Message);
//}

#endregion


// TEST Sizes

#region Test GetAll Sizes

//try
//{
//	IEnumerable<SizeModel> sizes = await sizeService.GetAll();
//    foreach (var size in sizes)
//    {
//        Console.WriteLine(size.Size);
//    }
//}
//catch (Exception ex)
//{

//    Console.WriteLine(ex.Message);
//}

#endregion

#region Test GetById Sizes

//try
//{
//    SizeModel? size = await sizeService.GetById(3);
//    if (size is null) throw new Exception();

//        Console.WriteLine(size.Size);
//}
//catch (Exception ex)
//{

//    Console.WriteLine(ex.Message);
//}

#endregion

#region Test Insert Size

//try
//{
//    SizeModel? insertedSize = await sizeService.Insert(new SizeModel(41));
//    if (insertedSize is null) throw new Exception();


//    Console.WriteLine(insertedSize.Size);
//}
//catch (Exception ex)
//{

//    Console.WriteLine(ex.Message);
//}
#endregion

#region Test Update Size

//try
//{
//    SizeModel? sizeToUpdate = await sizeService.GetById(4);
//    if (sizeToUpdate is null) throw new Exception();

//    SizeModel size = sizeToUpdate;
//    size.Size = 42;

//    SizeModel? updatedSize = await sizeService.Update(size, 4);
//    if (updatedSize is null) throw new Exception();


//    Console.WriteLine(updatedSize.Size);
//}
//catch (Exception ex)
//{

//    Console.WriteLine(ex.Message);
//}

#endregion

#region Test Delete Size

//try
//{

//    SizeModel? deletedSize = await sizeService.Delete(4);
//    if (deletedSize is null) throw new Exception();

//    Console.WriteLine(deletedSize.Size);
//}
//catch (Exception ex)
//{

//    Console.WriteLine(ex.Message);
//}

#endregion


// TEST Orders

#region Test GetAll Orders

//try
//{
//    IEnumerable<OrderModel> orders = await orderService.GetAll();
//    foreach (var order in orders)
//    {
//        Console.WriteLine($"User {order.User.FirstName} has order : ");
//        foreach (var products in order.OrderProducts)
//        {
//            Console.WriteLine(products.ModelName);
//            Console.WriteLine($"Quantity : {products.Quantity}");
//            Console.WriteLine($"Size :  {products.Size.Size}");
//            Console.WriteLine($"Total price : {products.Price}");
//        }
//        Console.WriteLine($"Total order price : {order.TotalPrice}");
//    }
//}
//catch (Exception ex)
//{

//    Console.WriteLine(ex.Message);
//}

#endregion

#region Test GetByUserId Order

//try
//{
//	IEnumerable<OrderModel> orders = await orderService.GetByUserId(12);
//    foreach (var order in orders)
//    {
//        Console.WriteLine($"User {order.User.FirstName} has order : ");
//        foreach (var products in order.OrderProducts)
//        {
//            Console.WriteLine(products.ModelName);
//            Console.WriteLine($"Quantity : {products.Quantity}");
//            Console.WriteLine($"Total price : {products.Price}");
//        }
//        Console.WriteLine($"Total order price : {order.TotalPrice}");
//        Console.WriteLine("///////////////////////////////////////");
//    }
//}
//catch (Exception ex)
//{

//    Console.WriteLine(ex);
//}

#endregion

#region Test GetByUserEmail Order

//try
//{
//	IEnumerable<OrderModel> orders = await orderService.GetByUserEmail("dok@gmail.com");
//    foreach (var order in orders)
//    {
//        Console.WriteLine($"User {order.User.FirstName} has order : ");
//        foreach (var products in order.OrderProducts)
//        {
//            Console.WriteLine(products.ModelName);
//            Console.WriteLine($"Quantity : {products.Quantity}");
//            Console.WriteLine($"Total price : {products.Price}");
//        }
//        Console.WriteLine($"Total order price : {order.TotalPrice}");
//        Console.WriteLine("///////////////////////////////////////");
//    }
//}
//catch (Exception ex)
//{

//    Console.WriteLine(ex.Message);
//}

#endregion

#region Test Insert Order

//List<OrderProductModel> opml = new List<OrderProductModel>();
//opml.Add(new OrderProductModel(66, 6, 2, 1, 0));
//OrderModel order = new OrderModel(12, 0, opml);

//try
//{
//	OrderModel? insertedOrder = await orderService.Insert(order);
//	if (insertedOrder is null) throw new Exception();

//    foreach (var item in opml)
//    {
//        Console.WriteLine(item.Size.SizeId);

//    }
//}
//catch (Exception ew)
//{

//	throw;
//}

#endregion





// TEST appart

#region Test Include
//try
//{
//IEnumerable<ProductEntity> list = await dataContext.Products.Include(p => p.CategoriesEntity).ToListAsync();

//    foreach (var item in list)
//    {

//        Console.WriteLine(item.Description);

//        foreach (var cate in item.CategoriesEntity)
//        {
//            Console.WriteLine(cate.CategoryName);
//        }

//    }
//}
//catch (Exception ex)
//{

//	throw;
//}

#endregion






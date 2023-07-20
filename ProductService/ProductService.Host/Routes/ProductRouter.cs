using ProductService.Domain;
using ProductService.Domain.Entities;
using ProductService.Domain.Interfaces;

namespace ProductService.Host.Routes;

public static class ProductRouter
{
    public static WebApplication AddProductRouter(this WebApplication application)
    {
        var userGroup = application.MapGroup("/api/users");

        userGroup.MapGet("/", GetAll);
        userGroup.MapGet("/{id:long}", GetProductById);
        userGroup.MapPost("/", CreateProduct);
        userGroup.MapPut("/", UpdateProduct);
        userGroup.MapDelete("/{id:long}", DeleteProduct);

        return application;
    }
    
    private static IResult GetAll(IProductManager productManager)
    {
        var products = productManager.GetAllProducts();
        return Results.Ok(products); 
    }


    // ПОлучить пользователь по id
    private static IResult GetProductById(long id, IProductManager productManager)
    {
        var product = productManager.GetById(id);
        return product is null ? Results.NotFound() : Results.Ok(product); // Данные пользователя
    }


    //Добавление пользователя
    private static IResult CreateProduct(Product product, IProductManager productManager)
    {
        var createProduct = productManager.CreateProduct(product);
        return Results.Ok(createProduct); //Данные пользователя
    }


    //Обновление данных пользователя

    private static IResult UpdateProduct(Product product, IProductManager productManager)
    {
        var updateUser = productManager.UpdateById(product);
        return updateUser is null ? Results.NotFound() : Results.Ok(updateUser);
    }

    //Удаление пользователя

    private static IResult DeleteProduct(long id, IProductManager productManager)
    {
        var deletedUser = productManager.DeleteById(id);
        return deletedUser is null ? Results.NotFound() : Results.Ok(deletedUser);
    }
}
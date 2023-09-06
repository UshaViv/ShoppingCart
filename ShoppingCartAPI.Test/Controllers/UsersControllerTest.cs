using Moq;
using ShoppingCartAPI.Controllers;
using ShoppingCartAPI.PayloadModels;
using ShoppingCartAPI.Services;

namespace ShoppingCartAPI.Test.Controllers;

public class UsersControllerTest
{
    [Fact]
    public void AddAsync_Success()
    {
        //Arrange
        var mockUserService = new Mock<IUserService>();
        var controller = new UsersController(mockUserService.Object);

        //Act
        UserPayload userPayload = new() {
            Name = "usha",
            PhoneNumber = "1234567890"
        };   
        var actionResult  = controller.AddAsync(userPayload);

        //Assert
        Assert.True(actionResult.IsCompletedSuccessfully);
    }
}

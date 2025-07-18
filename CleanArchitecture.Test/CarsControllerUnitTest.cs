using CleanArchitecture.Application.Feautures.Car.Commands;
using CleanArchitecture.Presentation.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CleanArchitecture.Test
{
    public class CarsControllerUnitTest
    {
        [Fact]
        public async Task CreateReturnsOkResultWhenRequestIsValid()
        {
            //Arrange
            var mediatorMock = new Mock<IMediator>();
            CreateCarCommand createCarCommand = new CreateCarCommand("Toyota", "Corolla", 400);
            CreateCarCommandRequest response = new CreateCarCommandRequest(message: "Kayıt Başarıyla Eklendi ");
            CancellationToken token = new CancellationToken();

            mediatorMock.Setup(m => m.Send(createCarCommand, token)).ReturnsAsync(response);
            ValuesController valuesController = new ValuesController(mediatorMock.Object);

            //Act 

            var result = await valuesController.CreateCar(createCarCommand, token);

            //Assert

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<CreateCarCommandRequest>(okResult.Value);

            Assert.Equal(response, returnValue);
            mediatorMock.Verify(m => m.Send(createCarCommand, token), Times.Once);

        }
    }
}

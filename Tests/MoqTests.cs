using System;
using Moq;
using UnitTest;

namespace Tests
{
	public class MoqTests
	{
		//_sut is system under test
		private readonly CustomService _sut;

		private readonly Mock<ICustomServiceRepository> _respositoryMock = new Mock<ICustomServiceRepository>();

		public MoqTests()
		{
			_sut = new CustomService(this._respositoryMock.Object);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        //triple AAA (Arrange,ACT and Assert)
        public async Task ShouldTestTheStringReturn(string expected,string mock,string service )
		{
			//Arrange
			_respositoryMock.Setup(x => x.TestReturn()).Returns(mock);

			//Act
			var retorno = _sut.ConsultTestReturn(service);
			
			//Assert
			Assert.Equal(expected, retorno);


		}


        public static IEnumerable<object[]> TestData()
        {
            yield return new object[] { "ola caio",  "ola", "caio" } ;
            yield return new object[] { "tchau caio", "tchau", "caio"  };
            yield return new object[] { "bem vindo matheus", "bem vindo", "matheus" };
        }

    }
}


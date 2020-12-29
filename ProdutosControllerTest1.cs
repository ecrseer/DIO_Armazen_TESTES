
using Armazen_API.Controllers;
using DIO_Armazen.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace DIO_Armazen_TESTES
{
    public class ProdutosControllerTest1
    {//to do
        private readonly Mock<DbSet<Produto>> _mockSet;
        private readonly Mock<Context> _mockContext;
        private readonly Produto _produto;
        public ProdutosControllerTest1() {
            _mockSet = new Mock<DbSet<Produto>>();
            _mockContext = new Mock<Context>();
            _produto = new Produto { id=32,descricao="Desodorante ivone"};
            _mockContext.Setup(mck => mck.produtos).Returns(
                _mockSet.Object);//retorna o objt
            _mockContext.Setup(mck => mck.produtos.FindAsync(32))
                .ReturnsAsync(_produto);//retorna metodo utilizado
        }
        
        [Fact]
        public async Task getCategoriax_()
        {
            var servico = new ProdutosController(_mockContext.Object);
            await servico.GetProduto(32);

            _mockSet.Verify(mymck => mymck.FindAsync(32), Times.Once());

        }






        
    }
}

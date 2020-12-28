
using Armazen_API.Controllers;
using DIO_Armazen.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace DIO_Armazen_TESTES
{
    public class UtilitariosControllerTest1
    {
        private readonly Mock<DbSet<Utilitario>> _mockSet;
        private readonly Mock<Context> _mockContext;
        private readonly Utilitario _utilitario;
        public UtilitariosControllerTest1() {
            _mockSet = new Mock<DbSet<Utilitario>>();
            _mockContext = new Mock<Context>();
            _utilitario = new Utilitario { id=32,descricao="Eletrodomesticos"};
            _mockContext.Setup(m => m.Utilitarios).Returns(_mockSet.Object);
        }
        
        [Fact]
        public async Task get_Utilitario()
        {
            var servico = new UtilitariosController(_mockContext.Object);
            await servico.GetUtilitario(32);
            _mockSet.Verify(mymck => mymck.FindAsync(32), Times.Once());

        }






        
    }
}

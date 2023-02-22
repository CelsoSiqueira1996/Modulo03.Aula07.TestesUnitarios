using Modulo03.Aula07.TestesUnitarios;

namespace TestContactService
{
    public class TestRemoveContact
    {
        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        public void TestRemoveContactInvalidIndex(int index)
        {
            //Arrange - prepara o ambiente de teste
            var expected = "Índice inválido. Tente novamente.";
            var contactService = new ContactService();

            //Act - executa a ação que queremos testar
            var result = contactService.RemoveContact(index);

            //Assert - verifica se o resultado obtido é o esperado
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestRemoveContactCorrect()
        {
            //Arrange - prepara o ambiente de teste
            var expected = "Contato 'Celso' removido com sucesso.";
            var contactService = new ContactService();
            contactService.AddContact("Celso", "1499999-9999", "celso@gmail.com");

            //Act - executa a ação que queremos testar
            var result = contactService.RemoveContact(0);

            //Assert - verifica se o resultado obtido é o esperado
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestRemoveContactNullReference()
        {
            //Arrange - prepara o ambiente de teste
            var contactService = new ContactService();
            contactService.contacts = null;

            //Act/Assert - executa a ação que queremos testar
            Assert.Throws<NullReferenceException>(() => contactService.RemoveContact(0));
        }
    }
}

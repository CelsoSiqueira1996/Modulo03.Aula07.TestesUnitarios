using Modulo03.Aula07.TestesUnitarios;

namespace TestContactService
{
    public class TestUpdateContact
    {
        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        public void TestUpdateContactInvalidIndex(int index)
        {
            //Arrange - prepara o ambiente de teste
            var expected = "Índice inválido. Tente novamente.";
            var contactService = new ContactService();

            //Act - executa a ação que queremos testar
            var result = contactService.UpdateContact(index, "Celso", "1499999-9999", "celso@gmail.com");

            //Assert - verifica se o resultado obtido é o esperado
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestUpdateContactCorrect()
        {
            //Arrange - prepara o ambiente de teste
            var expected = "Contato 'Geovana' atualizado com sucesso.";
            var contactService = new ContactService();
            contactService.AddContact("Celso", "1499999-9999", "celso@gmail.com");

            //Act - executa a ação que queremos testar
            var result = contactService.UpdateContact(0, "Geovana", "1499999-9999", "geovana@gmail.com");

            //Assert - verifica se o resultado obtido é o esperado
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestUpdateContactNullReference()
        {
            //Arrange - prepara o ambiente de teste
            var contactService = new ContactService();
            contactService.contacts = null;

            //Act/Assert - executa a ação que queremos testar
            Assert.Throws<NullReferenceException>(() => contactService.UpdateContact(0, "Celso", "1499999-9999", "celso@gmail.com"));
        }
    }
}

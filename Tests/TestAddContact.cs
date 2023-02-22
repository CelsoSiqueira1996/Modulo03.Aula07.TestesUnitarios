using Modulo03.Aula07.TestesUnitarios;

namespace TestContactService
{
    public class TestAddContact
    {
        [Fact]
        public void TestAddValidContact()
        {
            //Arrange - prepara o ambiente de teste
            var expected = true;
            var contactService = new ContactService();

            //Act - executa a ação que queremos testar
            var result = contactService.AddContact("Celso", "1499999-9999", "celso@gmail.com");

            //Assert - verifica se o resultado obtido é o esperado
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestAddDuplicateContact()
        {
            //Arrange - prepara o ambiente de teste
            var expected = true;
            var contactService = new ContactService();
            contactService.AddContact("Celso", "1499999-9999", "celso@gmail.com");

            //Act - executa a ação que queremos testar
            var result = contactService.AddContact("Celso", "1499999-9999", "celso@gmail.com");

            //Assert - verifica se o resultado obtido é o esperado
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestAddContactNullReference()
        {
            //Arrange - prepara o ambiente de teste
            var contactService = new ContactService();
            contactService.contacts = null;

            //Act/Assert - executa a ação que queremos testar
            Assert.Throws<NullReferenceException>(() => contactService.AddContact("Celso", "1499999-9999", "celso@gmail.com"));
        }
    }
}
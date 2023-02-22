using Modulo03.Aula07.TestesUnitarios;

namespace TestContactService
{
    public class TestListsContacts
    {
        [Fact]
        public void TestListsContactsWhenEmpty()
        {
            //Arrange - prepara o ambiente de teste
            var expected = "Não há contatos cadastrados.";
            var contactService = new ContactService();

            //Act - executa a ação que queremos testar
            var result = contactService.ListContacts();

            //Assert - verifica se o resultado obtido é o esperado
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestListsContactsCorrect()
        {
            //Arrange - prepara o ambiente de teste
            var expected = "Lista de contatos:\n1. Celso - 1499999-9999 - celso@gmail.com\n";
            var contactService = new ContactService();
            contactService.AddContact("Celso", "1499999-9999", "celso@gmail.com");

            //Act - executa a ação que queremos testar
            var result = contactService.ListContacts();

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
            Assert.Throws<NullReferenceException>(() => contactService.ListContacts());
        }
    }
}

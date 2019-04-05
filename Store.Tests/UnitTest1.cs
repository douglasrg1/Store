using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.StoreContext.Entities;
using Store.Domain.StoreContext.ValueObjects;

namespace Store.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var name = new Name("douglas","rocha");
            var document = new Document("34534543534");
            var email = new Email("teste@homail.com");

            var mouse = new Product("mouse","rato","img.png",11.50m,10);
            var teclado = new Product("teclado","teclado","teclado.png",22.50m,10);
            var impressora = new Product("impressora","impressora","impressora.png",110.50m,10);
            var placaMae = new Product("Placa Mae","Placa Mae","placaMae.png",180.50m,10);
            var processador = new Product("processador","processador","processador.png",311.50m,10);
            var Memoria = new Product("Memoria","Memoria","Memoria.png",199.50m,10);

            var c = new Customer(name,document,email,"23423423423");

            var order = new Order(c);

            order.Additem(new OrderItem(mouse,5,10));
            order.Additem(new OrderItem(teclado,5,10));
            order.Additem(new OrderItem(impressora,5,10));
            order.Additem(new OrderItem(placaMae,5,10));
            order.Additem(new OrderItem(processador,5,10));
            order.Additem(new OrderItem(Memoria,5,10));

            order.PlaceOrder();

            order.Pay();

            order.Ship();

            order.Cancel();

        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.StoreContext.ValueObjects;

namespace Store.Tests.ValueObjects
{
    [TestClass]
    public class DocumentTests
    {
        [TestMethod]
        public void ReturnTrueIfDocumentIsValid()
        {
            var document = new Document("12312312312");
            Assert.IsTrue(document.IsValid);

        }
        [TestMethod]
        public void ReturnFalseIfDocumentIsInvalid()
        {
            var document2 = new Document("123456789121");
            Assert.IsFalse(document2.IsValid);

        }
    }
}

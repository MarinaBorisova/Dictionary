using NUnit.Framework;
using NSubstitute;
using DC.Core;
using System.Collections.Generic;

namespace DC.UTest
{
    [TestFixture]
    public class UnitTestProductManager
    {
        private ProductManager _target;      
        private IProductRepository _fakeReposiitory;
        [SetUp]
        public void Setup()
        {
            _fakeReposiitory = Substitute.For<IProductRepository>();
            _target = new ProductManager(_fakeReposiitory);    
        }

        [Test]
        public void AddProduct_ReturnTrue()
        {
            var productTest = new Product("testId", "testName");

            _fakeReposiitory
             .ProductsAdd(productTest.Id, productTest.NameProduct)
             .Returns(x => true);

            bool result = _target.AddProduct(productTest);

            _fakeReposiitory
                .Received()
                .ProductsAdd(productTest.Id, productTest.NameProduct);

            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void GetProducts_ReturnListOfProducts()
        {
            var expexted = new List<Product>
            {
                new Product("idtest1", "nametest1"),
                new Product("idtest2", "nametest2"),
            };
            _fakeReposiitory.ProductsGetAll().Returns(new List<Product>(expexted));

            var actual = _target.GetProducts();

            CollectionAssert.AreEqual(expexted, actual);
            _fakeReposiitory.Received().ProductsGetAll();
        }

        [Test]
        public void GetProductById_ReturnProduct()
        {
            var expexted = new Product("idTest", "nameTest");

            _fakeReposiitory.ProductsGetbyId(expexted.Id).Returns(expexted);
             var actul = _target.GetProduct(expexted.Id);

             Assert.AreEqual(expexted, actul);
            _fakeReposiitory.Received().ProductsGetbyId(expexted.Id);

            
        }
    }
}
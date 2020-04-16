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
            _fakeReposiitory.ProductsGetAll().Returns(new List<Product>());
            _target.GetProducts();

            _fakeReposiitory.Received().ProductsGetAll();
        }

        
    }
}
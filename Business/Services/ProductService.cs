using AutoMapper;
using SimpleCRUD_MVC.Business.Models.Input;
using SimpleCRUD_MVC.Business.Services.Base;
using SimpleCRUD_MVC.Business.Services.Interfaces;
using SimpleCRUD_MVC.Data;
using SimpleCRUD_MVC.Data.Models;
using System.Transactions;

namespace SimpleCRUD_MVC.Business.Services
{
    public class ProductService : BaseService<Product>
    {
        private readonly IBaseService<ProductImage> _productImageService;

        public ProductService(IMapper mapper, SimpleCRUD_MVCContext context, IBaseService<ProductImage> productImageService) : base(mapper, context)
        {
            _productImageService = productImageService;
        }

        public override Product Add<Input>(Input input)
        {
            ProductInput item = input as ProductInput;

            using (TransactionScope scope = new TransactionScope())
            {
                Product product = base.Add(input);

                MemoryStream stream = new MemoryStream();
                ProductImage productImage = new ProductImage();

                item.Image.CopyTo(stream);
                productImage.Imagem = stream.ToArray();
                productImage.ProductId = product.Id;
                _productImageService.Add(productImage);

                scope.Complete();

                return product;
            }
        }
    }
}

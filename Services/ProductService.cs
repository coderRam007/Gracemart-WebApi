public class ProductService{
    private readonly IProductRepository _productRepository;
      public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public async Task<IEnumerable<ProductModel>> GetProducts()
    {
        return await _productRepository.GetProducts();
    }

}
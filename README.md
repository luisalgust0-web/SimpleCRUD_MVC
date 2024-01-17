# SimpleCRUD_MVC

Este projeto � um CRUD simples realizado seguindo o padr�o MVC

DIVIS�O DAS PASTAS: 

 -Business: Se encontra as partes do negocio do projeto como os servi�os e suas interfaces e os inputModelViews e os outputModelViews.

 -Configuration: Contem a classe ServiceConfiguration que conta com um m�todo de extens�o Configuration onde todos os services s�o adicionados.

 -Controllers: cont�m os controllers do projeto.

 -Data: Se encontra a classe Context e os models que representam os modelos do DB.

 -MapperProfiles: Contem a classe profiles onde configuramos os Maps que o AutoMapper ira utilizar ao realizar o mapeamento de uma classe a outra.

 -Migrations: Cont�m o historico de migra�oes do proeto com seus ups e downs

 -View: Contem as views de cada controller

SERVICES:

 1 - Os services foram implementado utilizando o conceito de Generics onde se tem um servi�o base(BaseService) que recebe um tipo generico(T) e possui m�todos basicos que ser�o utilizados por varias entidades;

 2 - O conceito de heran�a tamb�m foi aplicado em casos onde uma rotina de instru��es peculiar deve ser executada criando classes service que herdam de BaseService e sobrescrevem algum m�todo especifico.

  //Exemplo retirado da classe ProductServie:

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

 3 - O conceito de sobrecarga de m�todos tamb�m foi aplicado onde m�todos com mesmo nome e mesmo retorno foram escritos por�m com paramentros diferentes 
 
  //A baixo dois m�todos com mesmo nome e retorno por�m que recebem parametros diferentes:
  
public List<Output> GetAll<Output>(Expression<Func<T, object>> func)
{
    List<T> listEntitys = _context.Set<T>().Include(func).ToList();
    return _mapper.Map<List<Output>>(listEntitys);
}

public List<Output> GetAll<Output>()
{
    List<T> listEntitys = _context.Set<T>().ToList();
    return _mapper.Map<List<Output>>(listEntitys);
}


CONFIGURATIONS:
 
 1 - A pasta Configurations que cont�m a classe ServiceConfiguration que centraliza todos os servi�os que ser�o configurados no Program.cs atrav�s de um m�todo de extens�o que retorna um IServiceCollection e recebe tamb�m a mesma instancia de IServiceCollection
 
 //M�todo de extens�o Configuration:

public static IServiceCollection Configuration(this IServiceCollection serviceCollection) 
{
    serviceCollection.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
    serviceCollection.AddScoped<ProductService, ProductService>();
    serviceCollection.AddScoped<OrderItemService, OrderItemService>();
    return serviceCollection;
}

CONTROLLERS: 
 1 - Na pasta controllers possui uma outra pasta Base que cont�m um BaseController onde est� localizado um met�do Alert que dispara um alert bootstrap de sucesso ou erro.

 //M�todo Alert presente no BaseController:
 
public void Alert(AlertType alertType,string message)
    {
        switch (alertType)
        {
            case AlertType.sucess:
                TempData["AlertType"] = "alert-success";
                TempData["AlertMessage"] = message;
                break;
            case AlertType.error:
                TempData["AlertType"] = "alert-warning";
                TempData["AlertMessage"] = message;
                break;
        }
        
    }
}

2 - Esse controller sera herdado por todos os outros controllers visando que o m�todo alert sera utilizado para comunicar ao usuario se uma opera��o foi bem sucedida ou n�o.

 //Exemplo da heran�a de todos os controllers criados neste projeto:

 public class ClientController : BaseController

MAPPERPROFILES: 

1 - Contem a classe Profiles que herda de Profile do pr�prio AutoMapper onde s�o configurados os Maps de uma classe para outra.

2 - Alguns Maps s�o mais complexos que outros necessitando especificar algumas propriedades e de onde essa propriedade ira receber a informa��o

 //M�todo que cria um map e especifica tamb�m uma propriedade especifica e de onde a informa��o dessa propriedade ser� mapeada: 
 CreateMap<Order, OrderOutput>()
     .ForMember( x => x.ClientLastName, cfg => cfg.MapFrom(src => src.Client.LastName))
     .ForMember( x => x.ClientFirstName, cfg => cfg.MapFrom(src => src.Client.FirstName));


SHARED - _LAYOUT:

1 - Na Shared _Layout se encontra uma l�gica que renderiza o alert 

 //L�gica para a apresenta��o do alert:
 
@if(TempData["AlertMessage"] != null)
{
    <div class="alert @TempData["AlertType"] alert-dismissible fade show" role="alert">
        <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
        @TempData["AlertMessage"]
    </div>
}

PROGRAM: 
 1 - Adiciona o servi�o do autoMapper e indica onde buscar os Maps 

 //Adicionado o AutoMapper: 

 builder.Services.AddAutoMapper(
    cfg => cfg.AddProfile<Profiles>());

 2 - Adiciona os servi�os do m�todo de exten��o criado 

 //Adicionando o m�todo de extens�o:

 builder.Services.Configuration()

3 - Uma pequena altera��o na rota padr�o para que a view default renderizada seja do OrderController

 //Alterando a rota padr�o: 

 app.MapControllerRoute(
    name: "default",
    pattern: "/{controller=Order}/{action=Index}/{id?}");
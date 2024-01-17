# SimpleCRUD_MVC

Este projeto é um CRUD simples realizado seguindo o padrão MVC

DIVISÃO DAS PASTAS: 

 -Business: Se encontra as partes do negocio do projeto como os serviços e suas interfaces e os inputModelViews e os outputModelViews.

 -Configuration: Contem a classe ServiceConfiguration que conta com um método de extensão Configuration onde todos os services são adicionados.

 -Controllers: contém os controllers do projeto.

 -Data: Se encontra a classe Context e os models que representam os modelos do DB.

 -MaperProfiles: Contem a classe profiles onde configuramos os Maps que o AutoMapper ira utilizar ao realizar o mapeamento de uma classe a outra.

 -Migrations: Contém o historico de migraçoes do proeto com seus ups e downs

 -View: Contem as views de cada controller

SERVICES:

1 - Os services foram implementado utilizando o conceito de Generics onde se tem um serviço base(BaseService) que recebe um tipo generico(T) e possui métodos basicos que serão utilizados por varias entidades;

2 - O conceito de herança também foi aplicado em casos onde uma rotina de instruções peculiar deve ser executada criando classes service que herdam de BaseService e sobrescrevem algum método especifico.

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

3 - O conceito de sobrecarga de métodos também foi aplicado onde métodos com mesmo nome e mesmo retorno foram escritos porém com paramentros diferentes 
 
//A baixo dois métodos com mesmo nome e retorno porém que recebem parametros diferentes:

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
 
 1 - A pasta Configurations que contém a classe ServiceConfiguration que centraliza todos os serviços que serão configurados no Program.cs através de um método de extensão que retorna um IServiceCollection e recebe também a mesma instancia de IServiceCollection
 
 //Método de extensão Configuration:

    public static IServiceCollection Configuration(this IServiceCollection serviceCollection) 
    {
       serviceCollection.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
       serviceCollection.AddScoped<ProductService, ProductService>();
       serviceCollection.AddScoped<OrderItemService, OrderItemService>();
       return serviceCollection;
    }

CONTROLLERS: 

 1 - Na pasta controllers possui uma outra pasta Base que contém um BaseController onde está localizado um metódo Alert que dispara um alert bootstrap de sucesso ou erro.

 //Método Alert presente no BaseController:
 
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


2 - Esse controller sera herdado por todos os outros controllers visando que o método alert sera utilizado para comunicar ao usuario se uma operação foi bem sucedida ou não.

 //Exemplo da herança de todos os controllers criados neste projeto:

    public class ClientController : BaseController
    {
       private readonly IBaseService<Client> _generalService;
    
       public ClientController(IBaseService<Client> generalService)
       {
          _generalService = generalService;
       }
       
    }

MAPERPROFILES: 

1 - Contem a classe Profiles que herda de Profile do próprio AutoMapper onde são configurados os Maps de uma classe para outra.

2 - Alguns Maps são mais complexos que outros necessitando especificar algumas propriedades e de onde essa propriedade ira receber a informação

 //Método que cria um map e especifica também uma propriedade especifica e de onde a informação dessa propriedade será mapeada:
 
    CreateMap<Order, OrderOutput>()
        .ForMember( x => x.ClientLastName, cfg => cfg.MapFrom(src => src.Client.LastName))
        .ForMember( x => x.ClientFirstName, cfg => cfg.MapFrom(src => src.Client.FirstName));


SHARED - _LAYOUT:

1 - Na Shared _Layout se encontra uma lógica que renderiza o alert 

 //Lógica para a apresentação do alert:
 
    @if(TempData["AlertMessage"] != null)
    {
       <div class="alert @TempData["AlertType"] alert-dismissible fade show" role="alert">
          <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
          @TempData["AlertMessage"]
       </div>
    }

PROGRAM: 

 1 - Adiciona o serviço do autoMapper e indica onde buscar os Maps 

 //Adicionado o AutoMapper: 

    builder.Services.AddAutoMapper(
        cfg => cfg.AddProfile<Profiles>());

 2 - Adiciona os serviços do método de extenção criado 

 //Adicionando o método de extensão:

    builder.Services.Configuration()

3 - Uma pequena alteração na rota padrão para que a view default renderizada seja do OrderController

 //Alterando a rota padrão: 

    app.MapControllerRoute(
       name: "default",
       pattern: "/{controller=Order}/{action=Index}/{id?}");

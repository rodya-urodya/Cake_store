using Microsoft.EntityFrameworkCore;
using Cake_store.Context.Entities;
using Cake_store.Context;

namespace Cake_store.Services.Products;

public class ProductModel
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

    // Navigation property for images
    //public virtual ICollection<Image> Images { get; set; }

    //// Navigation property for reviews
    //public virtual ICollection<Review> Reviews { get; set; }
    public virtual ICollection<string> Categories { get; set; }
}


//public class BookModelProfile : Profile
//{
//    public BookModelProfile()
//    {
//        CreateMap<Book, BookModel>()
//            .BeforeMap<BookModelActions>()
//            .ForMember(dest => dest.Id, opt => opt.Ignore())
//            .ForMember(dest => dest.AuthorId, opt => opt.Ignore())
//            .ForMember(dest => dest.AuthorName, opt => opt.Ignore())
//            .ForMember(dest => dest.Categories, opt => opt.Ignore())
//            ;
//    }

    //public class BookModelActions : IMappingAction<Book, BookModel>
    //{
    //    private readonly IDbContextFactory<MainDbContext> contextFactory;

    //    public BookModelActions(IDbContextFactory<MainDbContext> contextFactory)
    //    {
    //        this.contextFactory = contextFactory;
    //    }

    //    public void Process(Book source, BookModel destination, ResolutionContext context)
    //    {
    //        using var db = contextFactory.CreateDbContext();

    //        var book = db.Books.Include(x => x.Author).ThenInclude(x => x.Detail).FirstOrDefault(x => x.Id == source.Id);

    //        destination.Id = book.Uid;
    //        destination.AuthorId = book.Author.Uid;
    //        destination.AuthorName = book.Author.Name + " " + book.Author.Detail.Family;
    //        destination.Categories = book.Categories?.Select(x => x.Title);
    //    }
    //}
}
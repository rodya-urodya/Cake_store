using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Cake_store.Context.Entities;
using Cake_store.Context;
using Cake_store.Settings;
using FluentValidation;
using Cake_store.Settings;

namespace Cake_store.Services.Products;

public class CreateModel
{
    public string Name { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

    public Guid UserId { get; set; }

    // Navigation property for images
    //public virtual ICollection<Image> Images { get; set; }

    //// Navigation property for reviews
    //public virtual ICollection<Review> Reviews { get; set; }
    public virtual ICollection<string> Categories { get; set; }
}

public class CreateModelProfile : Profile
{
    public CreateModelProfile()
    {
        CreateMap<CreateModel, Product>()
            .ForMember(dest => dest.UserId, opt => opt.Ignore())
            .AfterMap<CreateModelActions>();
    }

    public class CreateModelActions : IMappingAction<CreateModel, Product>
    {
        private readonly IDbContextFactory<MainDbContext> contextFactory;

        public CreateModelActions(IDbContextFactory<MainDbContext> contextFactory)
        {
            this.contextFactory = contextFactory;
        }

        public void Process(CreateModel source, Product destination, ResolutionContext context)
        {
            using var db = contextFactory.CreateDbContext();

            var user = db.Users.FirstOrDefault(x => x.Id == source.UserId);

            destination.UserId = user.Id;
        }
    }
}

public class CreateProductModelValidator : AbstractValidator<CreateModel>
{
    public CreateProductModelValidator(IDbContextFactory<MainDbContext> contextFactory)
    {
        RuleFor(x => x.Name).ProductName();

        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("Author is required")
            .Must((id) =>
            {
                using var context = contextFactory.CreateDbContext();
                var found = context.Users.Any(a => a.Id == id);
                return found;
            }).WithMessage("Author not found");

        RuleFor(x => x.Description)
            .MaximumLength(1000).WithMessage("Maximum length is 1000");
    }
}
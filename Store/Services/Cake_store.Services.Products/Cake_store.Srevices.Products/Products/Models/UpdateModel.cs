using AutoMapper;
using FluentValidation;
using Cake_store.Settings;
using Cake_store.Context.Entities;
using Cake_store.Settings;

namespace Cake_store.Services.Products;

public class UpdateModel
{
    public string Name { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

    // Navigation property for images
    //public virtual ICollection<Image> Images { get; set; }

    //// Navigation property for reviews
    //public virtual ICollection<Review> Reviews { get; set; }
    public virtual ICollection<string> Categories { get; set; }
}

public class UpdateModelProfile : Profile
{
    public UpdateModelProfile()
    {
        CreateMap<UpdateModel, Product>();
    }
}

public class UpdateModelValidator : AbstractValidator<UpdateModel>
{
    public UpdateModelValidator()
    {
        RuleFor(x => x.Name).ProductName();

        RuleFor(x => x.Description)
            .MaximumLength(1000).WithMessage("Maximum length is 1000");
    }
}
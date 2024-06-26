﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Cake_store.Context.Entities;
using Cake_store.Context;
using Cake_store.Settings;
using FluentValidation;

namespace Cake_store.Services.Products;

public class CreateModel
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

//public class CreateModelProfile : Profile
//{
//    public CreateModelProfile()
//    {
//        CreateMap<CreateModel, Book>()
//            .ForMember(dest => dest.AuthorId, opt => opt.Ignore())
//            .AfterMap<CreateModelActions>();
//    }

//    public class CreateModelActions : IMappingAction<CreateModel, Book>
//    {
//        private readonly IDbContextFactory<MainDbContext> contextFactory;

//        public CreateModelActions(IDbContextFactory<MainDbContext> contextFactory)
//        {
//            this.contextFactory = contextFactory;
//        }

//        public void Process(CreateModel source, Book destination, ResolutionContext context)
//        {
//            using var db = contextFactory.CreateDbContext();

//            var author = db.Authors.FirstOrDefault(x => x.Uid == source.AuthorId);

//            destination.AuthorId = author.Id;
//        }
//    }
//}

//public class CreateBookModelValidator : AbstractValidator<CreateModel>
//{
//    public CreateBookModelValidator(IDbContextFactory<MainDbContext> contextFactory)
//    {
//        RuleFor(x => x.Title).BookTitle();

//        RuleFor(x => x.AuthorId)
//            .NotEmpty().WithMessage("Author is required")
//            .Must((id) =>
//            {
//                using var context = contextFactory.CreateDbContext();
//                var found = context.Authors.Any(a => a.Uid == id);
//                return found;
//            }).WithMessage("Author not found");

//        RuleFor(x => x.Description)
//            .MaximumLength(1000).WithMessage("Maximum length is 1000");
//    }
//}
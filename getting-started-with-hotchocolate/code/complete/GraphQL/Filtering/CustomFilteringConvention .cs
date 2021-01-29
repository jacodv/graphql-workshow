using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Data.Filters;
using HotChocolate.Data.Filters.Expressions;
using HotChocolate.Types.Descriptors;

namespace ConferencePlanner.GraphQL.Filtering
{
  public static class CustomOperations
  {
    public const int Like = 1025;
  }

  public class CustomFilteringConvention : FilterConvention
  {
    protected override FilterConventionDefinition CreateDefinition(IConventionContext context)
    {
      return base.CreateDefinition(context);
    }

    protected override void Configure(IFilterConventionDescriptor descriptor)
    {
      descriptor.AddDefaults();

      //descriptor.AddInvariantComparison();

      descriptor
        .Configure<StringOperationFilterInputType>(
          x => x
            .Operation(CustomOperations.Like)
        );

      descriptor
        .Operation(CustomOperations.Like).Name("like");

      descriptor.AddProviderExtension(
        new QueryableFilterProviderExtension(
          x => x
            .AddFieldHandler<QueryableStringInvariantLikeHandler>()));
    }
  }

  public static class CustomerFilterConventionExtensions
  {
    public static IFilterConventionDescriptor AddInvariantComparison(
      this IFilterConventionDescriptor conventionDescriptor)
    {
      return conventionDescriptor
        .Configure<StringOperationFilterInputType>(x=>
          x.Operation(CustomOperations.Like)
            .Name("like")  
        );
    }
      
  }
}

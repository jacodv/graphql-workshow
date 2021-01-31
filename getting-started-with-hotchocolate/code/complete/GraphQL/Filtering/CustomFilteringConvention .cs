using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Data.Filters;
using HotChocolate.Data.Filters.Expressions;
using HotChocolate.Types;
using HotChocolate.Types.Descriptors;

namespace ConferencePlanner.GraphQL.Filtering
{
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
            .Type<StringType>()
        );

      descriptor
        .Operation(CustomOperations.Like).Name("like");

      descriptor.AddProviderExtension(
        new QueryableFilterProviderExtension(
          x => x
            .AddFieldHandler<QueryableStringInvariantLikeHandler>()));
    }
  }
}

using HotChocolate.Data.Filters;

namespace ConferencePlanner.GraphQL.Filtering
{
  public static class CustomerFilterConventionExtensions
  {
    public static IFilterConventionDescriptor AddInvariantComparison(
      this IFilterConventionDescriptor conventionDescriptor)
    {
      return conventionDescriptor
        .Configure<StringOperationFilterInputType>(x =>
          x.Operation(CustomOperations.Like)
            .Name("like")
          );
    }
  }
}


using CodeSample.Data;

namespace CodeSample.Types
{

    public record AddThingInput(
         string Name
        );


    public record UpdateThingInput(
        int Id,
        string Name
        );


    public record Payload<T>(T Entity);

    public class Mutation
    {


        [UseTestDbContext]
        public async Task<Payload<Thing>> AddOrderAsync(
                    [ScopedService] TestDbContext context,
                  CancellationToken cancellationToken,
                  AddThingInput input)
        {
            var thing = new Thing
            {
                Name = input.Name
            };


            context.Things.Add(thing);
            await context.SaveChangesAsync(cancellationToken);

            return new Payload<Thing>(thing);

        }
    }
}

using CodeSample.Data;

namespace CodeSample.Types
{


    public record ThingInput(int? Id, string Name);


    public record Payload<T>(T Entity);

    public class Mutation
    {

        [UseTestDbContext]
        public async Task<Payload<Thing>> UpsertThing(
               [ScopedService] TestDbContext context,
             CancellationToken cancellationToken,
             ThingInput input)
        {

            Thing thing;

            if (input.Id == null)
            {
                thing = new Thing
                {
                    Name = input.Name
                };

                context.Things.Add(thing);

            }
            else
            {
                thing = new Thing
                {
                    Name = input.Name
                };

                context.Things.Update(thing);
            }

            await context.SaveChangesAsync(cancellationToken);

            return new Payload<Thing>(thing);
        }
    }
}
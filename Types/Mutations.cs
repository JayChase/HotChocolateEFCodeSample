
using CodeSample.Data;
using Microsoft.EntityFrameworkCore;

namespace CodeSample.Types
{


    public record AddThingInput(string Name);
    public record UpdateThingInput(int Id, string Name);
    public record DeleteThingInput(int Id);


    public record Payload<T>(T Entity);

    public class Mutation
    {

        [UseTestDbContext]
        public async Task<Payload<Thing>> AddThing(
               [ScopedService] TestDbContext context,
             CancellationToken cancellationToken,
             AddThingInput input)
        {

            Thing thing = new Thing
            {
                Name = input.Name
            };

            context.Things.Add(thing);


            await context.SaveChangesAsync(cancellationToken);

            return new Payload<Thing>(thing);
        }

        [UseTestDbContext]
        public async Task<Payload<Thing>> UpdateThing(
           [ScopedService] TestDbContext context,
         CancellationToken cancellationToken,
         UpdateThingInput input)
        {

            Thing thing = new Thing
            {
                Id = input.Id,
                Name = input.Name
            };


            context.Things.Update(thing);

            await context.SaveChangesAsync(cancellationToken);

            return new Payload<Thing>(thing);
        }

        [UseTestDbContext]
        public async Task<Payload<Thing>> DeleteThing(
         [ScopedService] TestDbContext context,
       CancellationToken cancellationToken,
       DeleteThingInput input)
        {

            Thing thing = new Thing
            {
                Id = input.Id
            };


            context.Things.Attach(thing);

            context.Entry(thing).State = EntityState.Deleted;

            await context.SaveChangesAsync(cancellationToken);

            return new Payload<Thing>(thing);
        }
    }
}


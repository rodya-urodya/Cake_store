namespace Cake_store.Services.Actions;

using Cake_store.Services.RabbitMq;
using System.Threading.Tasks;

public class Action : IAction
{
    private readonly IRabbitMq rabbitMq;

    public Action(IRabbitMq rabbitMq)
    {
        this.rabbitMq = rabbitMq;
    }

    public async Task PublicateProduct(PublicateProductModel model)
    {
        await rabbitMq.PushAsync(QueueNames.PUBLICATE_PRODUCT, model);
    }
}

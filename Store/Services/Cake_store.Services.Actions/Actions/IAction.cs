namespace Cake_store.Services.Actions;

using System.Threading.Tasks;

public interface IAction
{
    Task PublicateProduct(PublicateProductModel model);
}

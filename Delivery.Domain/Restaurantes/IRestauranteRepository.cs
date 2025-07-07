

namespace Delivery.Domain.Restaurantes;


public interface IRestauranteRepository
{
    void Add(Restaurante restaurante);

    void Update(Restaurante restaurante);
}
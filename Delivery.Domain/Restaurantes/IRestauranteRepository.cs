

namespace Delivery.Domain.Restaurantes;


public interface IRestauranteRepository
{
    void Add(Restaurante restaurante);

    void Update(Restaurante restaurante);


    Task<List<Restaurante>> GetAll(CancellationToken cancellationToken = default);
    Task<Restaurante?> GetByIdRestauranteAsync(RestauranteId id, CancellationToken cancellationToken = default);

    Task<Restaurante?> GetByIdAsync(RestauranteId id, CancellationToken cancellationToken = default);

    Task<bool> NombreExists(string nombre, CancellationToken cancellationToken = default);
}
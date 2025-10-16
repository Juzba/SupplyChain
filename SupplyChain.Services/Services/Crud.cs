using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using SupplyChain.Infrastructure.Repositories;

namespace SupplyChain.Services.Services;

public interface ICrud<T> where T : class
{
    Task<IEnumerable<T>?> GetAsync(CancellationToken cancellationToken = default);
}




public class Crud<T>(IRepository<T> repository, ILogger<Crud<T>> logger) : ICrud<T> where T : class
{
    private readonly IRepository<T> _repository = repository;
    private readonly ILogger<Crud<T>> _logger = logger;


    public async Task<IEnumerable<T>?> GetAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            var result = await _repository.GetAllAsync(cancellationToken);
            _logger.LogInformation("Retrieved all entities of type {EntityType}", typeof(T).Name);
            return result;
        }
        catch (Exception)
        {
            _logger.LogError("Error retrieving entities of type {EntityType}", typeof(T).Name);
            return null;
        }
    }
















}

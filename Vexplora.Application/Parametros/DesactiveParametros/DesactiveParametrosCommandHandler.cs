using Vexplora.Application.Abstractions.Messaging;
using Vexplora.Domain.Abstractions;
using Vexplora.Domain.Parametros;

namespace Vexplora.Application.Parametros.DesactiveParametros;

internal sealed class DeactiveParametrosCommandHandler : ICommandHandler<DesactiveParametrosCommand, int>
{
    private readonly IParametroRepository _parametroRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeactiveParametrosCommandHandler(
        IParametroRepository parametroRepository,
        IUnitOfWork unitOfWork
    )
    {
        _parametroRepository = parametroRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(DesactiveParametrosCommand request, CancellationToken cancellationToken)
    {
        var parametro = await _parametroRepository.GetByIdAsync(request.Id, cancellationToken);

        if (parametro is null)
        {
            return Result.Failure<int>(ParametroErrors.ParametroNotFound);
        }

        var entities = await _parametroRepository.GetAllParametrosBySubnivelToDelete(request.Id, cancellationToken);

        entities.Add(parametro);

        if (entities.Count > 0)
        {

            foreach (var relatedEntity in entities)
            {
               relatedEntity.Desactive();

               _parametroRepository.Update(relatedEntity);
            }
        }

        
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(parametro.Id!.Value, Message.Desactivate);
    }
}
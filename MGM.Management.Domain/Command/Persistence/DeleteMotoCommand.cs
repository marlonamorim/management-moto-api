using MGM.Management.Domain.Assertions;
using MGM.Management.Domain.ValueObjects;
using MGM.Management.Moto.Repository;

namespace MGM.Management.Domain.Command.Persistence
{
    public class DeleteMotoCommand(IMotoRepository motoRepository, IMotoAssertion motoAssertion) : IDeleteMotoCommand
    {
        private readonly IMotoRepository _motoRepository = motoRepository;
        private readonly IMotoAssertion _motoAssertion = motoAssertion;

        private MotoValueObject? Moto;

        public void AddPayload(MotoValueObject obj)
            => Moto = obj;

        public async Task ExecuteAsync()
        {
            _motoAssertion.MotoNeedsToBeValid(Moto);

            var moto = await _motoRepository.GetByIdAsync(Moto!.Id);

            _motoAssertion.MotoEntityMustExists(moto, Moto.Id);

            //TODO: Criar estrutura de locação para validação de exclusão de moto sem locação

            await _motoRepository.RemoveAsync(moto.Id);
        }
    }
}

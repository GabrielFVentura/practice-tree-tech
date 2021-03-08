using System.Threading.Tasks;

namespace Domain.Interfaces.IServices
{
    public interface IEmailService
    {
        Task<bool> EnviarEmail(string descricaoalarme, string nomeEquipamento);
    }
}
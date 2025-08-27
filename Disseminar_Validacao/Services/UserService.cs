using Disseminar_Validacao.Models;
using Disseminar_Validacao.Models.Notification;
using Disseminar_Validacao.Models.Validations;

namespace Disseminar_Validacao.Services
{
    public class UserService : BaseService, IUserService
    {
        public UserService(INotificator notificator) : base(notificator)
        {
        }
        public void AddUser(User user)
        {
            if(!ExecuteValidation(new UserValidation(), user))
            {
                return;
            }

            Notify("Usuário cadastrado com sucesso!");            

        }

        public void Dispose()
        {

        }
    }
}

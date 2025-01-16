using Dominio.DTO;

namespace Dominio.Accessors.Email
{
    public interface IEmailAccessor : IAccessor<EmailDTO>
    {
        public bool Exist(int id);
        public EmailDTO GetById(int id);
        public EmailDTO Save(EmailDTO emailDto);
        public void Update(EmailDTO emailDto);
        public void Delete(EmailDTO emailDto);
    }
}

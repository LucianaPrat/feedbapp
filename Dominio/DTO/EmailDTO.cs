using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Dominio.DTO
{
    public class EmailDTO : IValidation
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string Topic { get; set; }
        public string Body { get; set; }
        public EmailDTO() { }
        public EmailDTO(string address, string topic, string body)
        {
            Address = address;
            Topic = topic;
            Body = body;
        }
        public virtual void IsValid()
        {
            if (string.IsNullOrEmpty(Topic))
            {
                throw new Exception("El asunto no debe estar vacío.");
            }
            if (string.IsNullOrEmpty(Body))
            {
                throw new Exception("El body no puede estar vacío.");
            }
            if (Topic.Length > 30)
            {
                throw new Exception("El asunto debe tener menos de 20 caracteres.");
            }
            if (Topic.Length < 3)
            {
                throw new Exception("El asunto debe tener mas de 3 caracteres.");
            }
        }
    }
}

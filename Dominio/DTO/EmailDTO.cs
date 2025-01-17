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
                throw new Exception("The subject cannot be empty.");
            }
            if (string.IsNullOrEmpty(Body))
            {
                throw new Exception("The body cannot be empty.");
            }
            if (Topic.Length > 30)
            {
                throw new Exception("The subject must be less than 30 characters.");
            }
            if (Topic.Length < 3)
            {
                throw new Exception("The subject must be more than 3 characters.");
            }
        }
    }
}

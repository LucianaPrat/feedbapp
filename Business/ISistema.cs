using Business.Models;
using Dominio;
using Dominio.DTO;
using Dominio.Entity;

namespace Business
{
    public interface ISistema
    {
        List<ClientDTO> GetClients();
        List<Developer> GetDevelopers();
        List<LeaderDTO> GetLeaders();
        List<Admin> GetAdmins();
        List<Position> GetPositions();
        List<Deliveries> GetDeliveries();
        //void AddClient(ClientDTO clientDTO);
        void AddPerson(PersonDTO p);
        void AddPosition(Position p);
        void AddDeliveries(Deliveries d);
        void AddAdmin(Admin a);

        void CreateClient(ClientDTO c);
        void CreateDeveloper(Developer dev);

        void CreatePosition(Position p);
        void CreateLeader(LeaderDTO l);
        void CreateDeliverie(Deliveries d);
        Deliveries? SerchDeliveries(int id);
        LeaderDTO? SerchLeaderId(int id);
        Developer? SerchDeveloperId(int id);
        ClientDTO? SearchClientId(int id);

        Position? SerchPositionId(int id);

        void EditClient(ClientDTO c);
        void EditDeveloper(Developer d);
        void EditPosition(Position p);
        void EditLeader(LeaderDTO l);

        void DeleteClient(ClientDTO? cli);

        void DeleteLeader(LeaderDTO? li);
        void DeleteDeveloper(Developer? dev);
        void DeletePosition(Position? p);
        Admin Login(String email, String password);
        void SendEmail(int positionId, EmailDTO e, EmailConfig emailConfig);
    }
}

using Business.Models;
using Dominio;
using Dominio.DTO;
using Dominio.Entity;

namespace Business
{
    public interface ISistema
    {
        List<ClientDTO> GetClients();
        List<DeveloperDTO> GetDevelopers();
        List<LeaderDTO> GetLeaders();
        List<AdminDTO> GetAdmins();
        List<Position> GetPositions();
        List<Deliveries> GetDeliveries();
        //void AddClient(ClientDTO clientDTO);
        void AddPerson(PersonDTO p);
        void AddPosition(Position p);
        void AddDeliveries(Deliveries d);
        void AddAdmin(AdminDTO a);

        void CreateClient(ClientDTO c);
        void CreateDeveloper(DeveloperDTO dev);

        void CreatePosition(Position p);
        void CreateLeader(LeaderDTO l);
        void CreateDeliverie(Deliveries d);
        Deliveries? SearchDeliveries(int id);
        LeaderDTO? SearchLeaderId(int id);
        DeveloperDTO? SearchDeveloperId(int id);
        ClientDTO? SearchClientId(int id);

        Position? SerchPositionId(int id);

        void EditClient(ClientDTO c);
        void EditDeveloper(DeveloperDTO d);
        void EditPosition(Position p);
        void EditLeader(LeaderDTO l);

        void DeleteClient(ClientDTO? cli);

        void DeleteLeader(LeaderDTO? li);
        void DeleteDeveloper(DeveloperDTO? dev);
        void DeletePosition(Position? p);
        AdminDTO Login(String email, String password);
        void SendEmail(int positionId, EmailDTO e, EmailConfig emailConfig);
    }
}

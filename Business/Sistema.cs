using Business.Models;
using Dominio;
using Dominio.Accessors.Clients;
using Dominio.Accessors.Leaders;
using Dominio.DTO;
using Dominio.Entity;
using Feedbapp.Services;

namespace Business
{
    public class Sistema : ISistema
    {
        private static List<PersonDTO> _persons { get; set; } = new List<PersonDTO>();
        private static List<Position> _positions { get; set; } = new List<Position>();
        private static List<Deliveries> _deliveries { get; set; } = new List<Deliveries>();

        private IEmailService _emailService;
        private IClientAccessor _clientAccesor;
        private ILeaderAccessor _leaderAccesor;

        public Sistema(IEmailService emailService, IClientAccessor clientAccesor, ILeaderAccessor leaderAccesor)
        {
            _emailService = emailService;
            _clientAccesor = clientAccesor;
            _leaderAccesor = leaderAccesor;

            Precarga();
        }         

        #region Gets
        public List<ClientDTO> GetClients()
        {
            List<ClientDTO> results = new List<ClientDTO>();

            var clients = _clientAccesor.GetAll();

            foreach ( ClientDTO client in clients )
            {
                if(client.Removed == false)
                {
                    results.Add( client );
                }
            }
            return results;
        }
        public List<Developer> GetDevelopers()
        {
            List<Developer> Developers = new List<Developer>();
            foreach (var p in _persons)
            {
                if (p is Developer)
                {
                    Developer d = (Developer)p;
                    Developers.Add(d);
                }
            }
            return Developers;
        }
        public List<LeaderDTO> GetLeaders()
        {
            List<LeaderDTO> results = new List<LeaderDTO>();

            var leaders = _leaderAccesor.GetAll();

            foreach (LeaderDTO leader in leaders)
            {
                if (leader.Removed == false)
                {
                    results.Add(leader);
                }
            }
            return results;
        }

        public List<Admin> GetAdmins()
        {
            List<Admin> admins = new List<Admin>();
            foreach (var p in _persons)
            {
                if (p is Admin && p.Removed == false)
                {
                    Admin a = (Admin)p;
                    admins.Add(a);
                }
            }
            return admins;
        }
        public List<Position> GetPositions()
        {
            List<Position> pos = new List<Position>();
            foreach (var p in _positions)
            {
                if (p.Removed == false)
                {
                    pos.Add(p);
                }
            }
            return pos;
        }
        public List<Deliveries> GetDeliveries()
        {
            return _deliveries;
        }
        #endregion

        #region Adds
        //public void AddClient(ClientDTO clientDTO)
        //{
        //    _clientAccesor.Save(clientDTO);

        //    // convertir DTO en Entity
        //    //var clientEntity = new Client
        //    //{
        //    //    Name = clientDTO.Name                
        //    //};

        //    // insertar en la base de datos

        //    //using (var context = new ApplicationDbContext())
        //    //{
        //    //    //_clients.Add(c);
        //    //}
        //}
        public void AddPerson(PersonDTO p)
        {
            _persons.Add(p);
        }
        public void AddPosition(Position p)
        {
            _positions.Add(p);
        }       
        public void AddDeliveries(Deliveries d)
        {
            _deliveries.Add(d);
        }
        public void AddAdmin(Admin a)
        {
            a.IsValid();
            _persons.Add(a);
        }
        #endregion

        #region Preload
        public void Precarga()
        {
            //ClientDTO client1 = new ClientDTO("Frasal");
            //ClientDTO client2 = new ClientDTO("Youtube");
            //Leader leader1 = new Leader("Daniel", "Frascarelli", "lucianaprates10@gmail.com", client1);
            //Leader leader2 = new Leader("Angela", "Diaz", "angela@gmail.com", client2);
            //Developer developer1 = new Developer("Luciana", "Prates", "lu@gmail.com", leader1);
            //Developer developer2 = new Developer("Martina", "Perez", "martina@gmail.com", leader2);

            //AddClient(client1);
            //AddClient(client2);
            //AddPerson(leader1);
            //AddPerson(leader2);
            //AddPerson(developer1);
            //AddPerson(developer2);

            //Position position1 = new Position(Recurrence.OtherWeek, "Hola", developer1);
            //Position position2 = new Position(Recurrence.Weekly, "Chau", developer2);

            //AddPosition(position1);
            //AddPosition(position2);

        }
        #endregion

        #region Creates
        public void CreateClient(ClientDTO c)
        {
            _clientAccesor.Save(c);

            //if (!_clients.Contains(c))
            //{
            //    c.IsValid();
            //    _clients.Add(c);
            //}
            //else
            //{
            //    throw new Exception("Ya existe este cliente");
            //}

        }
        public void CreateDeveloper(Developer dev)
        {
            List<Developer> devs = GetDevelopers();
            if (!devs.Contains(dev))
            {
                dev.IsValid();
                LeaderDTO l = SearchLeaderId(dev.Leader.Id);
                dev.Leader = l;
                _persons.Add(dev);
            }
            else
            {
                throw new Exception("Ya existe este cliente");
            }
        }

        public void CreatePosition(Position p)
        {
            if (!_positions.Contains(p))
            {
                Developer? d = SerchDeveloperId(p.Developer.Id);
                p.Developer = d;
                _positions.Add(p);
            }
            else
            {
                throw new Exception("Ya existe esta posicion");
            }
        }
        public void CreateLeader(LeaderDTO l)
        {
            _leaderAccesor.Save(l);
            // TODO
            //if (!GetLeaders().Contains(l))
            //{
            //    ClientDTO c = SearchClientId(l.Client.Id);
            //    l.Client = c;
            //    _persons.Add(l);
            //}
            //else
            //{
            //    throw new Exception("Ya existe esta posicion");
            //}
        }
        public void CreateDeliverie(Deliveries d)
        {
            
            _deliveries.Add(d);
            
        }
        #endregion

        #region Serch
        public Deliveries? SerchDeliveries(int id)
        {
            foreach (var d in _deliveries)
            {
                if (d.Id == id)
                {
                    return d;
                }
            }
            return null;
        }
        public LeaderDTO? SerchLeaderId(int id)
        {
            foreach (LeaderDTO l in GetLeaders())
            {
                if (l.Id == id)
                {
                    return l;
                }
            }
            return null;
        }
        public Developer? SerchDeveloperId(int id)
        {
            foreach (var d in _persons)
            {
                if (d.Id == id && d is Developer)
                {
                    return (Developer)d;
                }
            }
            return null;
        }
        public ClientDTO? SearchClientId(int id)
        {
            return _clientAccesor.GetById(id);

            //foreach (var c in _clients)
            //{
            //    if (c.Id == id)
            //    {
            //        return c;
            //    }
            //}
            //return null;
        }
        private LeaderDTO? SearchLeaderId(int leaderID)
        {
            foreach (LeaderDTO l in GetLeaders())
            {
                if (l.Id == leaderID)
                {
                    return l;
                }
            }
            return null;
        }
        private Developer SearchDeveloperId(int id)
        {
            foreach (Developer p in GetDevelopers())
            {
                if (p.Id == id)
                {
                    return p;
                }
            }
            return null;
        }
        public Position? SerchPositionId(int id)
        {
            foreach (Position p in _positions)
            {
                if (p.Id == id)
                {
                    return p;
                }
            }
            return null;
        }

        #endregion

        #region Edits
        public void EditClient(ClientDTO c)
        {
            _clientAccesor.Update(c);
        }
        public void EditDeveloper(Developer d)
        {
            foreach (Developer dev in GetDevelopers())
            {
                if (dev.Id == d.Id)
                {
                    LeaderDTO l = SearchLeaderId(d.Leader.Id);
                    dev.Name = d.Name;
                    dev.LastName = d.LastName;
                    dev.Email = d.Email;
                    dev.Leader = l;
                    dev.Active = d.Active;
                }
            }
        }
        public void EditPosition(Position p)
        {
            foreach (Position po in _positions)
            {
                if (po.Id == p.Id)
                {
                    Developer dev = SearchDeveloperId(p.Developer.Id);
                    po.Developer = dev;
                    po.Recurrence = p.Recurrence;
                    po.Description = p.Description;
                }
            }
        }
        public void EditLeader(LeaderDTO l)
        {
            _leaderAccesor.Update(l);
        }
        #endregion

        #region Deletes
        public void DeleteClient(ClientDTO c)
        {
            _clientAccesor.Delete(c);
        }

        public void DeleteLeader(LeaderDTO l)
        {
            _leaderAccesor.Delete(l);
        }

        public void DeleteDeveloper(Developer? dev)
        {
            foreach (var d in _persons)
            {
                if (d == dev)
                {
                   d.Delete();
                }
            }
        }
        public void DeletePosition(Position? p)
        {
            foreach (var po in _positions)
            {
                if (po == p)
                {
                    po.Delete();
                }
            }
        }
        #endregion
        public Admin Login(String email, String password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                throw new Exception("Los campos no deben ser vacios");
            }
            foreach (Admin a in GetAdmins())
            { //Si los datos recividos coinciden con un usuario registrado permite
                if (a.Email.Equals(email) && a.Password.Equals(password))
                {
                    return a;
                }
            }
            throw new Exception("No existe un administrador con esos datos");
        }

        public void SendEmail(int positionId,EmailDTO e, EmailConfig emailConfig)
        {
            e.IsValid();
            Position p = SerchPositionId(positionId);
            CreateDeliverie(new Deliveries(p,e));

            _emailService.SendEmail(e, emailConfig);

        }
    }
}

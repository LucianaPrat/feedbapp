﻿using Business.Models;
using Dominio;
using Dominio.Accessors.Clients;
using Dominio.Accessors.Leaders;
using Dominio.Accessors.Clients;
using Dominio.Accessors.Email;
using Dominio.DTO;
using Dominio.Entity;
using Feedbapp.Services;
using Dominio.Accessors.Developers;

namespace Business
{
    public class Sistema : ISistema
    {
        private static List<PersonDTO> _persons { get; set; } = new List<PersonDTO>();
        private static List<Position> _positions { get; set; } = new List<Position>();
        private static List<Deliveries> _deliveries { get; set; } = new List<Deliveries>();

        private IEmailService _emailService;
        private IEmailAccessor _emailAccesor;
        private IClientAccessor _clientAccesor;
        private ILeaderAccessor _leaderAccesor;
        private IDeveloperAccessor _developerAccesor;

        public Sistema(IEmailService emailService, 
            IEmailAccessor emailAccesor, 
            IClientAccessor clientAccesor,
            ILeaderAccessor leaderAccesor,
            IDeveloperAccessor developerAccesor)
        {
            _emailService = emailService;
            _emailAccesor = emailAccesor;
            _clientAccesor = clientAccesor;
            _leaderAccesor = leaderAccesor;
            _developerAccesor = developerAccesor;
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
        public List<DeveloperDTO> GetDevelopers()
        {
            List<DeveloperDTO> results = new List<DeveloperDTO>();

            var developers = _developerAccesor.GetAll();

            foreach (DeveloperDTO developer in developers)
            {
                if (developer.Removed == false)
                {
                    results.Add(developer);
                }
            }
            return results;
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
            ClientDTO client1 = SearchClientId(1);
            ClientDTO client2 = SearchClientId(1);

            //Leader leader1 = new Leader("Daniel", "Frascarelli", "lucianaprates10@gmail.com", client1);
            //Leader leader2 = new Leader("Angela", "Diaz", "angela@gmail.com", client2);
            //Developer developer1 = new Developer("Luciana", "Prates", "lu@gmail.com", leader1);
            //Developer developer2 = new Developer("Martina", "Perez", "martina@gmail.com", leader2);

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
        public void CreateDeveloper(DeveloperDTO dev)
        {
            _developerAccesor.Save(dev);
        }

        public void CreatePosition(Position p)
        {
            //if (!_positions.Contains(p))
            //{
            //    Developer? d = SearchDeveloperId(p.Developer.Id);
            //    p.Developer = d;
            //    _positions.Add(p);
            //}
            //else
            //{
            //    throw new Exception("Ya existe esta posicion");
            //}
        }
        public void CreateLeader(LeaderDTO l)
        {
            _leaderAccesor.Save(l);
        }
        public void CreateDeliverie(Deliveries d)
        {            
            _deliveries.Add(d);            
        }

        #endregion

        #region Serch
        public Deliveries? SearchDeliveries(int id)
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
        public LeaderDTO? SearchLeaderId(int id)
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
        public DeveloperDTO? SearchDeveloperId(int id)
        {
            return _developerAccesor.GetById(id); 
        }
        public ClientDTO? SearchClientId(int id)
        {
            return _clientAccesor.GetById(id); 
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
        public void EditDeveloper(DeveloperDTO d)
        {
            _developerAccesor.Update(d);
        }
        public void EditPosition(Position p)
        {
            //foreach (Position po in _positions)
            //{
            //    if (po.Id == p.Id)
            //    {
            //        DeveloperDTO dev = SearchDeveloperId(p.Developer.Id);
            //        po.Developer = dev;
            //        po.Recurrence = p.Recurrence;
            //        po.Description = p.Description;
            //    }
            //}
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

        public void DeleteDeveloper(DeveloperDTO? dev)
        {
            _developerAccesor.Delete(dev);
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

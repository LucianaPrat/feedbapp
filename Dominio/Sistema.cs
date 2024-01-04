using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Sistema
    {
        #region Singleton
        private static Sistema _instancia = null;
        public Sistema()
        {
            Precarga();
        }
        public static Sistema GetInstancia()
        {

            if (_instancia == null)
            {
                _instancia = new Sistema();
            }
            return _instancia;
        }
        #endregion
        private List<Client> _clients { get; set; } = new List<Client>();
        private List<Person> _persons { get; set; } = new List<Person>();
        private List<Position> _positions { get; set; } = new List<Position>();
        private List<Deliveries> _deliveries { get; set; } = new List<Deliveries>();

        #region Gets
        public List<Client> GetClients()
        {
            List < Client > c = new List < Client >();
            foreach ( Client client in _clients )
            {
                if(client.Removed == false)
                {
                    c.Add( client );
                }
            }
            return c;
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
        public List<Leader> GetLeaders()
        {
            List<Leader> leaders = new List<Leader>();
            foreach (var p in _persons)
            {
                if (p is Leader && p.Removed == false)
                {
                    Leader d = (Leader)p;
                    leaders.Add(d);
                }
            }
            return leaders;
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
        public void AddClient(Client c)
        {
            _clients.Add(c);
        }
        public void AddPerson(Person p)
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
        #endregion

        #region Preload
        public void Precarga()
        {
            Client client1 = new Client("Frasal");
            Client client2 = new Client("Youtube");
            Leader leader1 = new Leader("Daniel", "Frascarelli", "frasca@gmail.com", client1);
            Leader leader2 = new Leader("Angela", "Diaz", "angela@gmail.com", client2);
            Developer developer1 = new Developer("Luciana", "Prates", "lu@gmail.com", leader1);
            Developer developer2 = new Developer("Martina", "Perez", "martina@gmail.com", leader2);

            AddClient(client1);
            AddClient(client2);
            AddPerson(leader1);
            AddPerson(leader2);
            AddPerson(developer1);
            AddPerson(developer2);

            Position position1 = new Position(Recurrence.OtherWeek, "Hola", developer1);
            Position position2 = new Position(Recurrence.Weekly, "Chau", developer2);

            AddPosition(position1);
            AddPosition(position2);

            Deliveries deliveries1 = new Deliveries(new DateTime(2001, 10, 10), position1);
            Deliveries deliveries2 = new Deliveries(new DateTime(2001, 10, 13), position2);

            AddDeliveries(deliveries1);
            AddDeliveries(deliveries2);
        }
        #endregion

        #region Creates
        public void CreateClient(Client c)
        {
            if (!_clients.Contains(c))
            {
                _clients.Add(c);
            }
            else
            {
                throw new Exception("Ya existe este cliente");
            }
        }
        public void CreateDeveloper(Developer dev)
        {
            List<Developer> devs = GetDevelopers();
            if (!devs.Contains(dev))
            {
                Leader l = SearchLeaderId(dev.Leader.Id);
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
        public void CreateLeader(Leader l)
        {
            if (!GetLeaders().Contains(l))
            {
                Client c = SerchClientId(l.Client.Id);
                l.Client = c;
                _persons.Add(l);
            }
            else
            {
                throw new Exception("Ya existe esta posicion");
            }
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
        public Leader? SerchLeaderId(int id)
        {
            foreach (Leader l in GetLeaders())
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
        public Client? SerchClientId(int id)
        {
            foreach (var c in _clients)
            {
                if (c.Id == id)
                {
                    return c;
                }
            }
            return null;
        }
        private Leader? SearchLeaderId(int leaderID)
        {
            foreach (Leader l in GetLeaders())
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
        public void EditClient(Client c)
        {
            foreach (Client cli in _clients)
            {
                if (cli.Id == c.Id)
                {
                    cli.Name = c.Name;
                    cli.Active = c.Active;
                }
            }
        }
        public void EditDeveloper(Developer d)
        {
            foreach (Developer dev in GetDevelopers())
            {
                if (dev.Id == d.Id)
                {
                    Leader l = SearchLeaderId(d.Leader.Id);
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
        public void EditLeader(Leader l)
        {
            foreach (Leader le in GetLeaders())
            {
                if (l.Id == le.Id)
                {
                    Client? c = SerchClientId(l.Client.Id);
                    le.Name = l.Name;
                    le.LastName = l.LastName;
                    le.Client = c;
                }
            }
        }
        #endregion

        #region Deletes
        public void DeleteClient(Client? cli)
        {
            foreach (Client c in _clients)
            {
                if (c == cli)
                {
                    c.Delete();
                }
            }
        }

        public void DeleteLeader(Leader? li)
        {
            foreach (var l in _persons)
            {
                if (l == li)
                {
                    l.Delete();
                }
            }
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
    }
}

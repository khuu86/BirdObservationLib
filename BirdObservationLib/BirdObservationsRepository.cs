using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdObservationLib
{
    public class BirdObservationsRepository
    {
        private List<BirdObservation> _observations; // Liste af BirdObservation-objekter
        private int _nextId = 1; // Id til næste BirdObservation-objekt

        public BirdObservationsRepository()
        {
            _observations = new List<BirdObservation>();
            {
                Add(new BirdObservation { Species = "Blåmejse", HowMany = 2 });
                Add(new BirdObservation { Species = "Ringdue", HowMany = 8 });
                Add(new BirdObservation { Species = "Musvit", HowMany = 2 });
                Add(new BirdObservation { Species = "Sølvmåge", HowMany = 12 });
                Add(new BirdObservation { Species = "Spætmejse", HowMany = 1 });
            };
        }

        // returnerer en liste af alle BirdObservation-objekter
        public List<BirdObservation> GetAll(int? minHowMany = null, string? species = null)
        {
            // Copy Constructor
            List<BirdObservation> result = new List<BirdObservation>(_observations);
            if (minHowMany != null)
            {
                result = result.FindAll(o => o.HowMany >= minHowMany);
            }
            if (species != null)
            {
                result = result.FindAll(o => o.Species.Contains(species, StringComparison.OrdinalIgnoreCase));
            }
            return result;
        }

        // returnerer et BirdObservation-objekt med en bestemt Id
        public BirdObservation? GetById(int id)
        {
            return _observations.FirstOrDefault(o => o.Id == id);
        }

        // Tilføjer et BirdObservation-objekt til listen
        public BirdObservation Add(BirdObservation observation)
        {
            observation.Validate();
            observation.Id = _nextId++;
            _observations.Add(observation);
            return observation;
        }

        // Sletter et BirdObservation-objekt fra listen
        public BirdObservation? Delete(int id)
        {
            BirdObservation? observation = GetById(id);
            if (observation == null)
            {
                return null;
            }
            _observations.Remove(observation);
            return observation;
        }

        // HUSK BUILD -> BUILD SOLUTION













    }
}

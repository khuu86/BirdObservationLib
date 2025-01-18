namespace BirdObservationLib
{
    public class BirdObservation
    {
        public int Id { get; set; }
        public string Species { get; set; }
        public int HowMany { get; set; }

        public void ValidateSpecies()
        {
            if (Species == null)
            {
                throw new ArgumentNullException("Species cannot be null");
            }
            if (Species.Length < 2)
            {
                throw new ArgumentOutOfRangeException("Species must be at least 2 characters long");
            }
        }

        public void ValidateHowMany()
        {
            if (HowMany <= 0)
            {
                throw new ArgumentOutOfRangeException("How many must be greater than 0");
            }
        }

        public void Validate()
        {
            ValidateSpecies();
            ValidateHowMany();
        }

        public override string ToString()
        {
            return $"Id: {Id}, Species: {Species}, HowMany: {HowMany}";
        }


    }
}

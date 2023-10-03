namespace ActorRepositoryLib
{
    public class Actor
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int BirthYear { get; set; }

        public void ValidateName()
        {
            if (String.IsNullOrWhiteSpace(Name))
            {
                throw new ArgumentNullException("Name må ikke være null eller tom!");
            }
            if (Name.Length < 4)
            {
                throw new ArgumentOutOfRangeException("Name skal være mindst 4 tegn lang");
            }
        }

        public void ValidateBirthYear()
        {
            if (BirthYear < 1820)
            {
                throw new ArgumentOutOfRangeException("Birthyear skal være 1820 eller højere");
            }
        }

        public void Validate()
        {
            ValidateName();
            ValidateBirthYear();
        }

        public override string ToString()
        {
            return $"{Id} : {Name} : {BirthYear}";
        }
    }
}
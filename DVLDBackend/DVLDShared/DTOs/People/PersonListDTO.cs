namespace DVLDShared.DTOs.People;

    public sealed class PersonListDto
    {
        public int PersonId { get; set; }

        public string NationalNo { get; set; } = string.Empty;

        public string FullName { get; set; } = string.Empty;

        public DateTime DateOfBirth { get; set; }

        public string Gender { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public string? Email { get; set; }

        public string CountryName { get; set; } = string.Empty;

        public string? ImagePath { get; set; }
    }
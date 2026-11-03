namespace DVLDShared.DTOs.ApplicationsType;

public class ApplicationsTypeDTO
{
    public ApplicationsTypeDTO(int ApplicationTypeId, string ApplicationTypeTitle, decimal ApplicationFees)
    {
        this.ApplicationTypeId = ApplicationTypeId;
        this.ApplicationTypeTitle = ApplicationTypeTitle;
        this.ApplicationFees = ApplicationFees;
    }

    public int ApplicationTypeId { get; set; }

    public string ApplicationTypeTitle { get; set; }

    public decimal ApplicationFees { get; set; }
}

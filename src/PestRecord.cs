public class PestRecord
{
    public int Id { get; set; }
    public string PestType { get; set; }
    public string Location { get; set; }
    public string Severity { get; set; }
    public string Status { get; set; }
    public string TechnicianName { get; set; }
    public string TreatmentApplied { get; set; }
    public DateTime DateReported { get; set; }

    public PestRecord(int id, string pestType, string location, 
                      string severity, string status, 
                      string technicianName, string treatmentApplied, 
                      DateTime dateReported)
    {
        Id = id;
        PestType = pestType;
        Location = location;
        Severity = severity;
        Status = status;
        TechnicianName = technicianName;
        TreatmentApplied = treatmentApplied;
        DateReported = dateReported;
    }

    public override string ToString()
    {
        return $"ID: {Id} | Pest: {PestType} | Location: {Location} | " +
               $"Severity: {Severity} | Status: {Status} | " +
               $"Technician: {TechnicianName} | Treatment: {TreatmentApplied} | " +
               $"Date: {DateReported.ToShortDateString()}";
    }
}
namespace ProjetoMAUI.Models;

public sealed class Candidate
{
    public string Office { get; set; } = "";
    public string Name { get; set; } = "";
    public string Party { get; set; } = "";
    public string Number { get; set; } = "";
    public bool Optional { get; set; }
    public string DisplayName => string.IsNullOrWhiteSpace(Name) ? "A definir" : Name;
    public string DisplayParty => string.IsNullOrWhiteSpace(Party) ? "Apoio ainda não informado" : Party;
    public string DisplayNumber => string.IsNullOrWhiteSpace(Number) ? "—" : Number;
    public string Initials => string.IsNullOrWhiteSpace(Name) ? "?" : string.Concat(Name
        .Split(' ', StringSplitOptions.RemoveEmptyEntries).Take(2)
        .Select(part => part[0])).ToUpperInvariant();
}

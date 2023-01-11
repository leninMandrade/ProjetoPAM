namespace PAM.Endpoints.Games

{
    public record GameRequest(string Name, string Developer, string Publisher, string Platform, bool Multiplayer, string Genre, string Country);
}
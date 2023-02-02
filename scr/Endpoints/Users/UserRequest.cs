namespace PAM.Endpoints.Users;

public record UserRequest(string Name, string Email, string Password, string NickName);
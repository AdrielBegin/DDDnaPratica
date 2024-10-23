namespace BuberDinner.Contracts.AuthenticationResponse;
public record LoginRequest(
    string email,
    string password 
    );

    
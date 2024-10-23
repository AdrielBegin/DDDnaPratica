namespace BuberDinner.Contracts.AuthenticationResponse;
public record RegisterRequest(
    string firstName,
    string lastName,
    string email,
    string password 
    );

    
namespace BuberDinner.Contracts.AuthenticationResponse;
public record AuthenticationResponse(
    Guid id,
    string firstName,
    string lastName,
    string email,
    string token 
    );

    
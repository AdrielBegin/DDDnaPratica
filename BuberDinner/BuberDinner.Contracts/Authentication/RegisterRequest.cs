namespace BuberDinner.Contracts.AuthenticationResponse;
public record RegisterRequest(
    string FirstName,
    string LastName,
    string Email,
    string Password 
    );

    
namespace Schoolme.Domain.ValueObjects;

public sealed record HomeAddress(
    string Street,
    string City,
    string PostalCode,
    string Country);
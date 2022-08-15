using Newtonsoft.Json;

class Persone
{
    [JsonProperty("Фамилия: ")]
    public string? LastName { get; private set; }
    [JsonProperty("Имя: ")]
    public string? FirstName { get; private set; }

    [JsonProperty("Возраст: ")]
    public byte? Age { get; private set; }

    public Persone(string? lastName, string? firstName, byte? age)
    {
        LastName = lastName;
        FirstName = firstName;
        Age = age;
    }
}
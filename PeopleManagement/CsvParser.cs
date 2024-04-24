class CsvParser
{
    public List<Person> Parse()
    {
        List<Person> people = new List<Person>();
        // Read file
        string filePath = @"C:\Users\Tika Khadka\Desktop\git\Assignment 2\Data\People.csv";
        var lines = File.ReadAllLines(filePath);
        
        // Parsing
        foreach(var line in lines.Skip(1))
        {
            var parts = line.Split(",", StringSplitOptions.RemoveEmptyEntries);
            var person = new Person
            {
                index = int.Parse(parts[0]),
                userId = parts[1],
                firstName = parts[2],
                lastName = parts[3],
                sex = Enum.Parse<Gender>(parts[4]),
                email = parts[5],
                phone = parts[6],
                dob = DateTime.Parse(parts[7]),
                jobTitle = parts[8]
            };

            people.Add(person);
        }
        
        return people;
    }
}
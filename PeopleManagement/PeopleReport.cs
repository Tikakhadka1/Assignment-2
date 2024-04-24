class PeopleReport
{
    public void SaveMales(List<Person> people)
    {
        var males = people.Where(p => p.sex == Gender.Male).ToList();
        WriteToCsv(males, "males.csv");
    }

    public void SaveFemales(List<Person> people)
    {
        var adultFemales = people.Where(p => p.sex == Gender.Female && (DateTime.Now.Year - p.dob.Year) >= 20).ToList();
        WriteToCsv(adultFemales, "adultfemales.csv");
    }

    public void SaveDotComUsers(List<Person> people)
    {
        var dotComUsers = people.Where(p => p.email.EndsWith("@example.com")).Select(p => new { p.userId, p.email, p.phone }).ToList();
        using (StreamWriter writer = new StreamWriter("dotcomusers.csv"))
        {
            foreach (var user in dotComUsers)
            {
                writer.WriteLine($"{user.userId},{user.email},{user.phone}");
            }
        }
    }

    private void WriteToCsv(List<Person> people, string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            foreach (var person in people)
            {
                writer.WriteLine($"{person.index},{person.userId},{person.firstName},{person.lastName},{person.sex},{person.email},{person.phone},{person.dob},{person.jobTitle}");
            }
        }
    }
}